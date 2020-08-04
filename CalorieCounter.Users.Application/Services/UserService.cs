using CalorieCounter.Common.Domain.Adapters;
using CalorieCounter.Users.Application.Contract.DTOs;
using CalorieCounter.Users.Application.Contract.Services;
using CalorieCounter.Users.Application.Mappings;
using CalorieCounter.Users.Domain.Exceptions;
using CalorieCounter.Users.Domain.Model;
using CalorieCounter.Users.Domain.Repositories;
using System;

namespace CalorieCounter.Users.Application.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IEncryptionProvider _encryptionProvider;
        private readonly IIdentifierGenerator _identifierGenerator;
        private readonly IDailyActivityRepository _dailyActivityRepository;

        public UserService(
            IUserRepository userRepository, 
            IEncryptionProvider encryptionProvider, 
            IIdentifierGenerator identifierGenerator, 
            IDailyActivityRepository dailyActivityRepository)
        {
            _userRepository = userRepository;
            _encryptionProvider = encryptionProvider;
            _identifierGenerator = identifierGenerator;
            _dailyActivityRepository = dailyActivityRepository;
        }

        public UserDto GetUserBy(CredentialsDto dto)
        {
            User user = _userRepository.GetBy(dto.Email, dto.Password);
            if (user == null) throw new InvalidCredentialsException();

            return user.ToDto();
        }

        public UserDto GetUserBy(UserIdDto dto)
        {
            User user = _userRepository.Get(dto.Id);
            if (user == null) throw new UserDoesNotExistsException();

            return user.ToDto();
        }

        public UserIdDto CreateUser(CreateUserDto dto)
        {
            ThrowExceptionIfEmailIsAlreadyUsed(dto.Email);
            User user = CreateUserInstance(dto);
            InsertUser(user);

            return new UserIdDto(user.Id);
        }

        private void ThrowExceptionIfEmailIsAlreadyUsed(string email)
        {
            User user = _userRepository.GetBy(email);
            if (user != null) throw new EmailAlreadyUsedException();
        }

        private User CreateUserInstance(CreateUserDto dto)
        {
            string id = _identifierGenerator.GetIdentifier();
            string encryptedPassword = _encryptionProvider.Encrypt(dto.Password);
            Enum.TryParse(dto.Gender, out Gender gender);
            
            DailyActivity dailyActivity = _dailyActivityRepository.Get(dto.DailyActivityId);
            if (dailyActivity == null) throw new DailyActivityDoesNotExistsException();

            return User.FromBuilder()
                .SetGeneralInformation(id, dto.Name)
                .SetCredentials(dto.Email, encryptedPassword)
                .SetBodyMeasures(dto.Age, dto.Weight, dto.Height, gender, dailyActivity)
                .GetInstance();
        }

        private void InsertUser(User user)
        {
            if (user.IsInvalid) 
                throw new InvalidUserException(user.GetBrokenRules());

            _userRepository.Insert(user);
        }
    }
}
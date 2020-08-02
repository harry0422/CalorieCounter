using CalorieCounter.Common.Domain.Adapters;
using CalorieCounter.Users.Application.Contract;
using CalorieCounter.Users.Application.Mappings;
using CalorieCounter.Users.Domain.Exceptions;
using CalorieCounter.Users.Domain.Model;
using CalorieCounter.Users.Domain.Repositories;

namespace CalorieCounter.Users.Application.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IEncryptionProvider _encryptionProvider;
        private readonly IIdentifierGenerator _identifierGenerator;

        public UserService(IUserRepository userRepository, IEncryptionProvider encryptionProvider, IIdentifierGenerator identifierGenerator)
        {
            _userRepository = userRepository;
            _encryptionProvider = encryptionProvider;
            _identifierGenerator = identifierGenerator;
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
            User user = CreateUserInstance(dto.Email, dto.Password, dto.Name, dto.Age);
            InsertUser(user);

            return new UserIdDto(user.Id);
        }

        private void ThrowExceptionIfEmailIsAlreadyUsed(string email)
        {
            User user = _userRepository.GetBy(email);
            if (user != null) throw new EmailAlreadyUsedException();
        }

        private User CreateUserInstance(string email, string password, string name, int age)
        {
            string id = _identifierGenerator.GetIdentifier();
            string encryptedPassword = _encryptionProvider.Encrypt(password);

            return new User(id, email, encryptedPassword, name, age);
        }

        private void InsertUser(User user)
        {
            if (user.IsInvalid) 
                throw new InvalidUserException(user.GetBrokenRules());

            _userRepository.Insert(user);
        }
    }
}
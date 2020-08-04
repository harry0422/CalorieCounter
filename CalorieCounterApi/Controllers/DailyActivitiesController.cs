using CalorieCounter.Users.Application.Contract.DTOs;
using CalorieCounter.Users.Application.Contract.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CalorieCounterApi.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class DailyActivitiesController : ControllerBase
    {
        private readonly IDailyActivityService _dailyActivityService;

        public DailyActivitiesController(IDailyActivityService dailyActivityService)
        {
            _dailyActivityService = dailyActivityService;
        }

        // GET: api/DailyActivities
        [HttpGet]
        public ActionResult Get()
        {
            IList<DailyActivityDto> dailyActivities = _dailyActivityService.GetDailyActivities();
            return Ok(dailyActivities);
        }

        // GET api/DailyActivities/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            throw new NotImplementedException();
        }
    }
}
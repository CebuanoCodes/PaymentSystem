using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PaymentSystem.Models;
using PaymentSystem.Repositories;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PaymentSystem.Controllers
{

    [Route("api/users")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IDataRepository _dataRepository;
        //private readonly ILogger<UserController> _logger;


        public UserController(IDataRepository dataRepository/*, ILogger<UserController> logger*/)
        {
            _dataRepository = dataRepository;
            //_logger = logger;
        }

        // GET: api/Users
        [HttpGet]
        public  IEnumerable<User> Get()

        {
            try
            {
                var user =  _dataRepository.GetAll();
                if (user == null)
                {
                    //_logger.LogInformation("Users not found.");
                    return (IEnumerable<User>)NotFound();
                }

                return user;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        // GET: api/Users/5
        [HttpGet("{id}")]
        [Authorize]
        public async Task<IActionResult> Get(int id)
        {
            try
            {
                //var currentUser = GetCurrentUser();
                var user = _dataRepository.Get(id);
                if (user == null)
                {
                    //_logger.LogInformation($"The user with the {id} does not exist");
                    return NotFound("User not found.");
                }

                return Ok(user);
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
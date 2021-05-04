using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProjectShopping.Entities;
using ProjectShopping.Models;
using ProjectShopping.services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectShopping.Controllers
{
    [Route("api/user")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IShoppingRepository _repository;
        private readonly IMapper _mapper;

        public UserController(IShoppingRepository repository, IMapper mapper)
        {
            _mapper = mapper;
            _repository = repository;
        }
        [HttpGet]
        public IEnumerable<User> GetAllUsers()

        {
            Console.WriteLine();
            return _repository.GetAllUsers();
        }

        [HttpPost]
        [Route("Signup")]
        public ActionResult AddNewUser([FromBody]UserCreationDTO user)
        {
            User ActualUser = _mapper.Map<User>(user);
            var res = _repository.AddUser(ActualUser);
            if (!res)
            {
                return StatusCode(409,$"email '{user.email}' already exist");
            }
            _repository.save();
            return Ok();
        } 

        [HttpPost]
        [Route("login")]
        public ActionResult<User> Login([FromBody] UserLoginDTO user)
        {
            var res = _repository.validateUser(user);
            if (res==null)
            {
                return StatusCode(401, $"email or password invalid");
            }
            return res;
        }
    }
}

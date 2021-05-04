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
    [Route("api/admin")]
    [ApiController]
    public class AdminController : ControllerBase
    {
        private readonly IShoppingRepository _repository;
        private readonly IMapper _mapper;
        public AdminController(IShoppingRepository repository, IMapper mapper)
        {
            _mapper = mapper;
            _repository = repository;
        }
        
        [HttpPost]
        [Route("Login")]
        public ActionResult<User> LoginAdmin([FromBody] UserLoginDTO user)
        {
            var res = _repository.validateUserAdmin(user);
            if (res==null)
            {
                return StatusCode(401, $"email or password invalid");
            }
            return res;
        }

        [HttpPut]
        [Route("product/{id}")]
        public ActionResult UpdateProduct(Guid id,ProductUpdateDTO product)
        {
            var productFromRepo = _repository.GetProduct(id);
            _mapper.Map(product, productFromRepo);
            _repository.save();
            return Ok();

        }

        [HttpPost]
        [Route("product")]
        public ActionResult PostProducts(ProductCreatingDTO p)
        {
            var productEntity = _mapper.Map<Product>(p);
            _repository.AddProduct(productEntity);
            _repository.save();
            return Ok();
        }
    }
}

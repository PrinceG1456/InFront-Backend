using Infront.Services.IServices;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Infront.Api.Controllers.v1
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {

        private readonly IUserService _userService;
        private readonly ICacheService _cacheService;


        public UsersController(IUserService usersService, ICacheService cacheService)
        {
            _userService = usersService;
            _cacheService = cacheService;
        }

        [HttpGet]
        [Route("/user")]
        public async Task<IActionResult> CacheUser()
        {
            var users = await _userService.GetAllAsync();
            return Ok(users);
        }

        [HttpGet]
        [Route("/ClearCache")]
        public IActionResult CacheRemove()
        {
            _cacheService.ClearCache();
            return Ok("Cache Cleared Successfully");
        }
    }
}

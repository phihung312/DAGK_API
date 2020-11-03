using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BUS.Interface;
using BUS.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;

namespace Api_SprintRetrospective.Controllers
{
    public class LoginController : BaseController
    {
        private readonly IUserService _UserService;
        private readonly ITokenService _TokenService;
        public LoginController(IUserService userService, ITokenService tokenService)
        {
            _UserService = userService;
            _TokenService = tokenService;
        }
        [Route("api/login")]
        [HttpPost]
        public IActionResult Login([FromBody] JObject login)
        {
            var error = new ErrorObject(Error.SUCCESS);
            try
            {
                JToken jToken;
                if (!login.TryGetValue("username", out jToken)) return Ok(error.Failed("username invalid."));
                var username = jToken.Value<string>();
                if (!login.TryGetValue("password", out jToken)) return Ok(error.Failed("password invalid."));
                var password = jToken.Value<string>();

                var result = _UserService.Login(username, password);
                if (result.Code == Error.SUCCESS.Code)
                {
                    var token = _TokenService.CreateToken(result.GetData<User>());
                    _User = result.GetData<User>();
                    return Ok(error.SetData(token));
                }
                else
                {
                    return Ok(result);
                }
            }
            catch (Exception ex)
            {
                return Ok(error.System(ex));
            }
        }
    }
}
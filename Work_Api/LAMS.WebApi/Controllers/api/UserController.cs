using FluentValidation;
using LAMS.Logic.Common.Services.Users;
using LAMS.WebApi.Models.Users;
using Swagger.Net.Annotations;
using System;
using System.Net;
using System.Net.Http;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;

namespace LAMS.WebApi.Controllers.api
{
    /// <summary>
    /// API controller управления пользователями.
    /// </summary>
     [System.Web.Mvc.AllowAnonymous]
    [RoutePrefix("api/user")]
    public class UserController : ApiController
    {
        private readonly IUserService _service;

        
        public UserController(IUserService userService)
        {
            _service = userService;
        }

        [SwaggerResponseRemoveDefaults]
        [HttpGet, Route("signin")]
        public async Task<IHttpActionResult> SignIn([FromUri] string userName, [FromUri] string password)
        {
            if (String.IsNullOrEmpty(userName))
                return StatusCode(HttpStatusCode.NoContent);

            var user = await _service.SignIn(userName, password);

            if (user == null)
                return Ok(0);
            else
                return Ok(user);
        }

        [SwaggerResponseRemoveDefaults]
        [HttpGet, Route("getuserinfo")]
        public async Task<IHttpActionResult> GetUserInfo([FromUri] string userName)
        {
            if (String.IsNullOrEmpty(userName))
                return StatusCode(HttpStatusCode.NoContent);

            var user = await _service.GetUserInfo(userName);

                return Ok(user);
        }

        [SwaggerResponseRemoveDefaults]
        [SwaggerResponse(HttpStatusCode.InternalServerError, "Произошла ошибка на сервере во время поиска")]
        [HttpGet, Route("deluser")]
        public async Task<IHttpActionResult> DelUser([FromUri] string Id)
        {
            if (String.IsNullOrEmpty(Id))
                return StatusCode(HttpStatusCode.NoContent);

            var user = await _service.DelUser(Id);

            return Ok(user);
        }

        [SwaggerResponseRemoveDefaults]
        [SwaggerResponse(HttpStatusCode.InternalServerError, "Произошла ошибка на сервере во время поиска")]
        [HttpGet, Route("getusers")]
        public async Task<IHttpActionResult> GetUsers()
        {    

            var user = await _service.GetUsers();

            return Ok(user);
        }
    }
}

using FluentValidation;
using LAMS.Logic.Common.Models.Users;
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
    [RoutePrefix("api/userregistration")]
    public class RegistrationController : ApiController
    {
        //Dependen Injection
        private readonly IRegistrationService _service;


        public RegistrationController(IRegistrationService registrationService)
        {
            _service = registrationService;
        }

        /// <summary>
        /// Регистрирует нового пользователя с уникальным Login.
        /// </summary>
        /// <param name="model">Модель пользователя, содержащая: Login, UserName and Password.</param>
        /// <returns></returns>
        [System.Web.Mvc.AllowAnonymous]
        [HttpPost, Route("register")]
        [SwaggerResponseRemoveDefaults]
        public async Task<IHttpActionResult> Register([FromBody] RegisterUser model)
        {


            var id = await _service.RegisterAsync(model.Email, model.UserName, model.Password);

            if (id == null)
            {
                // throws 409 conflict
                return Ok(0);
            }
            return Ok(id);
        }

        [SwaggerResponseRemoveDefaults]
        [HttpPost, Route("addhr")]
        public async Task<IHttpActionResult> HrRegistration([FromBody] User user)
        {
            var _docId = await _service.HrRegistration(user);

            return Ok(_docId);
        }


    }
}

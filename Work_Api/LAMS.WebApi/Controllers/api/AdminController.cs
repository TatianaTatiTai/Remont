using LAMS.Logic.Common.Models.Admin;
using LAMS.Logic.Common.Services.Admin;
using Swagger.Net.Annotations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;

namespace LAMS.WebApi.Controllers.api
{
    [System.Web.Mvc.AllowAnonymous]
    [RoutePrefix("api/admin")]
    public class AdminController : ApiController
    {
        private readonly IAdminService _service;

        public AdminController(IAdminService adminService)
        {
            _service = adminService;
        }

        [SwaggerResponseRemoveDefaults]
        [HttpPost, Route("addmaterial")]
        public async Task<IHttpActionResult> AddMaterial([FromBody] MaterialBLL material)
        {
            var _id = await _service.AddMaterial(material);

            return Ok(_id);
        }

        [SwaggerResponseRemoveDefaults]
        [HttpGet, Route("getmaterials")]
        public async Task<IHttpActionResult> GetMaterials()
        {
            var materials = await _service.GetMaterials();

            return Ok(materials);
        }

        [SwaggerResponseRemoveDefaults]
        [HttpPost, Route("addworktype")]
        public async Task<IHttpActionResult> AddWorkType([FromBody] WorkTypeBLL workType)
        {
            var _id = await _service.AddWorkType(workType);

            return Ok(_id);
        }

        [SwaggerResponseRemoveDefaults]
        [HttpGet, Route("getworktypes")]
        public async Task<IHttpActionResult> GetWorkTypes()
        {
            var workTypes = await _service.GetWorkTypes();

            return Ok(workTypes);
        }
    }
}
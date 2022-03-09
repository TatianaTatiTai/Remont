using LAMS.Logic.Common.Models.Work;
using LAMS.Logic.Common.Services.Work;
using Swagger.Net.Annotations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;

namespace LAMS.WebApi.Controllers.api
{
    [System.Web.Mvc.AllowAnonymous]
    [RoutePrefix("api/work")]
    public class WorkController : ApiController
    {
        private readonly IWorkService _service;

        public WorkController(IWorkService workService)
        {
            _service = workService;
        }

        [SwaggerResponseRemoveDefaults]
        [HttpPost, Route("addorder")]
        public async Task<IHttpActionResult> AddOrder([FromBody] OrderBLL order)
        {
            var _docId = await _service.AddOrder(order);

            return Ok(_docId);
        }

        [SwaggerResponseRemoveDefaults]
         [HttpGet, Route("getuserorders")]
        public async Task<IHttpActionResult> GetUserOrders([FromUri] string UserId)
        {
            var orders = await _service.GetUserOrders(UserId);

            return Ok(orders);
        }

        [SwaggerResponseRemoveDefaults]
        [HttpGet, Route("delorder")]
        public async Task<IHttpActionResult> DelOrder([FromUri] string Id)
        {
            var order = await _service.DelOrder(Id);

            return Ok(order);
        }

        [SwaggerResponseRemoveDefaults]
        [HttpGet, Route("approveorder")]
        public async Task<IHttpActionResult> ApproveOrder([FromUri] string id)
        {
            int _count = await _service.ApproveOrder(id);

            return Ok(_count);
        }
        [SwaggerResponseRemoveDefaults]
        [HttpGet, Route("rejectorder")]
        public async Task<IHttpActionResult> RejectOrder([FromUri] string id)
        {
            int _count = await _service.RejectOrder(id);

            return Ok(_count);
        }
    }
}
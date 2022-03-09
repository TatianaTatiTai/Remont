using LAMS.DataAccess.Common.Models.Work;
using LAMS.Logic.Common.Models.Work;
using LAMS.Logic.Common.Services.Worker;
using LAMS.WebApi.Areas.HttpResponses;
using Swagger.Net.Annotations;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;

namespace LAMS.WebApi.Controllers.api
{
    [System.Web.Mvc.AllowAnonymous]
    [RoutePrefix("api/worker")]
    public class WorkerController : ApiController
    {
        private readonly IWorkerService _service;

        public WorkerController(IWorkerService workerService)
        {
            _service = workerService;
        }

        [SwaggerResponseRemoveDefaults]
        [HttpGet, Route("getneworders")]
        public async Task<IHttpActionResult> GetNewOrders()
        {
            var orders = await _service.GetNewOrders();

            return Ok(orders);
        }

        [SwaggerResponseRemoveDefaults]
        [HttpGet, Route("getprocessingorders")]
        public async Task<IHttpActionResult> GetProcessingOrders()
        {
            var orders = await _service.GetProcessingOrders();

            return Ok(orders);
        }

        [SwaggerResponseRemoveDefaults]
        [HttpGet, Route("getworkorders")]
        public async Task<IHttpActionResult> GetWorkOrders()
        {
            var orders = await _service.GetWorkOrders();

            return Ok(orders);
        }

        [SwaggerResponseRemoveDefaults]
        [HttpGet, Route("getwaitorders")]
        public async Task<IHttpActionResult> GetWaitOrders()
        {
            var orders = await _service.GetWaitOrders();

            return Ok(orders);
        }

        [SwaggerResponseRemoveDefaults]
        [HttpGet, Route("getapproveorders")]
        public async Task<IHttpActionResult> GetApproveOrders()
        {
            var orders = await _service.GetApproveOrders();

            return Ok(orders);
        }

        [SwaggerResponseRemoveDefaults]
        [HttpGet, Route("getfinishorders")]
        public async Task<IHttpActionResult> GetFinishOrders()
        {
            var orders = await _service.GetFinishOrders();

            return Ok(orders);
        }
        [SwaggerResponseRemoveDefaults]
        [HttpGet, Route("finishorder")]
        public async Task<IHttpActionResult> FinishOrder([FromUri] string id)
        {
            int _count = await _service.FinishOrder(id);

            return Ok(_count);
        }

        [SwaggerResponseRemoveDefaults]
        [HttpGet, Route("processingorder")]
        public async Task<IHttpActionResult> ProcessingOrder([FromUri] string id)
        {
            int _count = await _service.ProcessingOrder(id);

            return Ok(_count);
        }

        [SwaggerResponseRemoveDefaults]
        [HttpGet, Route("waitorder")]
        public async Task<IHttpActionResult> WeitOrder([FromUri] string id)
        {
            int _count = await _service.WaitOrder(id);

            return Ok(_count);
        }

        [SwaggerResponseRemoveDefaults]
        [HttpGet, Route("workorder")]
        public async Task<IHttpActionResult> WorkOrder([FromUri] string id)
        {
            int _count = await _service.WorkOrder(id);

            return Ok(_count);
        }

        [SwaggerResponseRemoveDefaults]
        [HttpPost, Route("addordermaterial")]
        public async Task<IHttpActionResult> AddOrderMaterial([FromBody] OrderMaterialBLL orderMaterial)
        {
            var _id = await _service.AddOrderMaterial(orderMaterial);

            return Ok(_id);
        }

        [SwaggerResponseRemoveDefaults]
        [HttpGet, Route("getordermaterials")]
        public async Task<IHttpActionResult> GetOrderMaterials([FromUri] string IdOrder)
        {
            var orders = await _service.GetOrderMaterials(IdOrder);

            return Ok(orders);
        }
        [SwaggerResponseRemoveDefaults]
        [HttpGet, Route("getordermaterialssum")]
        public async Task<IHttpActionResult> GetOrderMaterialsSum([FromUri] string IdOrder)
        {
            var sum = await _service.GetOrderMaterialsSum(IdOrder);

            return Ok(sum);
        }
        [SwaggerResponseRemoveDefaults]
        [HttpGet, Route("delordermaterial")]
        public async Task<IHttpActionResult> DelOrderMaterial([FromUri] int Id)
        {
            var orderMaterial = await _service.DelOrderMaterial(Id);

            return Ok(orderMaterial);
        }

        [SwaggerResponseRemoveDefaults]
        [HttpPost, Route("addorderworktype")]
        public async Task<IHttpActionResult> AddOrderWokType([FromBody] OrderWorkTypeBLL orderWorkType)
        {
            var _id = await _service.AddOrderWorkType(orderWorkType);

            return Ok(_id);
        }

        [SwaggerResponseRemoveDefaults]
        [HttpGet, Route("getorderworktypes")]
        public async Task<IHttpActionResult> GetOrderWokTypes([FromUri] string IdOrder)
        {
            var orders = await _service.GetOrderWorkTypes(IdOrder);

            return Ok(orders);
        }
        [SwaggerResponseRemoveDefaults]
        [HttpGet, Route("getorderworktypessum")]
        public async Task<IHttpActionResult> GetOrderWokTypesSum([FromUri] string IdOrder)
        {
            var sum = await _service.GetOrderWorkTypesSum(IdOrder);

            return Ok(sum);
        }
        [SwaggerResponseRemoveDefaults]
        [HttpGet, Route("delorderworktype")]
        public async Task<IHttpActionResult> DelOrderWorkType([FromUri] int Id)
        {
            var orderMaterial = await _service.DelOrderWorkType(Id);

            return Ok(orderMaterial);
        }

        [SwaggerResponseRemoveDefaults]
        [HttpPost, Route("addworkercost")]
        public async Task<IHttpActionResult> AddWorkeCost([FromBody] OrderWorkerCostBLL orderWorkerCost)
        {
            var _id = await _service.AddWorkerCost(orderWorkerCost);

            return Ok(_id);
        }

        [SwaggerResponseRemoveDefaults]
        [HttpGet, Route("getworkercosts")]
        public async Task<IHttpActionResult> GetWorkerCosts([FromUri] string IdOrder)
        {
            var orders = await _service.GetWorkerCosts(IdOrder);

            return Ok(orders);
        }

        [SwaggerResponseRemoveDefaults]
        [HttpGet, Route("delworkercost")]
        public async Task<IHttpActionResult> DelWorkerCost([FromUri] int Id)
        {
            var orderMaterial = await _service.DelWorkerCost(Id);

            return Ok(orderMaterial);
        }

        [SwaggerResponseRemoveDefaults]
        [HttpGet, Route("getworkercostssum")]
        public async Task<IHttpActionResult> GetWorkerCostsSum([FromUri] string IdOrder)
        {
            var sum = await _service.GetWorkerCostsSum(IdOrder);

            return Ok(sum);
        }
        [SwaggerResponseRemoveDefaults]
        [HttpGet, Route("getonecost")]
        public async Task<IHttpActionResult> GetOneCost([FromUri] int Id)
        {
            var cost = await _service.GetOneCost(Id);

            return Ok(cost);
        }
        [SwaggerResponseRemoveDefaults]
        [HttpGet, Route("getonecostworktype")]
        public async Task<IHttpActionResult> GetOneCostWorkType([FromUri] int Id)
        {
            var cost = await _service.GetOneCostWorkType(Id);

            return Ok(cost);
        }

        [SwaggerResponseRemoveDefaults]
        [HttpPost, Route("addevaluation")]
        public async Task<IHttpActionResult> AddEvaluation([FromBody] EvaluationBLL evaluation)
        {
            var _id = await _service.AddEvaluation(evaluation);

            return Ok(_id);
        }

        [SwaggerResponseRemoveDefaults]
        [HttpGet, Route("getevaluation")]
        public async Task<IHttpActionResult> GetEvaluation([FromUri] string Id)
        {
            var cost = await _service.GetEvaluation(Id);

            return Ok(cost);
        }
        [SwaggerResponseRemoveDefaults]
        [HttpPost, Route("uploadFiles")]
        public async Task<IHttpActionResult> PostUploadFiles()
        {
            var httpRequest = HttpContext.Current.Request;

            if (httpRequest.Files.Count > 0)
            {
                string id = httpRequest.Form.GetValues("IdOrder")[0];
                int totalCount = Int32.Parse(httpRequest.Form.GetValues("textsCount")[0]);
                var textIndex = httpRequest.Form.GetValues("textIndex")[0];
                if (!string.IsNullOrEmpty(id))
                {
                    foreach (string file in httpRequest.Files)
                    {
                        var ext = file.Substring(file.LastIndexOf('.'), file.Length - file.LastIndexOf('.'));
                        var postedFile = httpRequest.Files[file];
                        var fileData = new MemoryStream();
                        postedFile.InputStream.CopyTo(fileData);

                        var doctext = new DocumentBLL { IdOrder = id, Name = file, Extension = ext, Text = fileData.ToArray(), Number = Int32.Parse(textIndex) };
                        int textId = await _service.AddTextAsync(doctext);
                    }

                    return Created("PostUploadFiles", id);
                }
                else
                    return BadRequest("Не валидный Id документа");
            }
            else
            {
                return BadRequest("Нет прикрепленных файлов");
            }
        }

        [SwaggerResponseRemoveDefaults]
        [HttpGet, Route("getnamesoftext")]
        public async Task<IHttpActionResult> GetNamesOfTexts([FromUri] string IdOrder)
        {
            IEnumerable<DocumentBLL> textsInfo = await _service.GetNamesOfTextsAsync(IdOrder);
            if (textsInfo == null)
            {
                return BadRequest("Ошибка в запросе");
            }

            return Ok(textsInfo);
        }
        [SwaggerResponseRemoveDefaults]
        [HttpGet, Route("gettextbyid")]
        public async Task<IHttpActionResult> GetTextById([FromUri] int id)
        {
            DocumentDb textArchive = _service.GetTextById(id);

            MemoryStream dataStream = new MemoryStream(textArchive.Text);


            return new FileActionResult(dataStream, Request, textArchive.Name);
        }

    }
}
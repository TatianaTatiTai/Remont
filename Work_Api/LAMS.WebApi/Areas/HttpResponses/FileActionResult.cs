using System.Net.Http;
using System.Web.Http;
using System.IO;
using System.Net;
using System.Threading.Tasks;
using System.Web;

namespace LAMS.WebApi.Areas.HttpResponses
{
	public class FileActionResult : IHttpActionResult
	{
		private readonly HttpRequestMessage _httpRequestMessage;
		private HttpResponseMessage _httpResponseMessage;

		private readonly string _fileName;
		private readonly MemoryStream _bookStuff;

		public FileActionResult(MemoryStream data, HttpRequestMessage request, string filename)
		{
			this._bookStuff = data;
			this._httpRequestMessage = request;
			this._fileName = filename;
		}

		public Task<HttpResponseMessage> ExecuteAsync(System.Threading.CancellationToken cancellationToken)
		{
			_httpResponseMessage = _httpRequestMessage.CreateResponse(HttpStatusCode.OK);
			_httpResponseMessage.Content = new StreamContent(_bookStuff);
			_httpResponseMessage.Content = new ByteArrayContent(_bookStuff.ToArray());
			_httpResponseMessage.Content.Headers.ContentDisposition = new System.Net.Http.Headers.ContentDispositionHeaderValue("attachment");
			_httpResponseMessage.Content.Headers.ContentDisposition.FileName = HttpUtility.UrlEncode(this._fileName, System.Text.Encoding.UTF8);
			_httpResponseMessage.Content.Headers.Add("Access-Control-Expose-Headers", "Content-Disposition");
			_httpResponseMessage.Content.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("application/octet-stream");

			return Task.FromResult(_httpResponseMessage);
		}
	}
}
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.StaticFiles;

namespace WebAPI_Core.API.Controllers
{
    [ApiController]
    [Route("api/Files")]
    public class FilesController : ControllerBase
    {
        FileExtensionContentTypeProvider _filecontenttype;
        public FilesController(FileExtensionContentTypeProvider filecontenttype)
        {
            _filecontenttype = filecontenttype;
        }

        #region Download File from api
        [HttpGet("{address}")]
        public ActionResult GetFile(string address)
        {
            // path file
            var pathToFile = "SRV-549621.rar";
            if (!System.IO.File.Exists(pathToFile))
            {
                return NotFound();
            }

            var bytes = System.IO.File.ReadAllBytes(pathToFile);


            //check content type file
            if (!_filecontenttype.TryGetContentType(pathToFile, out var contentType))
            {
                contentType = "application/octet-stream";
            }
            return File(bytes, contentType, Path.GetFileName(pathToFile));

        }
        #endregion
    }
}

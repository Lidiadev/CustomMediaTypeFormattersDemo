using CustomMediaTypeFormattersDemo.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Http;

namespace CustomMediaTypeFormattersDemo.Controllers
{
    public class AlbumController : ApiController
    {
        // POST: api/Album
        public IHttpActionResult Post([FromBody]AlbumModel albumModel)
        {
            if (albumModel != null)
            {
                Album album = new Album(albumModel);
                return Ok();
            }
            return BadRequest();
        }
    }
}

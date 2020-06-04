using CarRental.BLL.Interfaces;
using CarRental.WEB.Models;
using System.IO;
using System.Linq;
using System.Web.Hosting;
using System.Web.Http;

namespace CarRental.WEB.Controllers.Api
{
    [Authorize(Roles = RoleName.AdminAndManager)]
    public class ManufacturersController : ApiController
    {
        private readonly IManufacturerService manufacturerService;

        public ManufacturersController(IManufacturerService serv)
        {
            manufacturerService = serv;
        }

        // GET /api/manufacturers
        [HttpGet]
        [AllowAnonymous]
        public IHttpActionResult GetAll()
        {
            return Ok(manufacturerService.GetAll().Where(m => m.IsDeleted == false).ToList());
        }

        // GET /api/manufacturers/1
        [HttpGet]
        public IHttpActionResult Get(int id)
        {
            var manufacturerDto = manufacturerService.Get(id);

            if (manufacturerDto == null)
                return NotFound();

            return Ok(manufacturerDto);
        }

        // DELETE api/manufacturers/1
        [HttpDelete]
        public IHttpActionResult Delete(int id)
        {
            var manufacturerDto = manufacturerService.Get(id);
            if (manufacturerDto != null)
            {
                try
                {
                    manufacturerService.Delete(id);
                }
                catch
                {
                    return InternalServerError();
                }
                if (manufacturerDto.PictureLink != null)
                {
                    var pathToPicture = HostingEnvironment.MapPath(manufacturerDto.PictureLink);
                    if (File.Exists(pathToPicture))
                    {
                        File.Delete(pathToPicture);
                    }
                }
                return Ok("Item was deleted");
            }
            return NotFound();
        }
    }
}

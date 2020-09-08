using CarRental.BLL.Interfaces;
using CarRental.WEB.Models;
using System.IO;
using System.Linq;
using System.Web.Hosting;
using System.Web.Http;

namespace CarRental.WEB.Controllers.Api
{
    [Authorize(Roles = RoleName.AdminAndManager)]
    public class CarsController : ApiController
    {
        private readonly ICarService carService;

        public CarsController(ICarService serv)
        {
            carService = serv;
        }

        // GET /api/cars
        [HttpGet]
        [AllowAnonymous]
        public IHttpActionResult GetAll()
        {
            return Ok(carService.GetAllCars().Where(c => c.IsDeleted == false).ToList());
        }

        // DELETE /api/delete/1
        [HttpDelete]
        public IHttpActionResult Delete(int id)
        {
            var carDto = carService.Get(id);
            if (carDto != null)
            {
                try
                {
                    carService.Delete(id);
                }
                catch
                {
                    return InternalServerError();
                }
                if (carDto.PictureLink != null)
                {
                    var pathToPicture = HostingEnvironment.MapPath(carDto.PictureLink);
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

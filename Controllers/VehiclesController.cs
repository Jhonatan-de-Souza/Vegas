using Microsoft.AspNetCore.Mvc;
using Vegas.Models;

namespace Vegas.Controllers
{
    [Route("/api/vehicles")]
    public class VehiclesController : Controller
    {

        //this is new in .Net Core
        [HttpPost]
        public IActionResult CreateVehicle([FromBody]Vehicle vehicle)
        {
            return Ok(vehicle );
        }
    }
}


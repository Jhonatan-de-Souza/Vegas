using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Vegas.Controllers.Resources;
using Vegas.Models;
using Vegas.Persistence;

namespace Vegas.Controllers
{
    [Route("/api/vehicles")]
    public class VehiclesController : Controller
    {
        private readonly IMapper mapper;
        private readonly VegaDbContext context;
        public VehiclesController(IMapper mapper, VegaDbContext context)
        {
            this.context = context;
            this.mapper = mapper;

        }
        //this is new in .Net Core
        [HttpPost]
        public async Task<IActionResult> CreateVehicleAsync([FromBody]VehicleResource vehicleResource)
        {
            var vehicle = mapper.Map<VehicleResource, Vehicle>(vehicleResource);
            context.Vehicles.Add(vehicle);

            await context.SaveChangesAsync();
            
            return Ok(vehicle);
        }
    }
}


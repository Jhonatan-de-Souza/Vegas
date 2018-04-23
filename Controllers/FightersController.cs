using System.Collections.ObjectModel;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Vega.Core;
using Vegas.Core.Models;
using Vega.Controllers.Resources;

namespace Vegas.Controllers
{
    [Route("/api/fighters")]
    public class FightersController : Controller
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IFighterRepository repository;
        private readonly IMapper mapper;
        public FightersController(IUnitOfWork unitOfWork, IMapper mapper, IFighterRepository repository)
        {
            this.mapper = mapper;
            this.repository = repository;
            this.unitOfWork = unitOfWork;
        }
        //APIs
        [HttpGet]
        public IActionResult GetFighters()
        {
            var fighters = repository.GetFighterAsync();
            return Ok(fighters);
        }

        [HttpGet("{id}")]
        public IActionResult GetFighter(int id)
        {
            var fighter = repository.GetFighterByIdAsync(id);
            return Ok(fighter);
        }
        [HttpPost]
        public IActionResult CreateFighterAsync(FighterResource fighterResource){
            //implement fighter Creation here             
            return Ok(fighterResource);
        }
    }
}
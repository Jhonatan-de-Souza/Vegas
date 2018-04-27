using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Vega.Controllers.Resources;
using Vega.Core;
using Vega.Core.Models;

namespace Vega.Controllers
{
    //this makes sure that the name of the controller becomes the route for the API
    [Route("/api/[controller]")]
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
        public async Task<IEnumerable<FighterResource>> GetFighters()
        {
            var fighters = await repository.GetFighterAsync();
            return mapper.Map<IEnumerable<Fighter>,IEnumerable<FighterResource>>(fighters);
            
        }

        [HttpGet("{id}")]
        public IActionResult GetFighter(int id)
        {
            var fighter = repository.GetFighterByIdAsync(id);
            return Ok(fighter);
        }
        [HttpGet("skills")] 
        public async Task<IEnumerable<Skills>> GetSkills(){
            var skills = await repository.GetSkillsAsync();
            return skills;
        }
        [HttpPost]
        public async Task<IActionResult> CreateFighterAsync([FromBody]SaveFighterResource fighterResource){
            //implement fighter Creation here
            if(!ModelState.IsValid)
                return BadRequest();

            var fighter = mapper.Map<SaveFighterResource,Fighter>(fighterResource);

            repository.Add(fighter);
            await unitOfWork.CompleteAsync();

            fighter = await repository.GetFighterByIdAsync(fighter.Id);
            
            var result = mapper.Map<Fighter,FighterResource>(fighter);

            return Ok(result);
        }
    }
}
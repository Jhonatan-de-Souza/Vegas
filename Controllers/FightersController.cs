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
        public async Task<IActionResult> GetFighterAsync(int id)
        {
            var fighter = await repository.GetFighterByIdAsync(id);

            if(fighter == null ){
                return NotFound();
            }
                
            //missing mapping from fighter to fighterresource
            var fighterResource = mapper.Map<Fighter,FighterResource>(fighter);


            return Ok(fighterResource);
        }
        [HttpGet("skills")] 
        public async Task<IEnumerable<Skill>> GetSkills(){
            var skills = await repository.GetSkillsAsync();
            return skills;
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateFighterAsync(int id,[FromBody] SaveFighterResource fighterResource){
            if(!ModelState.IsValid)
                return BadRequest(ModelState);

            var fighter = await repository.GetFighterByIdAsync(id);
            if(fighter == null)
                return NotFound();
            mapper.Map<SaveFighterResource,Fighter>(fighterResource,fighter);

            //not implemented yet
            await unitOfWork.CompleteAsync();

            fighter = await repository.GetFighterByIdAsync(id);

            var result = mapper.Map<Fighter,FighterResource>(fighter);
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> CreateFighterAsync([FromBody]SaveFighterResource fighterResource){
            //implement fighter Creation here
            if(!ModelState.IsValid)
                return BadRequest(ModelState);

            var fighter = mapper.Map<SaveFighterResource,Fighter>(fighterResource);

            repository.Add(fighter);
            await unitOfWork.CompleteAsync();

            fighter = await repository.GetFighterByIdAsync(fighter.Id);
            
            var result = mapper.Map<Fighter,FighterResource>(fighter);

            return Ok(result);
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteVehicle(int id)
        {
            var fighter = await repository.GetFighterByIdAsync(id);
            if(fighter == null)
            {
                return NotFound();
            }
            repository.Remove(fighter);
            await unitOfWork.CompleteAsync();

            return Ok(id);
        }

    }
}
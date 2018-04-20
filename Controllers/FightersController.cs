using System.Collections.ObjectModel;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Vega.Core;
using Vegas.Core.Models;

namespace Vegas.Controllers
{
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
        [HttpGet("/api/fighters")]
        public IActionResult GetFighters()
        {
            var fighters = repository.GetFighterAsync();
            return Ok(fighters);
        }
    }
}
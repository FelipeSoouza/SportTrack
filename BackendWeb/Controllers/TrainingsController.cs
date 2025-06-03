using Microsoft.AspNetCore.Mvc;
using WebSport.Models;
using WebSport.Services;
using System.Collections.Generic;

namespace WebSport.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TrainingsController : ControllerBase
    {
        private readonly MongoService<Training> _service;

        public TrainingsController(MongoService<Training> service)
        {
            _service = service;
        }

        [HttpGet]
        public ActionResult<List<Training>> Get()
        {
            var trainings = _service.Get();
            return Ok(trainings);
        }

        [HttpPost]
        public ActionResult<Training> Post([FromBody] Training training)
        {
            _service.Create(training);
            return CreatedAtAction(nameof(Get), new { id = training.Id }, training);
        }
    }
}

using Microsoft.AspNetCore.Mvc;
using WebSport.Models;
using WebSport.Services;
using System.Collections.Generic;

namespace WebSport.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class FeedbacksController : ControllerBase
    {
        private readonly MongoService<Feedback> _service;

        public FeedbacksController(MongoService<Feedback> service)
        {
            _service = service;
        }

        [HttpGet]
        public ActionResult<List<Feedback>> Get()
        {
            var feedbacks = _service.Get();
            return Ok(feedbacks);
        }

        [HttpPost]
        public ActionResult<Feedback> Post([FromBody] Feedback feedback)
        {
            _service.Create(feedback);
            return CreatedAtAction(nameof(Get), new { id = feedback.Id }, feedback);
        }
    }
}

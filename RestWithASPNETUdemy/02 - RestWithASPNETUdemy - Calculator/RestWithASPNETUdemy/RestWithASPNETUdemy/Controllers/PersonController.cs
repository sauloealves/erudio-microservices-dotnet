using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using RestWithASPNETUdemy.Model;
using RestWithASPNETUdemy.Services;

namespace RestWithASPNETUdemy.Controllers {
    [ApiController]
    [Route("api/[controller]")]
    public class PersonController :ControllerBase {

        private readonly ILogger<PersonController> _logger;
        private IPersonService _person;

        public PersonController(ILogger<PersonController> logger, IPersonService _personService) {
            _logger = logger;
            _person = _personService;
        }

        [HttpGet()]
        public IActionResult Get() {
            return Ok(_person.FindAll());
        }
        [HttpGet("{id}")]
        public IActionResult GetById(long id) {
            var p = _person.GetById(id);
            if(p == null) { return NotFound(); }
            return Ok(p);
        }

        [HttpPost]
        public IActionResult Post([FromBody] Person person) {
            if (person == null) { return BadRequest(); }
            return Ok(_person.Create(person));
        }
        [HttpPut]
        public IActionResult Put([FromBody] Person person) {
            if(person == null) { return BadRequest(); }
            return Ok(_person.Update(person));
        }
        [HttpDelete("{id}")]
        public IActionResult Delete(long id) {
            _person.Delete(id);
            return NoContent();
        }

    }
}

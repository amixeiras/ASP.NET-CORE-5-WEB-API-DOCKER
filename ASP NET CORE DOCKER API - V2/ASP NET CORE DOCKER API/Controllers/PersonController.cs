using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ASP_NET_CORE_DOCKER_API.Model;
using ASP_NET_CORE_DOCKER_API.Services.Implementations;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace ASP_NET_CORE_DOCKER_API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PersonController : Controller
    {
        private readonly ILogger<PersonController> _logger;
        private readonly IPersonInterface _personInterface;
        public PersonController(ILogger<PersonController> logger, IPersonInterface personInterface)
        {
            _logger = logger;
            _personInterface = personInterface;
        }
        [HttpGet]
        public IActionResult Index()
        {
            return Ok(_personInterface.FindAll());
        }

        [HttpGet("{number}")]
        public ActionResult Get(long number)
        {
            var person = _personInterface.FindById(number);
            if (person == null)
                return NotFound(number);
            else
            return Ok(person);
        }

        [HttpPost]
        public IActionResult Post([FromBody] Person person)
        {
            if (person == null)
                return BadRequest();
            else
                return Ok(_personInterface.Create(person));
        }

        [HttpPut]
        public IActionResult Put([FromBody] Person person)
        {
            if (person == null)
                return BadRequest();
            else
                return Ok(_personInterface.Update(person));
        }

        [HttpDelete("{number}")]
        public IActionResult Delete(long number)
        {
            _personInterface.Delete(number);
            return Ok("Arquivo excluido");
        }
    }
}

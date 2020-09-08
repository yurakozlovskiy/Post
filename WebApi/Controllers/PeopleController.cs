using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Post;
using Repositories.AbstractProducts;
using DB;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PeopleController : ControllerBase
    {
        private IPeopleRepository _repository;
        public PeopleController(IPeopleRepository repository)
        {
            _repository = repository ?? throw new ArgumentNullException(nameof(_repository));
        }
        // GET api/values
        [HttpGet]
        public IEnumerable<People> Get()
        {
            return _repository.GetAll().ToList();
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            return Ok(_repository.Get(id));
        }

        // POST api/values
        [HttpPost]
        public IActionResult Post([FromBody] People people)
        {
            _repository.Add(people);
            return Ok();
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public IActionResult Put([FromBody] People people)
        {
            _repository.Update(people);
            return Ok();
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var person = _repository.Get(id);
            _repository.Remove(person);
            return Ok();

        }
    }
}

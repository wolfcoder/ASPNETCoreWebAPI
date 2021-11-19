﻿using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReadwriteController : ControllerBase
    {
        // GET: api/<ReadwriteController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<ReadwriteController>/5
        [HttpGet("{id}")]
        public string Get(string id)
        {
            return id;
        }

        // POST api/<ReadwriteController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<ReadwriteController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<ReadwriteController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}

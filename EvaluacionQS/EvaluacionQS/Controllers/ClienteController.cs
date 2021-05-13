using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EvaluacionQS.Contexts;
using EvaluacionQS.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace EvaluacionQS.Controllers
{
    [Route("api/[controller]")]
    public class ClienteController : Controller
    {
        private readonly AppDbContext context;

        public ClienteController(AppDbContext context)
        {
            this.context = context;
        }

        // GET: api/<controller>
        [HttpGet]
        public IEnumerable<Cliente> Get()
        {
            return context.Cliente.ToList();
        }

        // GET api/<controller>/5
        [HttpGet("{id}")]
        public Cliente Get(int id)
        {
            var cliente = context.Cliente.FirstOrDefault(p => p.ClienteId == id);
            return cliente;
        }

        // POST api/<controller>
        [HttpPost]
        public ActionResult Post([FromBody]Cliente cliente)
        {
            try
            {
                context.Cliente.Add(cliente);
                context.SaveChanges();
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest();
            }
        }

        // PUT api/<controller>/5
        [HttpPut("{id}")]
        public ActionResult Put(int id, [FromBody]Cliente cliente)
        {
            if (cliente.ClienteId == id)
            {
                context.Entry(cliente).State = EntityState.Modified;
                context.SaveChanges();
                return Ok();
            }
            else
            {
                return BadRequest();
            }
        }

        // DELETE api/<controller>/5
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            var cliente = context.Cliente.FirstOrDefault(p => p.ClienteId == id);
            if (cliente != null)
            {
                context.Cliente.Remove(cliente);
                context.SaveChanges();
                return Ok();
            }
            else
            {
                return BadRequest();
            }
        }
    }
}

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
    public class VendedorController : Controller
    {
        private readonly AppDbContext context;

        public VendedorController(AppDbContext context)
        {
            this.context = context;
        }

        // GET: api/<controller>
        [HttpGet]
        public IEnumerable<Vendedor> Get()
        {
            return context.Vendedor.ToList();
        }

        // GET api/<controller>/5
        [HttpGet("{id}")]
        public Vendedor Get(int id)
        {
            var vendedor = context.Vendedor.FirstOrDefault(p => p.VendedorId == id);
            return vendedor;
        }

        // POST api/<controller>
        [HttpPost]
        public ActionResult Post([FromBody]Vendedor vendedor)
        {
            try
            {
                context.Vendedor.Add(vendedor);
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
        public ActionResult Put(int id, [FromBody]Vendedor vendedor)
        {
            if (vendedor.VendedorId == id)
            {
                context.Entry(vendedor).State = EntityState.Modified;
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
            var vendedor = context.Vendedor.FirstOrDefault(p => p.VendedorId == id);
            if (vendedor != null)
            {
                context.Vendedor.Remove(vendedor);
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

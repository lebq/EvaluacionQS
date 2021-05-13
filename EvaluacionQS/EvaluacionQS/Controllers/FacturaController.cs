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
    public class FacturaController : Controller
    {
        private readonly AppDbContext context;

        public FacturaController(AppDbContext context)
        {
            this.context = context;
        }

        // GET: api/<controller>
        [HttpGet]
        public IEnumerable<Factura> Get()
        {
            return context.Factura.ToList();
        }

        // GET api/<controller>/5
        [HttpGet("{id}")]
        public Factura Get(int id)
        {
            var factura = context.Factura.FirstOrDefault(p => p.FacturaId == id);
            return factura;
        }

        // POST api/<controller>
        [HttpPost]
        public ActionResult Post([FromBody]Factura factura)
        {
            try
            {
                context.Factura.Add(factura);
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
        public ActionResult Put(int id, [FromBody]Factura factura)
        {
            if (factura.FacturaId == id)
            {
                context.Entry(factura).State = EntityState.Modified;
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
            var factura = context.Factura.FirstOrDefault(p => p.FacturaId == id);
            if (factura != null)
            {
                context.Factura.Remove(factura);
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

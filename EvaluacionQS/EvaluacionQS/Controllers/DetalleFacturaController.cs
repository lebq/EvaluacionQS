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
    public class DetalleFacturaController : Controller
    {
        private readonly AppDbContext context;

        public DetalleFacturaController(AppDbContext context)
        {
            this.context = context;
        }

        // GET: api/<controller>
        [HttpGet]
        public IEnumerable<DetalleFactura> Get()
        {
            return context.DetalleFactura.ToList();
        }

        // GET api/<controller>/5
        [HttpGet("{id}")]
        public DetalleFactura Get(int id)
        {
            var detalleFactura = context.DetalleFactura.FirstOrDefault(p => p.DetalleFacturaId == id);
            return detalleFactura;
        }

        // POST api/<controller>
        [HttpPost]
        public ActionResult Post([FromBody]DetalleFactura detalleFactura)
        {
            try
            {
                context.DetalleFactura.Add(detalleFactura);
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
        public ActionResult Put(int id, [FromBody]DetalleFactura detalleFactura)
        {
            if (detalleFactura.DetalleFacturaId == id)
            {
                context.Entry(detalleFactura).State = EntityState.Modified;
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
            var detalleFactura = context.DetalleFactura.FirstOrDefault(p => p.DetalleFacturaId == id);
            if (detalleFactura != null)
            {
                context.DetalleFactura.Remove(detalleFactura);
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

using pe.com.ciberelectrik.api.Models;
using pe.com.ciberelectrik.api.Models.repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace pe.com.ciberelectrik.api.Controllers
{
    [Route("api-ciberelectrik/producto")]
    public class ProductoController : ApiController
    {
        private readonly ProductoRepository repositorio = new ProductoRepository();

        // GET
        [HttpGet]
        public IHttpActionResult findAll()
        {
            var productos = repositorio.findAll();
            return Ok(productos);
        }

        [HttpGet]
        [Route("api-ciberelectrik/producto/custom")]
        public IHttpActionResult findAllCustom()
        {
            var productos = repositorio.findAllCustom();
            return Ok(productos);
        }

        // GET api/<controller>/5
        public string Get(int id)
        {
            return "value";
        }

        // POST
        [HttpPost]
        public IHttpActionResult add([FromBody] Producto obj)
        {
            bool success = repositorio.add(obj);
            if (success)
            {
                return Ok(new { mensaje = "Se registro el producto", producto = obj });
            }
            else
            {
                return BadRequest("No se pudo registrar");
            }
        }

        // PUT api/<controller>/5
        [HttpPut]
        [Route("api-ciberelectrik/producto/{id:int}")]
        public IHttpActionResult update(int id, [FromBody] Producto obj)
        {
            obj.codigo = id;
            bool success = repositorio.update(obj);
            if (success)
            {
                return Ok(new { mensaje = "Se actualizo el producto", producto = obj });
            }
            else
            {
                return BadRequest("No se pudo actualizar");
            }
        }

        // DELETE
        [HttpDelete]
        [Route("api-ciberelectrik/producto/{id:int}")]
        public IHttpActionResult delete(int id)
        {
            bool success = repositorio.delete(id);
            if (success)
            {
                return Ok(new { mensaje = "Se elimino el producto" });
            }
            else
            {
                return BadRequest("No se pudo eliminar");
            }
        }

        // ENABLE
        [HttpPut]
        [Route("api-ciberelectrik/producto/enable/{id:int}")]
        public IHttpActionResult enable(int id)
        {
            bool success = repositorio.enable(id);
            if (success)
            {
                return Ok(new { mensaje = "Se habilito el producto" });
            }
            else
            {
                return BadRequest("No se pudo habilitar");
            }
        }
    }
}

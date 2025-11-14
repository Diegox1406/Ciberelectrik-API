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
    [Route("api-ciberelectrik/marca")]
    public class MarcaController : ApiController
    {
        private readonly MarcaRepository repositorio = new MarcaRepository();

        [HttpGet]
        public IHttpActionResult findAll()
        {
            var marcas = repositorio.findAll();
            return Ok(marcas);
        }

        [HttpGet]
        [Route("api-ciberelectrik/marca/custom")]
        public IHttpActionResult findAllCustom()
        {
            var marcas = repositorio.findAllCustom();
            return Ok(marcas);
        }

        public string Get(int id)
        {
            return "value";
        }

        [HttpPost]
        public IHttpActionResult add([FromBody] Marca obj)
        {
            bool success = repositorio.add(obj);
            if (success)
            {
                return Ok(new { mensaje = "Se registro la marca", marca = obj });
            }
            else
            {
                return BadRequest("No se pudo registrar");
            }
        }

        [HttpPut]
        [Route("api-ciberelectrik/marca/{id:int}")]
        public IHttpActionResult update(int id, [FromBody] Marca obj)
        {
            obj.codigo = id;
            bool success = repositorio.update(obj);
            if (success)
            {
                return Ok(new { mensaje = "Se actualizo la marca", marca = obj });
            }
            else
            {
                return BadRequest("No se pudo actualizar");
            }
        }

        [HttpDelete]
        [Route("api-ciberelectrik/marca/{id:int}")]
        public IHttpActionResult delete(int id)
        {
            bool success = repositorio.delete(id);
            if (success)
            {
                return Ok(new { mensaje = "Se elimino la marca" });
            }
            else
            {
                return BadRequest("No se pudo eliminar");
            }
        }

        [HttpPut]
        [Route("api-ciberelectrik/marca/enable/{id:int}")]
        public IHttpActionResult enable(int id)
        {
            bool success = repositorio.enable(id);
            if (success)
            {
                return Ok(new { mensaje = "Se habilito la marca" });
            }
            else
            {
                return BadRequest("No se pudo habilitar");
            }
        }
    }
}

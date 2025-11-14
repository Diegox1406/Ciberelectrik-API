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
    // asignamos la ruta general
    [Route("api-ciberelectrik/distrito")]
    public class DistritoController : ApiController
    {
        // creamos la variable del repositorio
        private readonly DistritoRepository repositorio = new DistritoRepository();

        // GET
        [HttpGet]
        public IHttpActionResult findAll()
        {
            var distritos = repositorio.findAll();
            return Ok(distritos);
        }

        [HttpGet]
        [Route("api-ciberelectrik/distrito/custom")]
        public IHttpActionResult findAllCustom()
        {
            var distritos = repositorio.findAllCustom();
            return Ok(distritos);
        }

        // POST
        [HttpPost]
        public IHttpActionResult add([FromBody] Distrito obj)
        {
            bool success = repositorio.add(obj);
            if (success)
            {
                return Ok(new { mensaje = "Se registró el distrito", distrito = obj });
            }
            else
            {
                return BadRequest("No se pudo registrar");
            }
        }

        // PUT
        [HttpPut]
        [Route("api-ciberelectrik/distrito/{id:int}")]
        public IHttpActionResult update(int id, [FromBody] Distrito obj)
        {
            obj.codigo = id;
            bool success = repositorio.update(obj);
            if (success)
            {
                return Ok(new { mensaje = "Se actualizó el distrito", distrito = obj });
            }
            else
            {
                return BadRequest("No se pudo actualizar");
            }
        }

        // DELETE
        [HttpDelete]
        [Route("api-ciberelectrik/distrito/{id:int}")]
        public IHttpActionResult delete(int id)
        {
            bool success = repositorio.delete(id);
            if (success)
            {
                return Ok(new { mensaje = "Se eliminó el distrito" });
            }
            else
            {
                return BadRequest("No se pudo eliminar");
            }
        }

        // ENABLE
        [HttpPut]
        [Route("api-ciberelectrik/distrito/enable/{id:int}")]
        public IHttpActionResult enable(int id)
        {
            bool success = repositorio.enable(id);
            if (success)
            {
                return Ok(new { mensaje = "Se habilitó el distrito" });
            }
            else
            {
                return BadRequest("No se pudo habilitar");
            }
        }
    }
}

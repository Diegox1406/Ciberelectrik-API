using pe.com.ciberelectrik.api.Models;
using pe.com.ciberelectrik.api.Models.repository;
using System.Collections.Generic;
using System.Web.Http;

namespace pe.com.ciberelectrik.api.Controllers
{
    [Route("api-ciberelectrik/tipodocumento")]
    public class TipoDocumentoController : ApiController
    {
        private readonly TipoDocumentoRepository repositorio = new TipoDocumentoRepository();

        // GET: api-ciberelectrik/tipodocumento
        [HttpGet]
        public IHttpActionResult findAll()
        {
            var lista = repositorio.findAll();
            return Ok(lista);
        }

        // GET: api-ciberelectrik/tipodocumento/custom
        [HttpGet]
        [Route("api-ciberelectrik/tipodocumento/custom")]
        public IHttpActionResult findAllCustom()
        {
            var lista = repositorio.findAllCustom();
            return Ok(lista);
        }

        // POST: api-ciberelectrik/tipodocumento
        [HttpPost]
        public IHttpActionResult add([FromBody] TipoDocumento obj)
        {
            bool success = repositorio.add(obj);
            if (success)
                return Ok(new { mensaje = "Se registró el tipo de documento", tipoDocumento = obj });
            else
                return BadRequest("No se pudo registrar");
        }

        // PUT: api-ciberelectrik/tipodocumento/{id}
        [HttpPut]
        [Route("api-ciberelectrik/tipodocumento/{id:int}")]
        public IHttpActionResult update(int id, [FromBody] TipoDocumento obj)
        {
            obj.codigo = id;
            bool success = repositorio.update(obj);
            if (success)
                return Ok(new { mensaje = "Se actualizó el tipo de documento", tipoDocumento = obj });
            else
                return BadRequest("No se pudo actualizar");
        }

        // DELETE: api-ciberelectrik/tipodocumento/{id}
        [HttpDelete]
        [Route("api-ciberelectrik/tipodocumento/{id:int}")]
        public IHttpActionResult delete(int id)
        {
            bool success = repositorio.delete(id);
            if (success)
                return Ok(new { mensaje = "Se eliminó el tipo de documento" });
            else
                return BadRequest("No se pudo eliminar");
        }

        // PUT: api-ciberelectrik/tipodocumento/enable/{id}
        [HttpPut]
        [Route("api-ciberelectrik/tipodocumento/enable/{id:int}")]
        public IHttpActionResult enable(int id)
        {
            bool success = repositorio.enable(id);
            if (success)
                return Ok(new { mensaje = "Se habilitó el tipo de documento" });
            else
                return BadRequest("No se pudo habilitar");
        }
    }
}

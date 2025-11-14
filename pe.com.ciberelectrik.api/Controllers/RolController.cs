using pe.com.ciberelectrik.api.Models;
using pe.com.ciberelectrik.api.Models.repository;
using System.Web.Http;

namespace pe.com.ciberelectrik.api.Controllers
{
    [Route("api-ciberelectrik/rol")]
    public class RolController : ApiController
    {
        private readonly RolRepository repositorio = new RolRepository();

        // GET: api-ciberelectrik/rol
        [HttpGet]
        public IHttpActionResult findAll()
        {
            var roles = repositorio.findAll();
            return Ok(roles);
        }

        // GET: api-ciberelectrik/rol/custom
        [HttpGet]
        [Route("api-ciberelectrik/rol/custom")]
        public IHttpActionResult findAllCustom()
        {
            var roles = repositorio.findAllCustom();
            return Ok(roles);
        }

        // POST: api-ciberelectrik/rol
        [HttpPost]
        public IHttpActionResult add([FromBody] Rol obj)
        {
            bool success = repositorio.add(obj);
            if (success)
            {
                return Ok(new { mensaje = "Se registró el rol", rol = obj });
            }
            else
            {
                return BadRequest("No se pudo registrar");
            }
        }

        // PUT: api-ciberelectrik/rol/{id}
        [HttpPut]
        [Route("api-ciberelectrik/rol/{id:int}")]
        public IHttpActionResult update(int id, [FromBody] Rol obj)
        {
            obj.codigo = id;
            bool success = repositorio.update(obj);
            if (success)
            {
                return Ok(new { mensaje = "Se actualizó el rol", rol = obj });
            }
            else
            {
                return BadRequest("No se pudo actualizar");
            }
        }

        // DELETE: api-ciberelectrik/rol/{id}
        [HttpDelete]
        [Route("api-ciberelectrik/rol/{id:int}")]
        public IHttpActionResult delete(int id)
        {
            bool success = repositorio.delete(id);
            if (success)
            {
                return Ok(new { mensaje = "Se eliminó el rol" });
            }
            else
            {
                return BadRequest("No se pudo eliminar");
            }
        }

        // ENABLE: api-ciberelectrik/rol/enable/{id}
        [HttpPut]
        [Route("api-ciberelectrik/rol/enable/{id:int}")]
        public IHttpActionResult enable(int id)
        {
            bool success = repositorio.enable(id);
            if (success)
            {
                return Ok(new { mensaje = "Se habilitó el rol" });
            }
            else
            {
                return BadRequest("No se pudo habilitar");
            }
        }
    }
}

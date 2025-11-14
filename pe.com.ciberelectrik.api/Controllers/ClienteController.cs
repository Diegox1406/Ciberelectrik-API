using pe.com.ciberelectrik.api.Models;
using pe.com.ciberelectrik.api.Models.repository;
using System.Web.Http;

namespace pe.com.ciberelectrik.api.Controllers
{
    [Route("api-ciberelectrik/cliente")]
    public class ClienteController : ApiController
    {
        private readonly ClienteRepository repositorio = new ClienteRepository();

        // GET: api-ciberelectrik/cliente
        [HttpGet]
        public IHttpActionResult findAll()
        {
            var clientes = repositorio.findAll();
            return Ok(clientes);
        }

        // GET: api-ciberelectrik/cliente/custom
        [HttpGet]
        [Route("api-ciberelectrik/cliente/custom")]
        public IHttpActionResult findAllCustom()
        {
            var clientes = repositorio.findAllCustom();
            return Ok(clientes);
        }

        // POST: api-ciberelectrik/cliente
        [HttpPost]
        public IHttpActionResult add([FromBody] Cliente obj)
        {
            bool success = repositorio.add(obj);
            if (success)
            {
                return Ok(new { mensaje = "Se registró el cliente", cliente = obj });
            }
            else
            {
                return BadRequest("No se pudo registrar el cliente");
            }
        }

        // PUT: api-ciberelectrik/cliente/{id}
        [HttpPut]
        [Route("api-ciberelectrik/cliente/{id:int}")]
        public IHttpActionResult update(int id, [FromBody] Cliente obj)
        {
            obj.codigo = id;
            bool success = repositorio.update(obj);
            if (success)
            {
                return Ok(new { mensaje = "Se actualizó el cliente", cliente = obj });
            }
            else
            {
                return BadRequest("No se pudo actualizar el cliente");
            }
        }

        // DELETE: api-ciberelectrik/cliente/{id}
        [HttpDelete]
        [Route("api-ciberelectrik/cliente/{id:int}")]
        public IHttpActionResult delete(int id)
        {
            bool success = repositorio.delete(id);
            if (success)
            {
                return Ok(new { mensaje = "Se eliminó el cliente" });
            }
            else
            {
                return BadRequest("No se pudo eliminar el cliente");
            }
        }

        // PUT: api-ciberelectrik/cliente/enable/{id}
        [HttpPut]
        [Route("api-ciberelectrik/cliente/enable/{id:int}")]
        public IHttpActionResult enable(int id)
        {
            bool success = repositorio.enable(id);
            if (success)
            {
                return Ok(new { mensaje = "Se habilitó el cliente" });
            }
            else
            {
                return BadRequest("No se pudo habilitar el cliente");
            }
        }
    }
}

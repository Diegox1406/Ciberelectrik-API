using pe.com.ciberelectrik.api.Models;
using pe.com.ciberelectrik.api.Models.repository;
using System.Web.Http;

namespace pe.com.ciberelectrik.api.Controllers
{
    [Route("api-ciberelectrik/empleado")]
    public class EmpleadoController : ApiController
    {
        private readonly EmpleadoRepository repositorio = new EmpleadoRepository();

        [HttpGet]
        public IHttpActionResult findAll()
        {
            var lista = repositorio.findAll();
            return Ok(lista);
        }

        [HttpGet]
        [Route("api-ciberelectrik/empleado/custom")]
        public IHttpActionResult findAllCustom()
        {
            var lista = repositorio.findAllCustom();
            return Ok(lista);
        }

        [HttpPost]
        public IHttpActionResult add([FromBody] Empleado obj)
        {
            bool success = repositorio.add(obj);
            if (success)
                return Ok(new { mensaje = "Se registró el empleado", empleado = obj });
            else
                return BadRequest("No se pudo registrar");
        }

        [HttpPut]
        [Route("api-ciberelectrik/empleado/{id:int}")]
        public IHttpActionResult update(int id, [FromBody] Empleado obj)
        {
            obj.codigo = id;
            bool success = repositorio.update(obj);
            if (success)
                return Ok(new { mensaje = "Se actualizó el empleado", empleado = obj });
            else
                return BadRequest("No se pudo actualizar");
        }

        [HttpDelete]
        [Route("api-ciberelectrik/empleado/{id:int}")]
        public IHttpActionResult delete(int id)
        {
            bool success = repositorio.delete(id);
            if (success)
                return Ok(new { mensaje = "Se eliminó el empleado" });
            else
                return BadRequest("No se pudo eliminar");
        }

        [HttpPut]
        [Route("api-ciberelectrik/empleado/enable/{id:int}")]
        public IHttpActionResult enable(int id)
        {
            bool success = repositorio.enable(id);
            if (success)
                return Ok(new { mensaje = "Se habilitó el empleado" });
            else
                return BadRequest("No se pudo habilitar");
        }
    }
}

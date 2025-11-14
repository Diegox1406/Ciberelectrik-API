using pe.com.ciberelectrik.api.Models;
using pe.com.ciberelectrik.api.Models.repository;
using System.Web.Http;

namespace pe.com.ciberelectrik.api.Controllers
{
    [Route("api-ciberelectrik/ticketpedido")]
    public class TicketPedidoController : ApiController
    {
        private readonly TicketPedidoRepository repositorio = new TicketPedidoRepository();

        // GET: api-ciberelectrik/ticketpedido
        [HttpGet]
        public IHttpActionResult findAll()
        {
            var lista = repositorio.findAll();
            return Ok(lista);
        }

        // GET: api-ciberelectrik/ticketpedido/custom
        [HttpGet]
        [Route("api-ciberelectrik/ticketpedido/custom")]
        public IHttpActionResult findAllCustom()
        {
            var lista = repositorio.findAllCustom();
            return Ok(lista);
        }

        // POST: api-ciberelectrik/ticketpedido
        [HttpPost]
        public IHttpActionResult add([FromBody] TicketPedido obj)
        {
            bool success = repositorio.add(obj);
            if (success)
                return Ok(new { mensaje = "Se registró el ticket", ticket = obj });
            else
                return BadRequest("No se pudo registrar");
        }

        // PUT: api-ciberelectrik/ticketpedido/{id}
        [HttpPut]
        [Route("api-ciberelectrik/ticketpedido/{id:int}")]
        public IHttpActionResult update(int id, [FromBody] TicketPedido obj)
        {
            obj.nroped = id;
            bool success = repositorio.update(obj);
            if (success)
                return Ok(new { mensaje = "Se actualizó el ticket", ticket = obj });
            else
                return BadRequest("No se pudo actualizar");
        }

        // DELETE: api-ciberelectrik/ticketpedido/{id}
        [HttpDelete]
        [Route("api-ciberelectrik/ticketpedido/{id:int}")]
        public IHttpActionResult delete(int id)
        {
            bool success = repositorio.delete(id);
            if (success)
                return Ok(new { mensaje = "Se eliminó (deshabilitó) el ticket" });
            else
                return BadRequest("No se pudo eliminar");
        }

        // PUT: api-ciberelectrik/ticketpedido/enable/{id}
        [HttpPut]
        [Route("api-ciberelectrik/ticketpedido/enable/{id:int}")]
        public IHttpActionResult enable(int id)
        {
            bool success = repositorio.enable(id);
            if (success)
                return Ok(new { mensaje = "Se habilitó el ticket" });
            else
                return BadRequest("No se pudo habilitar");
        }
    }
}

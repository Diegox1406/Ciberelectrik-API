using pe.com.ciberelectrik.api.Models;
using pe.com.ciberelectrik.api.Models.repository;
using System.Web.Http;

namespace pe.com.ciberelectrik.api.Controllers
{
    [Route("api-ciberelectrik/detalleticketpedido")]
    public class DetalleTicketPedidoController : ApiController
    {
        private readonly DetalleTicketPedidoRepository repositorio = new DetalleTicketPedidoRepository();

        // GET: api-ciberelectrik/detalleticketpedido
        [HttpGet]
        public IHttpActionResult findAll()
        {
            var lista = repositorio.findAll();
            return Ok(lista);
        }

        // POST: api-ciberelectrik/detalleticketpedido
        [HttpPost]
        [Route("api-ciberelectrik/detalleticketpedido")]
        public IHttpActionResult add([FromBody] DetalleTicketPedido obj)
        {
            bool success = repositorio.add(obj);
            if (success)
                return Ok(new { mensaje = "Se registró el detalle del pedido", detalle = obj });
            else
                return BadRequest("No se pudo registrar");
        }
    }
}

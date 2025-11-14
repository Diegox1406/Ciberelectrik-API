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
    [Route("api-ciberelectrik/categoria")]

    public class CategoriaController : ApiController
    {
        // creamos la variable del repositorio
        private readonly CategoriaRepository repositorio = new CategoriaRepository();

        // GET 
        [HttpGet]
        public IHttpActionResult findAll()
        {
            var categorias = repositorio.findAll();
            return Ok(categorias);
        }

        [HttpGet]
        [Route("api-ciberelectrik/categoria/custom")]
        public IHttpActionResult findAllCustom()
        {
            var categorias = repositorio.findAllCustom();
            return Ok(categorias);
        }

        // GET api/<controller>
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<controller>
        [HttpPost]
        public IHttpActionResult add([FromBody] Categoria obj)
        {
            bool success = repositorio.add(obj);
            if (success)
            {
                return Ok(new {mensaje="Se registro la categoria", categoria=obj});
            }
            else
            {
                return BadRequest("No se pudo registrar");
            }
        }

        // PUT api/<controller>/5
        [HttpPut]
        [Route("api-ciberelectrik/categoria/{id:int}")]
        public IHttpActionResult update(int id, [FromBody] Categoria obj)
        {
            obj.codigo = id;
            bool success = repositorio.update(obj);
            if (success)
            {
                return Ok(new { mensaje = "Se actualizo la categoria", categoria = obj });
            }
            else
            {
                return BadRequest("No se pudo actualizar");
            }
        }

        // DELETE api/<controller>/5
        [HttpDelete]
        [Route("api-ciberelectrik/categoria/{id:int}")]
        public IHttpActionResult delete(int id)
        {
            bool success = repositorio.delete(id);
            if (success)
            {
                return Ok(new { mensaje = "Se elimino la categoria", });
            }
            else
            {
                return BadRequest("No se pudo eliminar");
            }
        }

        //ENABLE
        [HttpPut]
        [Route("api-ciberelectrik/categoria/enable/{id:int}")]
        public IHttpActionResult enable(int id)
        {
            bool success = repositorio.enable(id);
            if (success)
            {
                return Ok(new { mensaje = "Se habilito la categoria", });
            }
            else
            {
                return BadRequest("No se pudo habilitar");
            }
        }

    }
}
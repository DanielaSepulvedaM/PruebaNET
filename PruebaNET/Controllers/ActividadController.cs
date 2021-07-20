using Entidades;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Reporitorio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PruebaNET.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ActividadController : ControllerBase
    {
        private IRepositorioActividades repositorio;

        public ActividadController(IRepositorioActividades repoServicio)
        {
            repositorio = repoServicio;
        }

        [HttpGet]
        public IActionResult listarActividades()
        {
            var actividades = repositorio.ListarActividad();
            return Ok(actividades);
        }

        [HttpPost]
        public IActionResult CrearActividades(Actividad actividad)
        {
            repositorio.CrearActividad(actividad);
            return Ok();
        }

        [HttpPut]
        public IActionResult EditarActividades(Actividad actividad)
        {
            repositorio.EditarActividad(actividad);
            return Ok();
        }
        
        [HttpDelete("{actividadID:int}")]
        public IActionResult EliminarActividades(int actividadID)
        {
            repositorio.EliminarActividad(actividadID);
            return Ok();
        }
    }
}

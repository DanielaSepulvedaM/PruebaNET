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
    public class EmpleadoController : ControllerBase
    {
        private IRepositorioEmpleado repositorio;

        public EmpleadoController(IRepositorioEmpleado repoServicio)
        {
            repositorio = repoServicio;
        }

        [HttpGet]
        public IActionResult listarEmpleados()
        {
            var empleados = repositorio.ListarEmpleado();
            return Ok(empleados);

        }
    }
}

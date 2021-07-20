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
    public class EstadoController : ControllerBase
    {
        private IRepositorioEstado repositorio;

        public EstadoController(IRepositorioEstado repoServicio)
        {
            repositorio = repoServicio;
        }

        [HttpGet]
        public IActionResult listarEstados()
        {
            var estados = repositorio.ListarEstado();
            return Ok(estados);

        }
    }
}

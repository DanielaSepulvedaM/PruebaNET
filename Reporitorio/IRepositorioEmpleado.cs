using Entidades;
using System;
using System.Collections.Generic;
using System.Text;

namespace Reporitorio
{
    public interface IRepositorioEmpleado
    {
        IEnumerable<Empleado> ListarEmpleado();
    }
}

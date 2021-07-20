using Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Reporitorio
{
    public class RepositorioEmpleado : IRepositorioEmpleado
    {
        private BDActividadesContext context;

        public RepositorioEmpleado(BDActividadesContext ctx)
        {
            context = ctx;
        }
        public IQueryable<Estado> Empleados => context.Estado;
        public IEnumerable<Empleado> ListarEmpleado()
        {
            return context.Empleado.ToList();
        }
    }
}

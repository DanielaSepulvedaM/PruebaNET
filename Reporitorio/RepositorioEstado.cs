using Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Reporitorio
{
    public class RepositorioEstado : IRepositorioEstado
    {
        private BDActividadesContext context;

        public RepositorioEstado(BDActividadesContext ctx)
        {
            context = ctx;
        }
        public IQueryable<Estado> Estados => context.Estado;
        public IEnumerable<Estado> ListarEstado()
        {
            return context.Estado.ToList();
        }
    }
}

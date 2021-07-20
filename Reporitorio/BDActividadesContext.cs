using Entidades;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Reporitorio
{
    public class BDActividadesContext: DbContext
    {
        public BDActividadesContext(DbContextOptions<BDActividadesContext> options) : base(options) { }
        public DbSet<Empleado> Empleado { get; set; }
        public DbSet<Estado> Estado { get; set; }
        public DbSet<Actividad> Actividad { get; set; }
        public DbSet<ActividadEmpleado> ActividadEmpleado { get; set; }

    }
}

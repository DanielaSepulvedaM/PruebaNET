using Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Reporitorio
{
    public class RepositorioActividades : IRepositorioActividades
    {
        private BDActividadesContext context;

        public RepositorioActividades(BDActividadesContext ctx)
        {
            context = ctx;
        }
        public IQueryable<Actividad> Actividades => context.Actividad;

        public void CrearActividad(Actividad actividad)
        {
            actividad.EstadoID = 1;
            context.Actividad.Add(actividad);
            context.SaveChanges();
            var asignacion = new ActividadEmpleado
            {
                ActividadID = actividad.ActividadID,
                EmpleadoID = actividad.EmpleadoAsignado.EmpleadoID
            };

            context.ActividadEmpleado.Add(asignacion);

            context.SaveChanges();
        }

        public void EliminarActividad(int actividadID)
        {
            var actividad = context.Actividad.FirstOrDefault(p => p.ActividadID == actividadID);//filtrar por id
            if (actividad != null)
            {
                actividad.Eliminada = true;
                context.SaveChanges();
            }
        }

        public IEnumerable<Actividad> ListarActividad()
        {
            var actividades = (from act in context.Actividad
                         join est in context.Estado on act.EstadoID equals est.EstadoID
                         where act.Eliminada == false
                         select new Actividad
                         {
                             ActividadID = act.ActividadID,
                             Descripcion = act.Descripcion,
                             Estado = est,
                             EstadoID = est.EstadoID,
                             FechaEstimadas = act.FechaEstimadas
                         }).ToList();

            var actividadesIds = actividades.Select(a => a.ActividadID).ToArray();
            var empleados = (from emp in context.Empleado
                            join empAsig in context.ActividadEmpleado on emp.EmpleadoID equals empAsig.EmpleadoID
                            where actividadesIds.Contains(empAsig.ActividadID)
                            select new { emp, empAsig.ActividadID } ).ToDictionary(k => k.ActividadID, v => v.emp);

            foreach (var act in actividades)
                if(empleados.ContainsKey(act.ActividadID))
                    act.EmpleadoAsignado = empleados[act.ActividadID];
            

            return actividades.ToList();
        }

        public void EditarActividad(Actividad actividad)
        {
            context.Update(actividad);
            context.SaveChanges();
        }
    }
}

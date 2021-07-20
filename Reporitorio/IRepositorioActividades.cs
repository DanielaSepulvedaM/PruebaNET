using Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Reporitorio
{
    public interface IRepositorioActividades
    {
        IQueryable<Actividad> Actividades { get; }
        IEnumerable<Actividad> ListarActividades();
        Actividad ObtenerActividad(int actividadId);
        void CrearActividad(Actividad actividad);
        void EliminarActividad(int actividadID);
        void EditarActividad(Actividad actividad);
    }
}

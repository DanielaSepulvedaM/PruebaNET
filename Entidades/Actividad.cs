using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Entidades
{
    public class Actividad
    {
        public int ActividadID { get; set; }
        public DateTime FechaEstimadas { get; set; }
        public string Descripcion { get; set; }
        public int EstadoID { get; set; }
        public bool Eliminada { get; set; }

        public int DiasRetraso => (DateTime.Today - FechaEstimadas).TotalDays <= 0 ? 0 : EstadoID == 3 ? 0 : (int)(DateTime.Today - FechaEstimadas).TotalDays;
        [NotMapped]
        public virtual Estado Estado { get; set; }
        [NotMapped]
        public virtual Empleado EmpleadoAsignado { get; set; }
    }
}

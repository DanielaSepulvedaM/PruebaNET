import { Empleado } from "./empleado";
import { Estado } from "./estado";

export interface Actividad {
  actividadID: number;
  fechaEstimadas: Date;
  descripcion: string;
  estadoId: number;
  estado: Estado;
  diasRetraso: number;
  empleadoAsignado: Empleado;
}

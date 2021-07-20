import { Empleado } from "./empleado";

export interface Actividad {
  actividadID: number;
  fechaEstimadas: Date;
  descripcion: string;
  estado: {
    estadoID: number;
    nombre: string;
  }
  diasRetraso: number;
  empleadoAsignado: Empleado;
}

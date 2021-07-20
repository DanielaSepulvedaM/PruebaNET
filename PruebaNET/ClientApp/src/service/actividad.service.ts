import { Inject, Injectable } from '@angular/core';
import { HttpClient, HttpParams } from '@angular/common/http';
import { Observable, of, throwError } from 'rxjs';
import { map } from 'rxjs/operators'
import { Actividad } from '../interfaces/actividad';


@Injectable({
  providedIn: 'root'
})
export class ActividadService {
  public actividades: Actividad[];

  constructor(private http: HttpClient, @Inject('BASE_URL') private baseUrl: string) {
    
  }

  obtenerActividades(): Observable<Actividad[]> {
    return this.http.get<Actividad[]>(this.baseUrl + 'api/Actividad')
  }
  
  crearActividad(nuevaActividad: Actividad): Observable<Actividad> {
    return this.http.post<Actividad>(this.baseUrl + 'api/Actividad', nuevaActividad);
  }

  eliminarActividad(actividadId: number): Observable<object> {
    return this.http.delete(this.baseUrl + 'api/Actividad/' + actividadId)
  }

  cargarActividad(id: number): Observable<Actividad> {
    return this.http.get<Actividad>(this.baseUrl + 'api/actividad/' + id)
  }
}

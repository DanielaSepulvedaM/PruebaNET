import { HttpClient } from '@angular/common/http';
import { Inject, Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Empleado } from '../interfaces/empleado';

@Injectable({
  providedIn: 'root'
})
export class EmpleadoService {

  constructor(private http: HttpClient, @Inject('BASE_URL') private baseUrl: string) {
    
  }

  cargarEmpleados(): Observable<Empleado[]> {
    return this.http.get<Empleado[]>(this.baseUrl + 'api/Empleado')
  }
}

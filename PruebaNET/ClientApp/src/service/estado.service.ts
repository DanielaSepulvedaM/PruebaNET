import { HttpClient } from '@angular/common/http';
import { Inject, Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Estado } from '../interfaces/estado';

@Injectable({
  providedIn: 'root'
})
export class EstadoService {

  constructor(private http: HttpClient, @Inject('BASE_URL') private baseUrl: string) { }

  obtenerEstados(): Observable<Estado[]> {
    return this.http.get<Estado[]>(this.baseUrl + 'api/Estado');
  }
}

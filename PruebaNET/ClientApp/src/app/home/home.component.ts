import { AfterViewInit, Component } from '@angular/core';
import { Actividad } from '../../interfaces/actividad';
import { ActividadService } from '../../service/actividad.service';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
})
export class HomeComponent implements AfterViewInit {

  public actividades: Actividad[];

  constructor(private actService: ActividadService) {
    this.actividades = actService.actividades;
  }

  ngAfterViewInit(): void { this.cargarActividades();}
    

  eliminarActividad(id: number): void {
    this.actService.eliminarActividad(id).subscribe(c => { this.cargarActividades()});
  }

  private cargarActividades(): void {
    this.actService.obtenerActividades().subscribe(actividades => this.actividades = actividades);
  }
}

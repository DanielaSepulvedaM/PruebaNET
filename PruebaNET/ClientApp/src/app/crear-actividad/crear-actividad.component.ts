import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { Actividad } from '../../interfaces/actividad';
import { Empleado } from '../../interfaces/empleado';
import { ActividadService } from '../../service/actividad.service';
import { EmpleadoService } from '../../service/empleado.service';

@Component({
  selector: 'app-crear-actividad',
  templateUrl: './crear-actividad.component.html',
  styleUrls: ['./crear-actividad.component.css']
})
export class CrearActividadComponent implements OnInit {

  empleados: Empleado[];
  
  model = {} as Actividad;

  constructor(private actService: ActividadService, private empService: EmpleadoService, private router: Router) { }
 
  ngOnInit() {
    this.empService.cargarEmpleados().subscribe(empl => this.empleados = empl);
  }

  crearActividad(): void {
    this.actService.crearActividad(this.model).subscribe(e => {
      this.router.navigateByUrl('/');
    })
  }
}

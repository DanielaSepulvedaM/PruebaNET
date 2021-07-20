import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { Actividad } from '../../interfaces/actividad';
import { Empleado } from '../../interfaces/empleado';
import { Estado } from '../../interfaces/estado';
import { ActividadService } from '../../service/actividad.service';
import { EmpleadoService } from '../../service/empleado.service';
import { EstadoService } from '../../service/estado.service';

@Component({
  selector: 'app-editar-actividad',
  templateUrl: './editar-actividad.component.html',
  styleUrls: ['./editar-actividad.component.css']
})
export class EditarActividadComponent implements OnInit {
  empleados: Empleado[];
  estados: Estado[];
  model: Actividad;

  constructor(private actService: ActividadService,
    private empService: EmpleadoService,
    private estServoce: EstadoService,
    private router: Router,
    private route: ActivatedRoute) { }

  ngOnInit() {
    this.empService.cargarEmpleados().subscribe(empl => this.empleados = empl);
    this.estServoce.obtenerEstados().subscribe(estados => this.estados = estados);
    var id = this.route.snapshot.paramMap.get("id");
    this.actService.cargarActividad(Number(id)).subscribe(act => this.model = act);
  }

  modificarActividad(): void {
    this.actService.crearActividad(this.model).subscribe(e => {
      this.router.navigateByUrl('/');
    })
  }

}

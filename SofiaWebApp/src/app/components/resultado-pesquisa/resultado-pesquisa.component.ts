import { Component, OnInit, Input, EventEmitter } from '@angular/core';
import { BuscarColaboradoresService } from '../../services/buscar-colaboradores.service';
import { BuscarColaboradorPorTecnologiasResult } from '../../services/buscar-colaboradores.service';

@Component({
  selector: 'app-resultado-pesquisa',
  templateUrl: './resultado-pesquisa.component.html'
})
export class ResultadoPesquisaComponent implements OnInit {

  @Input() listaColaboradores: BuscarColaboradorPorTecnologiasResult[]

  constructor() { }

  ngOnInit() {    
  }

}

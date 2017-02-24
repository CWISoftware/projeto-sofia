import { Component, OnInit, Input, EventEmitter } from '@angular/core';
import { BuscarColaboradoresService, BuscarColaboradorPorTecnologiasResult } from '../../services/buscar-colaboradores.service';

@Component({
  selector: 'app-resultado-pesquisa',
  templateUrl: './resultado-pesquisa.component.html'
})
export class ResultadoPesquisaComponent implements OnInit {

  @Input() listaColaboradores: BuscarColaboradorPorTecnologiasResult[]

  constructor() { }

  ngOnInit() {
  }

  arr(stars: number): Array<number> {
    return new Array<number>(stars);
  }
}

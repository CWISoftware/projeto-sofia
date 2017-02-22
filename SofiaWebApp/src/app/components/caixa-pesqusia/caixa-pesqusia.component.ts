import { Component, OnInit, Input, Output, EventEmitter } from '@angular/core';
import 'rxjs/Rx';
import { BuscarColaboradoresService } from '../../services/buscar-colaboradores.service';
import { BuscarColaboradorPorTecnologiasResult } from '../../services/buscar-colaboradores.service';

@Component({
  selector: 'app-caixa-pesqusia',
  templateUrl: './caixa-pesqusia.component.html',
  providers: [BuscarColaboradoresService]
})
export class CaixaPesqusiaComponent implements OnInit {
  
  @Input() 
  listaColaboradores: BuscarColaboradorPorTecnologiasResult[];
  
  @Output() 
  listaColaboradoresChanged: EventEmitter<BuscarColaboradorPorTecnologiasResult[]> = new EventEmitter();

  txtPesquisa: string;

  constructor(private buscarColaboradoresService: BuscarColaboradoresService) { }

  ngOnInit() {
  }

  pesquisar() {

    this.buscarColaboradoresService
      .buscar(this.txtPesquisa)
      .subscribe((result) => {        
        this.listaColaboradores = result;
        this.listaColaboradoresChanged.next(this.listaColaboradores);
      });
  }
}

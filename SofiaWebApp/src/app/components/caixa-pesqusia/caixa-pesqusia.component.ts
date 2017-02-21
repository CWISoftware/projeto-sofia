import { Component, OnInit, Input, Output, EventEmitter } from '@angular/core';
import { BuscarColaboradoresService } from '../../services/buscar-colaboradores.service';
import { ColaboradorViewModel } from '../../services/buscar-colaboradores.service';
import 'rxjs/Rx';

@Component({
  selector: 'app-caixa-pesqusia',
  templateUrl: './caixa-pesqusia.component.html',
  providers: [BuscarColaboradoresService]
})
export class CaixaPesqusiaComponent implements OnInit {
  
  @Input() 
  listaColaboradores: ColaboradorViewModel[];
  
  @Output() 
  listaColaboradoresChanged: EventEmitter<ColaboradorViewModel[]> = new EventEmitter();

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
        console.log(this.listaColaboradores);
      });
  }
}

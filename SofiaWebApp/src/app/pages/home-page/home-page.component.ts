import { Component, OnInit, ViewEncapsulation } from '@angular/core';
import { CaixaPesqusiaComponent } from './../../components/caixa-pesqusia/caixa-pesqusia.component';
import { ResultadoPesquisaComponent } from './../../components/resultado-pesquisa/resultado-pesquisa.component';
import { ColaboradorViewModel } from '../../services/buscar-colaboradores.service';

@Component({
  selector: 'app-home-page',
  templateUrl: './home-page.component.html',
  encapsulation: ViewEncapsulation.None
})
export class HomePageComponent implements OnInit {

  resultadoPesquisa:ColaboradorViewModel[];

	public handleEvent(resultadoPesquisa){
    this.resultadoPesquisa = resultadoPesquisa;
  }
  constructor() { }

  ngOnInit() {
  }

}

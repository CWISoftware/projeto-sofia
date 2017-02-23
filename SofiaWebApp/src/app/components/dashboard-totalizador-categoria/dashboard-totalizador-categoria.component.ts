import { Component, OnInit } from '@angular/core';
import { CategoriaService, ObterTotalizadorCategoriasResult } from '../../services/categoria.service';

@Component({
  selector: 'app-dashboard-totalizador-categoria',
  templateUrl: './dashboard-totalizador-categoria.component.html',
  providers: [CategoriaService]
})
export class DashboardTotalizadorCategoriaComponent implements OnInit {

  data: ObterTotalizadorCategoriasResult[];

  constructor(private categoriaService: CategoriaService) { }

  ngOnInit() {
    this.categoriaService.obterTotalizadorCategorias()
      .subscribe((result) => { this.data = result });
  }

}

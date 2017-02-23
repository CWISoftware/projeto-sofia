import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-visualizar-perfil-usuario-page',
  templateUrl: './visualizar-perfil-usuario-page.component.html'
})
export class VisualizarPerfilUsuarioPageComponent implements OnInit {

  isShowModalAdicionarTecnologia: boolean;

  constructor() { }

  ngOnInit() {
  }

  abrirModalAdicionarTecnologia() {
    this.isShowModalAdicionarTecnologia = true;
  }

  modalAdicionarTecnologiaFechada() {
    this.isShowModalAdicionarTecnologia = false;
  }
}

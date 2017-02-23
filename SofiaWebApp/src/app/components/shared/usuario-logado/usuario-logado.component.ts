import { Component, OnInit } from '@angular/core';
import { Global } from '../../../global';

@Component({
  selector: 'app-usuario-logado',
  templateUrl: './usuario-logado.component.html'
})
export class UsuarioLogadoComponent implements OnInit {

  nome: string = Global.Usuario.nome;
  constructor() { }

  ngOnInit() {
  }

}

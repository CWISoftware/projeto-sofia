import { Component } from '@angular/core';

@Component({
    selector: 'usuario-logado',
    templateUrl: './app/components/home/usuario-logado.template.html'
})
export class UsuarioLogadoComponent {

    data: colaboradorResult;

    constructor() {
        this.data = {
            colaborador: {
                id: 1,
                nomecompleto: 'Usuario Logado',
                foto: 'https://cdn1.iconfinder.com/data/icons/circle-outlines/512/User_Account_Avatar_Person_Profile_Login_Human-512.png'
            }
        };
    }
}

interface colaboradorResult {
    colaborador: colaborador;
}

interface colaborador {
    id: number;
    nomecompleto: string;
    foto: string;
}
import { Injectable } from '@angular/core';
import { Http } from '@angular/http';
import { Observable } from 'rxjs/Rx';
import { Global } from '../global';

@Injectable()
export class BuscarColaboradoresService {

    constructor(private _http: Http) { }

    buscar(tecnologia: string): Observable<BuscarColaboradorPorTecnologiasResult[]> {
        return this._http
            .get(Global.API.busca + "?texto=" + encodeURIComponent(tecnologia))
            .map(res => res.json().data);
    }
}

export interface BuscarColaboradorPorTecnologiasResult {
    id: number;
    nome: string;
    tecnologias: BuscarColaboradorPorTecnologiasTecnologiaResult[];
}

export interface BuscarColaboradorPorTecnologiasTecnologiaResult {
    nome: string;
    icone: string;
    nivel: number;
    nivelPorExtenso: string;
}
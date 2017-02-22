import { Injectable } from '@angular/core';
import { Http } from '@angular/http';
import { Observable } from 'rxjs/Rx';

@Injectable()
export class BuscarColaboradoresService {

  _buscaUrl = 'http://localhost:5000/v1/busca?texto=';

  constructor(private _http: Http) { }

  buscar(tecnologia: string): Observable<BuscarColaboradorPorTecnologiasResult[]> {
    return this._http
      .get(this._buscaUrl + encodeURIComponent(tecnologia))
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
import { Injectable } from '@angular/core';
import { Http } from '@angular/http';
import { Observable } from 'rxjs/Rx';

@Injectable()
export class BuscarColaboradoresService {

  _buscaUrl = 'http://localhost:5000/v1/busca?texto=';

  constructor(private _http: Http) { }

  buscar(tecnologia: string): Observable<ColaboradorViewModel[]> {
    return this._http
      .get(this._buscaUrl + encodeURIComponent(tecnologia))
      .map(res => res.json().data);
  }
}

export interface ColaboradorViewModel {
    id: number;
    nome: string;
    tecnologias: TecnologiaViewModel[];
}

export interface TecnologiaViewModel {
    nome: string;
    icone: string;
    nivel: number;
    nivelPorExtenso: string;
}
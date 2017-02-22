import { Injectable } from '@angular/core';
import { Http } from '@angular/http';
import { Observable } from 'rxjs/Rx';

@Injectable()
export class TecnologiaService {

  _buscaUrl = 'http://localhost:5000/v1/tecnologias';

  constructor(private _http: Http) { }

  buscar(tecnologia: AvaliarNovaTecnologia) {
    return this._http
      .post(this._buscaUrl, tecnologia);
  }
}

export interface AvaliarNovaTecnologia {
  tecnologia:number,
  idCategoria:number,
  idColaborador:number;
  nivel:string;
  iconeUrl:string;
}

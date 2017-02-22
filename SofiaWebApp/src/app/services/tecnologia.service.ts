import { Injectable } from '@angular/core';
import { Http } from '@angular/http';
import { Observable } from 'rxjs/Rx';

@Injectable()
export class TecnologiaService {

  _buscaUrl = 'http://localhost:5000/v1/tecnologias';

  constructor(private _http: Http) { }

  //TODOC
  avaliarNovaTecnologia(command: AvaliarNovaTecnologiaCommand) {
    return this._http
      .post(this._buscaUrl, command)
      .map((response) => {
        console.log(response);
      });
  }
}

export interface AvaliarNovaTecnologiaCommand {
  tecnologia: string;
  idCategoria: number;
  idColaborador: number;
  nivel: string;
  iconeUrl: string;
}

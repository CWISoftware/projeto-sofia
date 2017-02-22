import { Injectable } from '@angular/core';
import { Http, Response } from '@angular/http';
import { Observable } from 'rxjs/Rx';
import { Headers, RequestOptions } from '@angular/http';

@Injectable()
export class TecnologiaService {

  _buscaUrl = 'http://localhost:5000/v1/tecnologias';

  constructor(private _http: Http) { }

  avaliarNovaTecnologia(command: AvaliarNovaTecnologiaCommand) {
    let headers = new Headers({ 'Content-Type': 'application/json' });
    let options = new RequestOptions({ headers: headers });

    return this._http
      .post(this._buscaUrl, JSON.stringify(command), options)
      .toPromise()
      .then(this.extractData)
      .catch(this.handleError);
  }

  private extractData(res: Response) {
    let body = res.json();
    return body.data || {};
  }
  private handleError(error: Response | any) {
    // In a real world app, we might use a remote logging infrastructure
    let errMsg: string;
    if (error instanceof Response) {
      const body = error.json() || '';
      const err = body.error || JSON.stringify(body);
      errMsg = `${error.status} - ${error.statusText || ''} ${err}`;
    } else {
      errMsg = error.message ? error.message : error.toString();
    }
    console.error(errMsg);
    return Promise.reject(errMsg);
  }

}

export interface AvaliarNovaTecnologiaCommand {
  tecnologia: string;
  idCategoria: number;
  idColaborador: number;
  nivel: string;
  iconeUrl: string;
}

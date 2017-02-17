import { Injectable } from '@angular/core';
import { Http } from '@angular/http';
import { ColaboradorViewModel } from '../models/busca';
import { Observable } from 'rxjs/Rx';
import 'rxjs/add/operator/map';

@Injectable()
export class PesquisaService {
    constructor(private http: Http) { }

    buscaUrl = 'http://localhost:60000/busca';

    buscar(tecnologia: string): Observable<ColaboradorViewModel[]> {
        return this.http.get(this.buscaUrl)
            .map(res => res.json().data);
    }
}
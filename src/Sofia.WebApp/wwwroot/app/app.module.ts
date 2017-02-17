import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { FormsModule } from '@angular/forms';
import { HttpModule } from '@angular/http';

import { AppComponent } from './app.component';
import { HomeComponent } from './components/home/home.component';
import { UsuarioLogadoComponent } from './components/home/usuario-logado.component';
import { BarraPesquisaComponent } from './components/home/barra-pesquisa.component';

@NgModule({
    imports: [BrowserModule, FormsModule, HttpModule],
    declarations: [AppComponent, HomeComponent, UsuarioLogadoComponent, BarraPesquisaComponent],
    bootstrap: [AppComponent]
})
export class AppModule { }

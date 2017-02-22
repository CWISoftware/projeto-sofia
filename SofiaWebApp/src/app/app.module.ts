import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { HttpModule } from '@angular/http';
import { RouterModule, Routes } from '@angular/router';

//root
import { AppComponent } from './app.component';

//shared
import { TopBarComponent } from './components/shared/top-bar/top-bar.component';
import { UsuarioLogadoComponent } from './components/shared/usuario-logado/usuario-logado.component';
import { FooterComponent } from './components/shared/footer/footer.component';
import { DashboardCategoriasComponent } from './components/dashboard-categorias/dashboard-categorias.component';
import { ResultadoPesquisaComponent } from './components/resultado-pesquisa/resultado-pesquisa.component';
import { CaixaPesqusiaComponent } from './components/caixa-pesqusia/caixa-pesqusia.component';
import { ModalAvaliarTecnologiaComponent } from './components/modal-avaliar-tecnologia/modal-avaliar-tecnologia.component';

//pages
import { HomePageComponent } from './pages/home-page/home-page.component';
import { VisualizarPerfilUsuarioPageComponent } from './pages/visualizar-perfil-usuario-page/visualizar-perfil-usuario-page.component';
import { PageNotFoundComponent } from './pages/page-not-found/page-not-found.component';



const appRoutes: Routes = [
  { path: 'perfil', component: VisualizarPerfilUsuarioPageComponent },
  { path: 'perfil:id', component: VisualizarPerfilUsuarioPageComponent },
  { path: '', component: HomePageComponent },
  {
    path: '',
    redirectTo: '/',
    pathMatch: 'full'
  },
  { path: '**', component: PageNotFoundComponent }
];

@NgModule({
  declarations: [
    AppComponent,
    HomePageComponent,
    TopBarComponent,
    FooterComponent,
    CaixaPesqusiaComponent,
    DashboardCategoriasComponent,
    ResultadoPesquisaComponent,
    UsuarioLogadoComponent,
    VisualizarPerfilUsuarioPageComponent,
    PageNotFoundComponent,
    ModalAvaliarTecnologiaComponent
  ],
  imports: [
    RouterModule.forRoot(appRoutes),
    BrowserModule,
    FormsModule,
    HttpModule
  ],
  providers: [],
  bootstrap: [AppComponent]
}) export class AppModule { }
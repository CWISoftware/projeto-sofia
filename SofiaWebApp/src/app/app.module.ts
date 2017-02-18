import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { HttpModule } from '@angular/http';

//root
import { AppComponent } from './app.component';

//shared
import { TopBarComponent } from './components/shared/top-bar/top-bar.component';
import { FooterComponent } from './components/shared/footer/footer.component';
import { CaixaPesqusiaComponent } from './components/shared/caixa-pesqusia/caixa-pesqusia.component';
import { ListaColaboradoresComponent } from './components/lista-colaboradores/lista-colaboradores.component';
import { DashboardCategoriasComponent } from './components/shared/dashboard-categorias/dashboard-categorias.component';

//pages
import { HomePageComponent } from './pages/home-page/home-page.component';

@NgModule({
  declarations: [
    AppComponent,
    HomePageComponent,
    TopBarComponent,
    FooterComponent,
    CaixaPesqusiaComponent,
    ListaColaboradoresComponent,
    DashboardCategoriasComponent
  ],
  imports: [
    BrowserModule,
    FormsModule,
    HttpModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }

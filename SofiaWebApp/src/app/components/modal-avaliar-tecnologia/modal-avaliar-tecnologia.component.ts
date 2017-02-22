import { Component, OnInit } from '@angular/core';
import 'rxjs/Rx';
import { TecnologiaService } from '../../services/tecnologia.service';
import { AvaliarNovaTecnologiaCommand } from '../../services/tecnologia.service';

@Component({
  selector: 'app-modal-avaliar-tecnologia',
  templateUrl: './modal-avaliar-tecnologia.component.html',
  providers: [TecnologiaService]
})
export class ModalAvaliarTecnologiaComponent implements OnInit {

  tecnologia: string;
  idCategoria: number;
  idColaborador: number;
  nivel: string;
  iconeUrl: string;

  constructor(private tecnologiaService: TecnologiaService) { }

  ngOnInit() {
  }

  adicionarTecnologia() {
    let command= this.criarCommand();
    /*command.tecnologia = this.tecnologia;
    command.idCategoria = this.idCategoria;
    command.idColaborador = this.idColaborador;
    command.nivel = this.nivel;
    command.iconeUrl = this.iconeUrl;
    command.tecnologia = "WCF";
    command.idCategoria = 2;
    command.idColaborador = 3;
    command.nivel = "Mito";
    command.iconeUrl = "https://tonysneed.files.wordpress.com/2016/01/wcf-logo.png";*/

    this.tecnologiaService
      .avaliarNovaTecnologia(command);
  };

  criarCommand(): AvaliarNovaTecnologiaCommand {
    return {
      "tecnologia": "WCF",
      "idCategoria": 2,
      "idColaborador": 3,
      "nivel": "Mito",
      "iconeUrl": "https://tonysneed.files.wordpress.com/2016/01/wcf-logo.png"
    };
  }
}

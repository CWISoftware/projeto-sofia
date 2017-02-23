import { Component, OnInit, Input, Output, EventEmitter } from '@angular/core';
import 'rxjs/Rx';
import { TecnologiaService } from '../../services/tecnologia.service';
import { AvaliarNovaTecnologiaCommand } from '../../services/tecnologia.service';

@Component({
  selector: 'app-modal-avaliar-tecnologia',
  templateUrl: './modal-avaliar-tecnologia.component.html',
  providers: [TecnologiaService]
})
export class ModalAvaliarTecnologiaComponent implements OnInit {

  @Input()
  showModal: boolean;

  @Output()
  onCloseModalEvent = new EventEmitter();

  data: AvaliarNovaTecnologiaCommand;
  niveis: [{ id: string, nome: string }];
  categorias: [{ id: number, nome: string }];  

  constructor(private tecnologiaService: TecnologiaService) {
    this.data = { tecnologia: "", iconeUrl: "", idCategoria: 0, idColaborador: 0, nivel: "NaoConheco" };
    this.niveis = [
      { id: "NaoConheco", nome: "NaoConheco" },
      { id: "Testei", nome: "Testei" },
      { id: "Conheco", nome: "Conheco" },
      { id: "Domino", nome: "Domino" },
      { id: "Mito", nome: "Mito" }];

    this.categorias = [
      { id: 1, nome: "Ferramentas" },
      { id: 2, nome: "Frameworks" },
      { id: 3, nome: "Banco de Dados" },
      { id: 4, nome: "Linguagens" }];

    this.showModal = false;
  }

  ngOnInit() {
  }

  adicionarTecnologia() {
    this.data.idColaborador = 1;
    this.tecnologiaService
      .avaliarNovaTecnologia(this.data);
  };

  abrirModal() {
    this.showModal = true;
  };

  fecharModal() {
    this.showModal = false;
    this.onCloseModalEvent.emit();
  };
}
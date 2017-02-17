import { Component } from '@angular/core';
import { PesquisaService } from '../../services/pesquisa.service';
import { ColaboradorViewModel } from '../../models/busca';

@Component({
    selector: 'barra-pesquisa',
    templateUrl: './app/components/home/barra-pesquisa.template.html',
    providers: [PesquisaService]
})
export class BarraPesquisaComponent {

    data: ColaboradorViewModel[];
    mostrarResultado: boolean;
    txtPesquisa: string;

    constructor(private buscaService: PesquisaService) {
        this.mostrarResultado = false;
        this.txtPesquisa = "";
    }

    pesquisar() {

        this.buscaService.buscar(this.txtPesquisa).subscribe(result => {                        
            this.data = result;
        });

        this.mostrarResultado = !(this.data == null);
    }
}
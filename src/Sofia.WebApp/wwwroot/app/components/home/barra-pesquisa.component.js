"use strict";
var __decorate = (this && this.__decorate) || function (decorators, target, key, desc) {
    var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
    if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
    else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
    return c > 3 && r && Object.defineProperty(target, key, r), r;
};
var __metadata = (this && this.__metadata) || function (k, v) {
    if (typeof Reflect === "object" && typeof Reflect.metadata === "function") return Reflect.metadata(k, v);
};
var core_1 = require('@angular/core');
var pesquisa_service_1 = require('../../services/pesquisa.service');
var BarraPesquisaComponent = (function () {
    function BarraPesquisaComponent(buscaService) {
        this.buscaService = buscaService;
        this.mostrarResultado = false;
        this.txtPesquisa = "";
    }
    BarraPesquisaComponent.prototype.pesquisar = function () {
        var _this = this;
        this.buscaService.buscar(this.txtPesquisa).subscribe(function (result) {
            _this.data = result;
        });
        this.mostrarResultado = !(this.data == null);
    };
    BarraPesquisaComponent = __decorate([
        core_1.Component({
            selector: 'barra-pesquisa',
            templateUrl: './app/components/home/barra-pesquisa.template.html',
            providers: [pesquisa_service_1.PesquisaService]
        }), 
        __metadata('design:paramtypes', [pesquisa_service_1.PesquisaService])
    ], BarraPesquisaComponent);
    return BarraPesquisaComponent;
}());
exports.BarraPesquisaComponent = BarraPesquisaComponent;
//# sourceMappingURL=barra-pesquisa.component.js.map
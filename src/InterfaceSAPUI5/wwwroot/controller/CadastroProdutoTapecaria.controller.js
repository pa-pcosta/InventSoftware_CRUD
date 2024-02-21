sap.ui.define([
	"sap/ui/core/mvc/Controller",
	"sap/ui/model/json/JSONModel",
	"sap/ui/core/routing/History",
	"../model/formatter"
], (Controller, JSONModel, History, formatter) => {
	"use strict";

	return Controller.extend("ui5.Controle_De_Estoque.controller.CadastroProdutoTapecaria", {
		formatter: formatter,

		onInit() {
			
			let roteador = this.getOwnerComponent().getRouter();
			roteador.getRoute("cadastro").attachPatternMatched(this.aoCoincidirRota, this);
		},

		aoCoincidirRota() {
        
            var url = 'api/Tapecaria/';

            this.setarModeloTapecaria(url);
		},

        async setarModeloTapecaria (url) {
			this.getView().setModel(new JSONModel({}), "produtoTapecaria");
		},

        aoClicarEmVoltar (){
            
            const historico = History.getInstance();
			const paginaAnterior = historico.getPreviousHash();

			if (paginaAnterior !== undefined) {
				window.history.go(-1);
			} else {
				const roteador = this.getOwnerComponent().getRouter();
				roteador.navTo("telaListagem");
			}
        },

        aoClicarEmSalvar (evento){
            
			var form = evento.getSource();
        }
	});
});
sap.ui.define([
	"sap/ui/core/mvc/Controller",
	"sap/ui/model/json/JSONModel",
	"sap/ui/core/routing/History",
	"../model/formatter"
], (Controller, JSONModel, History,formatter) => {
	"use strict";

	return Controller.extend("ui5.Controle_De_Estoque.controller.DetalhesProdutoTapecaria", {
		formatter: formatter,
		
        onInit() {
		    var roteador = this.getOwnerComponent().getRouter();
		    roteador.getRoute("detalhes").attachMatched(this.aoCoincidirRota, this);
		},

		aoCoincidirRota(evento) {
            
            var id = evento.getParameter("arguments").id
            var url = 'api/Tapecaria/' + id;

            this.setarModeloTapecaria(url);
		},

        async setarModeloTapecaria (url) {
			
			const resposta = await fetch(url);
			const modelo = await resposta.json();
			this.getView().setModel(new JSONModel(modelo), "produtoTapecaria");
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
        }
	});
});
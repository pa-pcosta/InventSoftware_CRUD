sap.ui.define([
	"sap/ui/core/mvc/Controller",
	"sap/ui/model/json/JSONModel",
	"sap/ui/core/routing/History"
], (Controller, JSONModel, History) => {
	"use strict";

	return Controller.extend("ui5.Controle_De_Estoque.controller.Base", {
		
        vincularRota(nomeRota){
			this.getOwnerComponent().getRouter().getRoute(nomeRota).attachPatternMatched(this.aoCoincidirRota, this);
        },

        definirModelo(nomeModelo, dados= null){
			if (dados == null)
			{
				this.getView().setModel(new JSONModel({}), nomeModelo);
			}
			else
			{
            	this.getView().setModel(new JSONModel(dados), nomeModelo);
			}
        },

		retornarParaPaginaAnterior(){
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
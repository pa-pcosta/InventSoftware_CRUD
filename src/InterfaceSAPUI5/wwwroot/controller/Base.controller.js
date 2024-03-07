sap.ui.define([
	"sap/ui/core/mvc/Controller",
	"sap/ui/model/json/JSONModel",
	"sap/ui/core/routing/History",
	"sap/m/MessageBox"
], (Controller, JSONModel, History, MessageBox) => {
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
				const roteador = this.getOwnerComponent().getRouter();
				roteador.navTo("telaListagem");
		},

		mostrarMessageBoxSucesso (mensagem){
			MessageBox.success(mensagem);
		},

		mostrarMessageBoxFalha (mensagem){
			MessageBox.error(mensagem);
		}
	});
});
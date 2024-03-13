sap.ui.define([
	"sap/ui/core/mvc/Controller",
	"sap/ui/model/json/JSONModel",
	"sap/ui/core/routing/History",
	"sap/m/MessageBox"
], (Controller, JSONModel, History, MessageBox) => {
	"use strict";

	return Controller.extend("ui5.Controle_De_Estoque.controller.Base", {
		
        vincularRota(nomeRota, aoCoincidirRota){
			this.getOwnerComponent().getRouter().getRoute(nomeRota).attachPatternMatched(aoCoincidirRota, this);
        },

        definirModelo(nomeModelo, dados = null){
			if (dados == null)
			{
				this.getView().setModel(new JSONModel({}), nomeModelo);
			}
			else
			{
            	this.getView().setModel(new JSONModel(dados), nomeModelo);
			}
        },

		navegarPara (rota, parametro = null){
			const roteador = this.getOwnerComponent().getRouter();

			roteador.navTo(rota, parametro);
		},

		obterMensagemI18n (mensagem) {
			const pacoteDeTexto = this.getOwnerComponent().getModel("i18n").getResourceBundle();
			
			return pacoteDeTexto.getText(mensagem);
		}
	});
});
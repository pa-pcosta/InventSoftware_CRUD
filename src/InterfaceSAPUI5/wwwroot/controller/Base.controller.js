sap.ui.define([
	"sap/ui/core/mvc/Controller",
	"sap/ui/model/json/JSONModel"
], (Controller, JSONModel) => {
	"use strict";

	return Controller.extend("ui5.Controle_De_Estoque.controller.Base", {
		
        vincularRota(nomeRota){
			this.getOwnerComponent().getRouter().getRoute(nomeRota).attachPatternMatched(this.aoCoincidirRota, this);
        },

        definirModelo(dados, nomeModelo){
            this.getView().setModel(new JSONModel(dados), nomeModelo);
        }
	});
});
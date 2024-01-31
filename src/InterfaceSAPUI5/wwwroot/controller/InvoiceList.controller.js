sap.ui.define([
	"sap/ui/core/mvc/Controller",
	"sap/ui/model/json/JSONModel",
	"../model/formatter",
	"sap/ui/model/Filter",
	"sap/ui/model/FilterOperator"
], (Controller, JSONModel, formatter, Filter, FilterOperator) => {
	"use strict";

	return Controller.extend("ui5.walkthrough.controller.InvoiceList", {
		formatter: formatter,

		onInit() {
			//console.log(this.setarModeloTapecaria().oData);
			this.setarModeloTapecaria();
		},

		async AoClicarEmFiltrar(oEvent) {
			const sQuery = oEvent.getParameter("query");
			const url = 'api/Tapecaria' + '?tipo=' + sQuery;

			let resposta = await fetch(url);

			if (resposta.ok){
				let modeloTapecaria= await resposta.json();
				this.getView().setModel(new JSONModel(modeloTapecaria), "produtoTapecaria");
			}
		},

		onPress(oEvent) {
			const oItem = oEvent.getSource();
			const oRouter = this.getOwnerComponent().getRouter();
			oRouter.navTo("detail", {
				invoicePath: window.encodeURIComponent(oItem.getBindingContext("invoice").getPath().substr(1))
			});
		},

		async setarModeloTapecaria() {

			const url = 'api/Tapecaria';
			
			return fetch(url)
				.then(data => {
					return data.json();
				})
				.then(modelo => { this.getView().setModel(new JSONModel(modelo), "produtoTapecaria"); });
		}
	});
});

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
			this.setarModeloMoeda();
		},

		onFilterInvoices(oEvent) {
			// build filter array
			const aFilter = [];
			const sQuery = oEvent.getParameter("query");
			if (sQuery) {
				aFilter.push(new Filter("id", FilterOperator.Contains, sQuery));
			}

			// filter binding
			const oList = this.byId("invoiceList");
			const oBinding = oList.getBinding("items");
			oBinding.filter(aFilter);
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
			let resposta = await fetch(url);
			if (resposta.ok){
				let modeloTapecaria= await resposta.json()
				modeloTapecaria = this.getView().setModel(new JSONModel(modeloTapecaria), "produtoTapecaria")
				
			}	 
			// fetch(url)
			// 	.then(data => {
			// 		data.json();
			// 	})
			// 	.then(modelo => { this.getView().setModel(new JSONModel(modelo), "produtoTapecaria"); });

			
		},

		setarModeloMoeda(){
			let moeda = {
				sigla: "BRL",
				simbolo: "R$"
			}

			let modelo = new JSONModel(moeda);
			this.getView().setModel(modelo, "moeda");
		}
	});
});

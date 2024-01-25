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
				aFilter.push(new Filter("ProductName", FilterOperator.Contains, sQuery));
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

		setarModeloTapecaria(){
			let produtoTapecaria = [
				{
					"Id": 1,
					"Tipo": 2,
					"DataEntrada": "2024-01-19T12:12:00",
					"Area": 2,
					"PrecoMetroQuadrado": 35.0000000,
					"EhEntrega": true,
					"Detalhes": "Campo Detalhes"
				},
				{
					"Id": 52,
					"Tipo": 3,
					"DataEntrada": "2023-12-22T00:00:00",
					"Area": 4,
					"PrecoMetroQuadrado": 100.00000,
					"EhEntrega": true,
					"Detalhes": "TESTE PUT API [retornar Id] #5 REPO SQLSERVER)"
				},
				{
					"Id": 6,
					"Tipo": 0,
					"DataEntrada": "2023-12-22T00:00:00",
					"Area": 8,
					"PrecoMetroQuadrado": 20.00000,
					"EhEntrega": true,
					"Detalhes": "TESTE POST API [retornar Id] AAA"
				},
				{
					"Id": 25,
					"Tipo": 1,
					"DataEntrada": "2023-12-22T00:00:00",
					"Area": 8,
					"PrecoMetroQuadrado": 10.00000,
					"EhEntrega": true,
					"Detalhes": "TESTE POST API [retornar Id] AAA"
				}
			];

			let modelo = new JSONModel(produtoTapecaria);
			this.getView().setModel(modelo,"produtoTapecaria");

			//return modelo;
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

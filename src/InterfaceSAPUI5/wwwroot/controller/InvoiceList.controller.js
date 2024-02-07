sap.ui.define([
	"sap/ui/core/mvc/Controller",
	"sap/ui/model/json/JSONModel",
	"../model/formatter",
	"sap/ui/model/Filter",
	"sap/ui/model/FilterOperator"
], (Controller, JSONModel, formatter, Filter, FilterOperator) => {
	"use strict";

	return Controller.extend("ui5.Controle_De_Estoque.controller.InvoiceList", {
		formatter: formatter,

		_valorSelecionadoComboBox :"",

		onInit() {
			//console.log(this.setarModeloTapecaria().oData);
			this.setarModeloTapecaria();
		},

		async AoClicarEmFiltrar(oEvent) {
			const sQuery = oEvent.getParameter("query");
			const url = 'api/Tapecaria' + '?tipo=' + this._valorSelecionadoComboBox + '&detalhes=' + sQuery;

			let resposta = await fetch(url);

			if (resposta.ok){
				let modeloTapecaria= await resposta.json();
				this.getView().setModel(new JSONModel(modeloTapecaria), "produtoTapecaria");
			}
		},

		aoMudarValorComboBox (evento) {

			let comboBox = evento.getSource();
			this._valorSelecionadoComboBox = comboBox.getProperty("selectedKey");
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

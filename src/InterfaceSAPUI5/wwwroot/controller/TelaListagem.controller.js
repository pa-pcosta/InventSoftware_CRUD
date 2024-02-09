sap.ui.define([
	"sap/ui/core/mvc/Controller",
	"sap/ui/model/json/JSONModel",
	"../model/formatter",
	"sap/ui/model/Filter",
	"sap/ui/model/FilterOperator"
], (Controller, JSONModel, formatter, Filter, FilterOperator) => {
	"use strict";

	return Controller.extend("ui5.Controle_De_Estoque.controller.TelaListagem", {
		formatter: formatter,

		onInit() {
			
			let roteador = this.getOwnerComponent().getRouter();
			roteador.getRoute("telaListagem").attachPatternMatched(this.aoCoincidirRotaListagem, this);
		},

		aoCoincidirRotaListagem (){

			this.setarModeloTapecaria('api/Tapecaria');
			this.setarModeloFiltro();
		},

		async AoClicarEmFiltrar() {

			const modeloFiltro = this.getView().getModel("filtro").getData();
			const valorSelecionadoComboBox = modeloFiltro.tipo;
			const valorSearchField = modeloFiltro.detalhes;

			var url = 'api/Tapecaria';

			if (valorSelecionadoComboBox || valorSearchField){
				url += '?';

				if (valorSelecionadoComboBox){
					url += "tipo="+valorSelecionadoComboBox;
				}

				if (valorSelecionadoComboBox && valorSearchField){
					url += '&';
				}

				if (valorSearchField){
					url +='detalhes='+valorSearchField;
				}
			}

			this.setarModeloTapecaria(url);
		},

		async setarModeloTapecaria (url) {
			
			return fetch(url)
				.then(data => {
					return data.json();
				})
				.then(modelo => { this.getView().setModel(new JSONModel(modelo), "produtoTapecaria"); });
		},

		setarModeloFiltro (){

			this.getView().setModel(new JSONModel({}), "filtro");
		}
	});
});
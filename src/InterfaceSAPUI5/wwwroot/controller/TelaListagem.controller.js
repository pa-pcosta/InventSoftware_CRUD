sap.ui.define([
	"./Base.controller",
	"sap/ui/model/json/JSONModel",
	"../model/formatter"
], (BaseController, JSONModel, formatter) => {
	"use strict";

	return BaseController.extend("ui5.Controle_De_Estoque.controller.TelaListagem", {
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

		aoClicarEmProduto (evento){

			var produtoTapecaria = evento.getSource();
			var contexto = produtoTapecaria.getBindingContext("produtoTapecaria");
			const roteador = this.getOwnerComponent().getRouter();

			roteador.navTo("detalhes",{
				id: contexto.getProperty("id")
			});
		},

		aoClicarEmAdicionar (){

			const roteador = this.getOwnerComponent().getRouter();

			roteador.navTo("cadastro");
		},

		async setarModeloTapecaria (url) {
			
			var resposta = await fetch(url);
			var listaProdutosTapecaria = await resposta.json();
			
			this.definirModelo(listaProdutosTapecaria, "produtoTapecaria");
		},

		setarModeloFiltro (){

			this.getView().setModel(new JSONModel({}), "filtro");
		}
	});
});

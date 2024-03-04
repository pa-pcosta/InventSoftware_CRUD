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

		async aoCoincidirRotaListagem (){
			var resposta = await fetch("api/Tapecaria");
			var listaProdutosTapecaria = await resposta.json();
			
			this.definirModelo("produtoTapecaria", listaProdutosTapecaria);
			this.definirModelo("filtro");
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

			var resposta = await fetch(url);
			var listaProdutosTapecaria = await resposta.json();
			
			this.definirModelo("produtoTapecaria", listaProdutosTapecaria);
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
		}
	});
});

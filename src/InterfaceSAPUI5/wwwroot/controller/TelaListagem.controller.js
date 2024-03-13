sap.ui.define([
	"./Base.controller",
	"../model/formatter"
], (BaseController, formatter) => {
	"use strict";

	return BaseController.extend("ui5.Controle_De_Estoque.controller.TelaListagem", {
		formatter: formatter,

		onInit() {
			
			this.vincularRota("telaListagem", this.aoCoincidirRotaListagem);
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
			let id = contexto.getProperty("id"); 
			const parametro = {id};

			this.navegarPara("detalhes", parametro);
		},

		aoClicarEmAdicionar (){
			
			this.navegarPara("cadastro");
		}
	});
});

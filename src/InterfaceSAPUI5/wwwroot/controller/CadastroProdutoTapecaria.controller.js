sap.ui.define([
	"./Base.controller",
	"../model/formatter",
	"../services/validacaoCadastro"
], (BaseController, formatter, Validador) => {
	"use strict";

	return BaseController.extend("ui5.Controle_De_Estoque.controller.CadastroProdutoTapecaria", {
		
		formatter: formatter,
		validador: Validador,

		onInit() {
			this.vincularRota("cadastro");
		},

		async aoCoincidirRota() {
            this.definirModelo("produtoTapecaria");

			var resposta = await fetch("api/Tapecaria/enumTipoTapecaria");
			var tiposTapecaria = await resposta.json();
			this.definirModelo("enumTipoTapecaria", tiposTapecaria);
		},

        aoClicarEmVoltar (){
            this.retornarParaPaginaAnterior();
        },

        aoClicarEmSalvar (){
            
			var novoProdutoTapecaria = this.getView().getModel("produtoTapecaria").getData();
			
			novoProdutoTapecaria.tipo = parseInt(novoProdutoTapecaria.tipo);
			
			fetch('api/Tapecaria', {
				method: 'POST',
				body: JSON.stringify(novoProdutoTapecaria),
				headers: {
					"Content-type": "application/json; charset=UTF-8"
				}
			})
			.then(resposta => resposta.json())
			.then(
				produtoCadastrado =>
					this.getOwnerComponent().getRouter().navTo("detalhes",{
						id: produtoCadastrado.id
					})
			);
        }
	});
});
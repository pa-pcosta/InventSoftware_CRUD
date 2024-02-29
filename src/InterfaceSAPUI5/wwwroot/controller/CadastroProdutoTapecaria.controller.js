sap.ui.define([
	"sap/ui/core/mvc/Controller",
	"sap/ui/model/json/JSONModel",
	"sap/ui/core/routing/History",
	"../model/formatter",
	"sap/m/MessageBox",
	"./Base.controller"
], (Controller, JSONModel, History, formatter, MessageBox, BaseController) => {
	"use strict";

	return BaseController.extend("ui5.Controle_De_Estoque.controller.CadastroProdutoTapecaria", {
		
		formatter: formatter,

		onInit() {
			vincularRota("cadastro");
		},

		aoCoincidirRota() {
            this.setarModeloTapecaria();
		},

        setarModeloTapecaria () {
			this.getView().setModel(new JSONModel({}), "produtoTapecaria");
		},

        aoClicarEmVoltar (){
            
            const historico = History.getInstance();
			const paginaAnterior = historico.getPreviousHash();

			if (paginaAnterior !== undefined) {
				window.history.go(-1);
			} else {
				const roteador = this.getOwnerComponent().getRouter();
				roteador.navTo("telaListagem");
			}
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
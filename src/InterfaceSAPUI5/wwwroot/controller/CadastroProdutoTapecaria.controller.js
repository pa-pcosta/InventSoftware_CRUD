sap.ui.define([
	"sap/ui/core/mvc/Controller",
	"sap/ui/model/json/JSONModel",
	"sap/ui/core/routing/History",
	"../model/formatter",
	"sap/m/MessageBox"
], (Controller, JSONModel, History, formatter, MessageBox) => {
	"use strict";

	return Controller.extend("ui5.Controle_De_Estoque.controller.CadastroProdutoTapecaria", {
		formatter: formatter,

		onInit() {
			let roteador = this.getOwnerComponent().getRouter();
			roteador.getRoute("cadastro").attachPatternMatched(this.aoCoincidirRota, this);
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
			var fetchPostBody = JSON.stringify(novoProdutoTapecaria);

			fetch('api/Tapecaria', {
				method: 'POST',
				body: fetchPostBody
			})
			.then(resposta => resposta.json())
			.then(json => console.log(json));
        }
	});
});
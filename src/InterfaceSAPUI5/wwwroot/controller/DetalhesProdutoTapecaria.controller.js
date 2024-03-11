sap.ui.define([
	"./Base.controller",
	"../model/formatter"
], (BaseController, formatter) => {
	"use strict";

	return BaseController.extend("ui5.Controle_De_Estoque.controller.DetalhesProdutoTapecaria", {
		formatter: formatter,
		
        onInit() {
		    this.vincularRota("detalhes");
		},

		async aoCoincidirRota(evento) {
            
            var id = evento.getParameter("arguments").id
            var url = 'api/Tapecaria/' + id;
			const resposta = await fetch(url);
			const modelo = await resposta.json();

            this.definirModelo("produtoTapecaria", modelo);
		},

        aoClicarEmVoltar (){
            this.retornarParaPaginaAnterior();
        },

		aoClicarEmEditar (){
			let produtoTapecaria = this.getView().getModel("produtoTapecaria").getData();
			let id = produtoTapecaria.id;

			const roteador = this.getOwnerComponent().getRouter();
			roteador.navTo("edicao", {id: id});
		}
	});
});
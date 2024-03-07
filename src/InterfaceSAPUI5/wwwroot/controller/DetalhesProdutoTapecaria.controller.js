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
        }
	});
});
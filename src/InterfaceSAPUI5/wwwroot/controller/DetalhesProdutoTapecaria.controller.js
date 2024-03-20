sap.ui.define([
	"./Base.controller",
	"../model/formatter",
	"sap/m/MessageBox",
	"../Repositorio/RepositorioCRUD"
], (BaseController, formatter, MessageBox, Repositorio) => {
	"use strict";

	return BaseController.extend("ui5.Controle_De_Estoque.controller.DetalhesProdutoTapecaria", {
		formatter: formatter,
		
        onInit() {
		    this.vincularRota("detalhes",this.aoCoincidirRotaDetalhes);
		},

		aoCoincidirRotaDetalhes(evento) 
		{
			this.exibirEspera(async() => {
				var id = evento.getParameter("arguments").id
				let produtoTapecaria = await Repositorio.obterPorId(id);
	
				this.definirModelo("produtoTapecaria", produtoTapecaria);
			});
		},

        aoClicarEmVoltar ()
		{
			this.exibirEspera(() => {
				this.navegarPara("telaListagem");
			});
        },

		aoClicarEmEditar ()
		{
			this.exibirEspera(() => {
				let id = this.obterModelo("produtoTapecaria").id;
				let parametro = {id};
	
				this.navegarPara("edicao", parametro)
			});
		},

		aoClicarEmRemover()
		{
			this.exibirEspera(async() => {
				let id = this.obterModelo("produtoTapecaria").id;
				let mensagemConfirmarRemocao = this.obterMensagemI18n("confirmarRemocao");
	
				this.exibirMensagemDeConfirmacao(mensagemConfirmarRemocao, (clique)=> {
					if(clique == MessageBox.Action.OK)
					{
						Repositorio.remover(id)
						.then( 
							this.exibirMensagemDeSucesso(this.obterMensagemI18n("mensagemSucessoRemocao"), (clique) => {
								if(clique == MessageBox.Action.OK)
								{
									this.navegarPara("telaListagem")
								}
							})
						);
					}
				})
			});
		}
	});
});
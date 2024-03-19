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
				var url = 'api/Tapecaria/' + id;
				let produtoTapecaria = await Repositorio.obterDadosDoServidor(url);
	
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
				let id = this.obtermodelo("produtoTapecaria").id;
				let parametro = {id};
	
				this.navegarPara("edicao", parametro)
			});
		},

		aoClicarEmRemover()
		{
			this.exibirEspera(async() => {
				let id = this.obterModelo("produtoTapecaria").id;
				let url = 'api/Tapecaria/' + id;
				let produtoARemover = await Repositorio.obterDadosDoServidor(url);
				let mensagemConfirmarRemocao = this.obterMensagemI18n("confirmarRemocao");
	
				this.exibirMensagemDeConfirmacao(mensagemConfirmarRemocao, (clique)=> {
					if(clique == MessageBox.Action.OK)
					{
						Repositorio.enviarDadosParaServidor(url, 'DELETE', produtoARemover)
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
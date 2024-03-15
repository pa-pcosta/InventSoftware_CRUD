sap.ui.define([
	"./Base.controller",
	"../model/formatter",
	"../Repositorio/RepositorioCRUD"
], (BaseController, formatter, Repositorio) => {
	"use strict";

	return BaseController.extend("ui5.Controle_De_Estoque.controller.TelaListagem", {
		formatter: formatter,

		onInit() {
			this.vincularRota("telaListagem", this.aoCoincidirRotaListagem);
		},

		async aoCoincidirRotaListagem ()
		{
			this.exibirEspera(async () => {
				let url = "api/Tapecaria";
				let listaProdutosTapecaria = await Repositorio.obterDadosDoServidor(url);
				
				this.definirModelo("produtoTapecaria", listaProdutosTapecaria);
				this.definirModelo("filtro");
			})
		},

		async aoClicarEmFiltrar()
		{
			this.exibirEspera(async() => {
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

			let listaProdutosTapecaria = await Repositorio.obterDadosDoServidor(url);
			
			this.definirModelo("produtoTapecaria", listaProdutosTapecaria);
		});
			
		},

		aoClicarEmProduto (evento)
		{
			this.exibirEspera(() => {
				var produtoTapecaria = evento.getSource();
				var contexto = produtoTapecaria.getBindingContext("produtoTapecaria");
				let id = contexto.getProperty("id"); 
				const parametro = {id};

				this.navegarPara("detalhes", parametro);
			});
		},

		aoClicarEmAdicionar ()
		{
			this.exibirEspera(() => {
				this.navegarPara("cadastro");
			});
		}
	});
});

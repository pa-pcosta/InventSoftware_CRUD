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
				let listaProdutosTapecaria = await Repositorio.obterTodos();
				this.definirModelo("produtoTapecaria", listaProdutosTapecaria);

				let tiposTapecaria = await Repositorio.obterEnumTipoTapecaria();
				this.definirModelo("enumTipoTapecaria", tiposTapecaria);

				this.definirModelo("filtro");
			})
		},

		async aoClicarEmFiltrar()
		{
			this.exibirEspera(async() => {
				const modeloFiltro = this.obterModelo("filtro");
				const valorSelecionadoComboBox = modeloFiltro.tipo;
				const valorSearchField = modeloFiltro.detalhes;

				let filtro = '';

				if (valorSelecionadoComboBox || valorSearchField){
					filtro += '?';

					if (valorSelecionadoComboBox){
						filtro += "tipo="+valorSelecionadoComboBox;
					}

					if (valorSelecionadoComboBox && valorSearchField){
						filtro += '&';
					}

					if (valorSearchField){
						filtro +='detalhes='+valorSearchField;
					}
				}

				let listaProdutosTapecaria = await Repositorio.obterTodos(filtro);
				
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
		},

		cadastroTeste()
		{
			this.exibirMensagemDeSucesso("Botão cadastrar acionado");
		}
	});
});

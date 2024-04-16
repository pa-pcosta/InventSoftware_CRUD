sap.ui.define([
	"./Base.controller",
	"../model/formatter",
	"../services/validacaoCadastro",
	"sap/m/MessageBox",
	"../Repositorio/RepositorioCRUD"
], (BaseController, formatter, Validador, MessageBox, Repositorio) => {
	"use strict";

	return BaseController.extend("ui5.controle_de_estoque.controller.CadastroProdutoTapecaria", {
		
		formatter: formatter,
		validador: Validador,

		onInit() {
			Validador.inicializaValidador(this.getView().getController());
			this.vincularRota("cadastro", this.aoCoincidirRotaCadastro);
			this.vincularRota("edicao", this.aoCoincidirRotaEdicao);
		},

		aoCoincidirRotaCadastro() 
		{
			this.exibirEspera(async() => {
				this.definirModelo("produtoTapecaria");

				let tiposTapecaria = await Repositorio.obterEnumTipoTapecaria();
				this.definirModelo("enumTipoTapecaria", tiposTapecaria);
				
				let view = this.getView();
				Validador.redefinirEstadoDosInputs(view);
			});
		},

		async aoCoincidirRotaEdicao (evento) 
		{
			this.exibirEspera(async() => {
				var id = evento.getParameter("arguments").id
				
				let produtoTapecaria = await Repositorio.obterPorId(id)
				this.definirModelo("produtoTapecaria", produtoTapecaria);
				
				let tiposTapecaria = await Repositorio.obterEnumTipoTapecaria();
				this.definirModelo("enumTipoTapecaria", tiposTapecaria);
			});
		},

        aoClicarEmVoltar ()
		{
			this.exibirEspera(() => {
				const id = this.obterModelo("produtoTapecaria").id;
				
				if (id != null)
				{
					let parametro = {id};
					this.navegarPara("detalhes", parametro);
				}
				else
				{
					this.navegarPara("telaListagem");
				}
			});
        },

        aoClicarEmSalvar ()
		{
			this.exibirEspera(async() => {

				let comboBox = this.getView().byId("cadastroComboBoxTipo");
				let datePicker = this.getView().byId("cadastroDatePickerDataEntrada");
				let inputArea = this.getView().byId("cadastroInputArea");
				let inputPreco = this.getView().byId("cadastroInputPrecoMetroQuadrado");
				let inputDetalhes = this.getView().byId("cadastroTextAreaDetalhes");

				Validador.validarTodos(comboBox, datePicker, inputArea, inputPreco, inputDetalhes);

				let novoProdutoTapecaria = this.obterModelo("produtoTapecaria");
				novoProdutoTapecaria.tipo = parseInt(novoProdutoTapecaria.tipo);
				
				let produtoCadastrado = novoProdutoTapecaria.id == null ? await Repositorio.criar(novoProdutoTapecaria) : await Repositorio.atualizar(novoProdutoTapecaria); 

				this.aoEfetuarCadastroComSucesso(produtoCadastrado);
			});
        },

		aoMudarValorTipo (evento)
		{
			this.exibirEspera(() => {
				let comboBox = evento.getSource();
				Validador.validarTipo(comboBox);
			});
		},

		aoMudarValorDataEntrada (evento)
		{
			this.exibirEspera(() => {
				let datePicker = evento.getSource();
				Validador.validarDataEntrada(datePicker);
			});
		},

		aoMudarValorTamanho (evento)
		{
			this.exibirEspera(() => {
				let campoInput = evento.getSource();
				Validador.validarTamanho(campoInput);
			});
		},

		aoMudarValorPrecoMetroQuadrado (evento)
		{
			this.exibirEspera(() => {
				let campoInput = evento.getSource();
				Validador.validarPrecoMetroQuadrado(campoInput);
			});
		},

		aoMudarValorDetalhes (evento)
		{
			this.exibirEspera(() => {
				let campoInput = evento.getSource();
				Validador.validarDetalhes(campoInput);
			});
		},

		aoEfetuarCadastroComSucesso(produtoCadastrado)
		{
			this.exibirEspera(() => {
				this.exibirMensagemDeSucesso(this.obterMensagemI18n("mensagemSucessoDeCadastro"),(clique) => {
						if(clique == MessageBox.Action.OK)
						{
							const id = produtoCadastrado.id;
							const parametro = {id}
							this.navegarPara("detalhes", parametro);
						}
					}
				)
			});
		}
	});
});
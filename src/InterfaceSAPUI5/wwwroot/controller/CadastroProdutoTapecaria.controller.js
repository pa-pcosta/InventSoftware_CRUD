sap.ui.define([
	"./Base.controller",
	"../model/formatter",
	"../services/validacaoCadastro",
	"sap/m/MessageBox",
	"../Repositorio/RepositorioCRUD"
], (BaseController, formatter, Validador, MessageBox, Repositorio) => {
	"use strict";

	return BaseController.extend("ui5.Controle_De_Estoque.controller.CadastroProdutoTapecaria", {
		
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

				let tiposTapecaria = await Repositorio.obterDadosDoServidor("api/Tapecaria/enumTipoTapecaria");
				this.definirModelo("enumTipoTapecaria", tiposTapecaria);
				
				let view = this.getView();
				Validador.redefinirEstadoDosInputs(view);
			});
		},

		async aoCoincidirRotaEdicao (evento) 
		{
			this.exibirEspera(async() => {
				var id = evento.getParameter("arguments").id
				var url = 'api/Tapecaria/' + id;
				
				let produtoTapecaria = await Repositorio.obterDadosDoServidor(url)
				this.definirModelo("produtoTapecaria", produtoTapecaria);
				
				let tiposTapecaria = await Repositorio.obterDadosDoServidor("api/Tapecaria/enumTipoTapecaria");
				this.definirModelo("enumTipoTapecaria", tiposTapecaria);
			});
		},

        aoClicarEmVoltar ()
		{
			this.exibirEspera(() => {
				const id = this.getView().getModel("produtoTapecaria").getData().id
				
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
				let inputDetalhes = this.getView().byId("cadastroInputDetalhes");

				Validador.validarTodos(comboBox, datePicker, inputArea, inputPreco, inputDetalhes);

				let url = 'api/Tapecaria';
				let novoProdutoTapecaria = this.getView().getModel("produtoTapecaria").getData();
				novoProdutoTapecaria.tipo = parseInt(novoProdutoTapecaria.tipo);
				let metodoHttp = novoProdutoTapecaria.id == null ? 'POST' : 'PUT'; 

				let produtoCadastrado = await Repositorio.enviarDadosParaServidor(url, metodoHttp, novoProdutoTapecaria);

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
				MessageBox.success(this.obterMensagemI18n("mensagemSucessoDeCadastro"), {
					actions: [MessageBox.Action.OK],
					onClose: (clique) => {
						if(clique == MessageBox.Action.OK)
						{
							const id = produtoCadastrado.id;
							const parametro = {id}
							this.navegarPara("detalhes", parametro);
						}
					}
				})
			});
		}
	});
});
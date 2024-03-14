sap.ui.define([
	"./Base.controller",
	"../model/formatter",
	"../services/validacaoCadastro",
	"sap/m/MessageBox"
], (BaseController, formatter, Validador, MessageBox) => {
	"use strict";

	return BaseController.extend("ui5.Controle_De_Estoque.controller.CadastroProdutoTapecaria", {
		
		formatter: formatter,
		validador: Validador,

		onInit() {
			Validador.inicializaValidador(this.getView().getController());
			this.vincularRota("cadastro", this.aoCoincidirRotaCadastro);
			this.vincularRota("edicao", this.aoCoincidirRotaEdicao);
		},

		async aoCoincidirRotaCadastro() {
            this.definirModelo("produtoTapecaria");

			var resposta = await fetch("api/Tapecaria/enumTipoTapecaria");
			var tiposTapecaria = await resposta.json();
			this.definirModelo("enumTipoTapecaria", tiposTapecaria);

			
            let view = this.getView();
			Validador.redefinirEstadoDosInputs(view);
		},

		aoCoincidirRotaEdicao (evento) {
			var id = evento.getParameter("arguments").id
            var url = 'api/Tapecaria/' + id;
			
			fetch(url)
			.then(resposta => resposta.json())
			.then(modelo => this.definirModelo("produtoTapecaria", modelo));
			
			fetch("api/Tapecaria/enumTipoTapecaria")
			.then(resposta => resposta.json())
			.then(modelo => this.definirModelo("enumTipoTapecaria", modelo));
		},

        aoClicarEmVoltar (){
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
        },

        async aoClicarEmSalvar (){
            Validador.validarTodos(this.getView());
			
			let novoProdutoTapecaria = this.getView().getModel("produtoTapecaria").getData();
			novoProdutoTapecaria.tipo = parseInt(novoProdutoTapecaria.tipo);
			let metodoFetch = novoProdutoTapecaria.id == null ? 'POST' : 'PUT'; 

			fetch('api/Tapecaria', {
				method: metodoFetch,
				body: JSON.stringify(novoProdutoTapecaria),
				headers: {
					"Content-type": "application/json; charset=UTF-8"
				}
			})
			.then(resposta => resposta.json())
			.then(produtoCadastrado => this.aoEfetuarCadastroComSucesso(produtoCadastrado));
        },

		aoMudarValorTipo (evento){
			let comboBox = evento.getSource();
			let mensagemErroValidacao = Validador.validarTipo(comboBox);

			if (mensagemErroValidacao)
			{
				comboBox.setValueState("Error");
                comboBox.setValueStateText(mensagemErroValidacao);
			}
		},

		aoMudarValorDataEntrada (evento){
			let datePicker = evento.getSource();
			let mensagemErroValidacao = Validador.validarDataEntrada(datePicker);

			if (mensagemErroValidacao)
			{
				datePicker.setValueState("Error");
                datePicker.setValueStateText(mensagemErroValidacao);
			}
		},

		aoMudarValorTamanho (evento){
            let campoInput = evento.getSource();
			let mensagemErroValidacao = Validador.validarTamanho(campoInput);

			if (mensagemErroValidacao)
			{
				campoInput.setValueState("Error");
                campoInput.setValueStateText(mensagemErroValidacao);
			}
		},

		aoMudarValorPrecoMetroQuadrado (evento){
            let campoInput = evento.getSource();
			let mensagemErroValidacao = Validador.validarPrecoMetroQuadrado(campoInput);

			if (mensagemErroValidacao)
			{
				campoInput.setValueState("Error");
                campoInput.setValueStateText(mensagemErroValidacao);
			}
		},

		aoMudarValorDetalhes (evento){
            let campoInput = evento.getSource();
			let mensagemErroValidacao = Validador.validarDetalhes(campoInput);

			if (mensagemErroValidacao)
			{
				campoInput.setValueState("Error");
                campoInput.setValueStateText(mensagemErroValidacao);
			}
		},

		aoEfetuarCadastroComSucesso(produtoCadastrado){
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
		}
	});
});
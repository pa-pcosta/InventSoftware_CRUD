sap.ui.define([
	"./Base.controller",
	"../model/formatter",
	"../services/validacaoCadastro"
], (BaseController, formatter, Validador) => {
	"use strict";

	return BaseController.extend("ui5.Controle_De_Estoque.controller.CadastroProdutoTapecaria", {
		
		formatter: formatter,
		validador: Validador,

		onInit() {
			this.vincularRota("cadastro");
			this.getOwnerComponent().getRouter().getRoute("edicao").attachPatternMatched(this.aoCoincidirRotaEdicao, this);
		},

		async aoCoincidirRota() {
            this.definirModelo("produtoTapecaria");

			var resposta = await fetch("api/Tapecaria/enumTipoTapecaria");
			var tiposTapecaria = await resposta.json();
			this.definirModelo("enumTipoTapecaria", tiposTapecaria);

			let view = this.getView();
            var campos = ["cadastroComboBoxTipo",
				"cadastroDatePickerDataEntrada",
				"cadastroInputArea",
				"cadastroInputPrecoMetroQuadrado",
				"cadastroInputDetalhes"
			];

            campos.forEach(
				function(idCampo) {
                var campo = view.byId(idCampo);
                if (campo) {
                    campo.setValueState("None");
                }
            });
		},

		aoCoincidirRotaEdicao (evento) {
			var id = evento.getParameter("arguments").id
            var url = 'api/Tapecaria/' + id;
			
			fetch(url)
			.then( resposta => resposta.json())
			.then( modelo => this.definirModelo("produtoTapecaria", modelo));
		},

        aoClicarEmVoltar (){
            this.retornarParaPaginaAnterior();
        },

        aoClicarEmSalvar (){
            let listaDeErrosValidacao = Validador.validarTodos(this.getView());
			
			if(listaDeErrosValidacao.length == 0){
				let novoProdutoTapecaria = this.getView().getModel("produtoTapecaria").getData();
				
				novoProdutoTapecaria.tipo = parseInt(novoProdutoTapecaria.tipo);
				
				fetch('api/Tapecaria', {
					method: 'POST',
					body: JSON.stringify(novoProdutoTapecaria),
					headers: {
						"Content-type": "application/json; charset=UTF-8"
					}
				})
				.then(resposta => resposta.json())
				.then(this.mostrarMessageBoxSucesso("SUCESSO !"))
				.then(
					produtoCadastrado =>
						this.getOwnerComponent().getRouter().navTo("detalhes",{
							id: produtoCadastrado.id
						})
				);
			}
			else
			{
				this.mostrarMessageBoxFalha("Alguns campos não atendem os critérios de validação")
			}
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
	});
});
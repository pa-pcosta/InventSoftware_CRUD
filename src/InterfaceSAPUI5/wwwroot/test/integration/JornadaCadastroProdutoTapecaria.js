sap.ui.define([
	"sap/ui/test/opaQunit",
	"./pages/CadastroProdutoTapecaria",
	"./pages/Listagem",
	"./pages/DetalhesProdutoTapecaria"
], (opaTest) => {
	"use strict";

	const ID_BOTAO_VOLTAR = "botaoVoltar";
	const ID_BOTAO_CANCELAR = "botaoCancelar";
	const ID_BOTAO_SALVAR = "botaoSalvar";
	const ID_COMBOBOX_TIPO = "cadastroComboBoxTipo";
	const ID_DATEPICKER_DATA_ENTRADA = "cadastroDatePickerDataEntrada";
	const ID_INPUT_AREA = "cadastroInputArea";
	const ID_INPUT_PRECO_METRO_QUADRADO = "cadastroInputPrecoMetroQuadrado";
	const ID_TEXTAREA_DETALHES = "cadastroTextAreaDetalhes";
	const ID_MESSAGEBOX_ERRO = "messageBoxErro";
	const ID_MESSAGEBOX_SUCESSO = "messageBoxSucesso";
	const DESCRICAO_REGISTRO_TESTE = "TESTE OPA";

	QUnit.module("CADASTRO DE PRODUTO DE TAPECARIA", () => {

		opaTest("Deve exibir tela de cadastro", (Given, When, Then) => {

			Given.iStartMyApp({
				hash:"cadastro"
			});

			Then.naTelaDeCadastro
			.paginaDeCadastroEhCarregadaComTitulo("tituloTelaCadastro");
		});

		opaTest("Deve navegar para tela de listagem", (Given, When, Then) => {

			When.naTelaDeCadastro
			.ehPressionadoBotaoComIcone("sap-icon://nav-back");

			Then.naTelaDeListagem
			.listaDeProdutosEhCarregadaComRegistros();

			When.naTelaDeListagem
			.ehPressionadoBotaoComTitulo("botaoAdicionarNovoProduto");

			Then.naTelaDeCadastro
			.paginaDeCadastroEhCarregadaComTitulo("tituloTelaCadastro");
		});

		opaTest("Deve cancelar cadastro e navegar para tela de listagem", (Given, When, Then) => {

			When.naTelaDeCadastro
			.ehPressionadoBotaoComTitulo("botaoCancelar");

			Then.naTelaDeListagem
			.listaDeProdutosEhCarregadaComRegistros();

			When.naTelaDeListagem
			.ehPressionadoBotaoComTitulo("botaoAdicionarNovoProduto");

			Then.naTelaDeCadastro
			.paginaDeCadastroEhCarregadaComTitulo("tituloTelaCadastro");
		});

		opaTest("Deve retornar erro ao tentar cadastrar com formulário vazio", (Given, When, Then) => {

			When.naTelaDeCadastro
			.ehPressionadoBotaoComTitulo("botaoSalvar");

			Then.naTelaDeCadastro
			.messageBoxEhExibida(ID_MESSAGEBOX_ERRO, "Alguns campos não atendem os critérios de validação");
		});

		opaTest("Deve retornar erro ao tentar cadastrar com dados inválidos", (Given, When, Then) => {

			When.naTelaDeCadastro
			.ehPreenchidaComboBox(ID_COMBOBOX_TIPO, "")
			.and
			.ehPreenchidoDatePicker(ID_DATEPICKER_DATA_ENTRADA, new Date(9999, 11, 31, 23, 59, 59, 999))
			.and
			.ehPreenchidoInput(ID_INPUT_AREA, "-3")
			.and
			.ehPreenchidoInput(ID_INPUT_PRECO_METRO_QUADRADO, "caracter")
			.and
			.ehPreenchidoInput(ID_TEXTAREA_DETALHES, "aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa");

			Then.naTelaDeCadastro
			.confereValueStateCampo(ID_COMBOBOX_TIPO, "Error")
			.and
			.confereValueStateCampo(ID_DATEPICKER_DATA_ENTRADA, "Error")
			.and
			.confereValueStateCampo(ID_INPUT_AREA, "Error")
			.and
			.confereValueStateCampo(ID_INPUT_PRECO_METRO_QUADRADO, "Error")
			.and
			.confereValueStateCampo(ID_TEXTAREA_DETALHES, "Error");

			When.naTelaDeCadastro
			.ehPressionadoBotaoComTitulo("botaoSalvar");

			Then.naTelaDeCadastro
			.messageBoxEhExibida(ID_MESSAGEBOX_ERRO, "Alguns campos não atendem os critérios de validação");
		});
		
		opaTest("Deve cadastrar produto com sucesso e navegar para tela de detalhes", (Given, When, Then) => {

			When.naTelaDeCadastro
			.ehPreenchidaComboBox(ID_COMBOBOX_TIPO, "3")
			.and
			.ehPreenchidoDatePicker(ID_DATEPICKER_DATA_ENTRADA, new Date())
			.and
			.ehPreenchidoInput(ID_INPUT_AREA, "11")
			.and
			.ehPreenchidoInput(ID_INPUT_PRECO_METRO_QUADRADO, "11")
			.and
			.ehPreenchidoInput(ID_TEXTAREA_DETALHES, `${ DESCRICAO_REGISTRO_TESTE + "" + new Date().getHours()}:${new Date().getMinutes()}`);

			Then.naTelaDeCadastro
			.confereValueStateCampo(ID_COMBOBOX_TIPO, "None")
			.and
			.confereValueStateCampo(ID_DATEPICKER_DATA_ENTRADA, "None")
			.and
			.confereValueStateCampo(ID_INPUT_AREA, "None")
			.and
			.confereValueStateCampo(ID_INPUT_PRECO_METRO_QUADRADO, "None")
			.and
			.confereValueStateCampo(ID_TEXTAREA_DETALHES, "None");

			When.naTelaDeCadastro
			.ehPressionadoBotaoComTitulo("botaoSalvar");

			Then.naTelaDeCadastro
			.messageBoxEhExibida(ID_MESSAGEBOX_SUCESSO, "Produto cadastrado com sucesso!")
			
			Then.naTelaDeDetalhes
			.paginaDeDetalhesEhCarregadaComRegistroCriado(DESCRICAO_REGISTRO_TESTE)
			
			Then.iTeardownMyApp();
		});
	});
});
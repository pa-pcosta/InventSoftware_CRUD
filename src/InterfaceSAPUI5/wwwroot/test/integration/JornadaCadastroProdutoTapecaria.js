sap.ui.define([
	"sap/ui/test/opaQunit",
	"./pages/CadastroProdutoTapecaria",
	"./pages/Listagem",
	"./pages/DetalhesProdutoTapecaria"
], (opaTest) => {
	"use strict";

	const ID_BOTAO_VOLTAR = "botaoVoltar";
	const ID_BOTAO_ADICIONAR = "botaoAdicionar";
	const ID_BOTAO_CANCELAR = "botaoCancelar";
	const ID_BOTAO_SALVAR = "botaoSalvar";
	const ID_COMBOBOX_TIPO = "cadastroComboBoxTipo";
	const ID_DATEPICKER_DATA_ENTRADA = "cadastroDatePickerDataEntrada";
	const ID_INPUT_AREA = "cadastroInputArea";
	const ID_INPUT_PRECO_METRO_QUADRADO = "cadastroInputPrecoMetroQuadrado";
	const ID_TEXTAREA_DETALHES = "cadastroTextAreaDetalhes";

	QUnit.module("Cadastro de produto de tapecaria", () => {

		opaTest("Deve exibir tela de CADASTRO", (Given, When, Then) => {

			Given.iStartMyUIComponent({
				componentConfig: {
					name: "ui5.controle_de_estoque"
				}
			});

			When.naTelaDeListagem
			.ehPressionadoBotao("botaoAdicionar");

			Then.naTelaDeCadastro
			.paginaDeCadastroEhCarregada ();
		});

		opaTest("Deve retornar para tela de LISTAGEM", (Given, When, Then) => {

			When.naTelaDeCadastro
			.ehPressionadoBotao(ID_BOTAO_VOLTAR);

			Then.naTelaDeListagem
			.listaDeProdutosEhCarregada();

			When.naTelaDeListagem
			.ehPressionadoBotao(ID_BOTAO_ADICIONAR);

			Then.naTelaDeCadastro
			.paginaDeCadastroEhCarregada();
		});

		opaTest("Deve cancelar cadastro e retornar para tela de LISTAGEM", (Given, When, Then) => {

			When.naTelaDeCadastro
			.ehPressionadoBotao(ID_BOTAO_CANCELAR);

			Then.naTelaDeListagem
			.listaDeProdutosEhCarregada();

			When.naTelaDeListagem
			.ehPressionadoBotao(ID_BOTAO_ADICIONAR);

			Then.naTelaDeCadastro
			.paginaDeCadastroEhCarregada();
		});

		opaTest("Deve retornar erro ao tentar cadastrar com formulário vazio", (Given, When, Then) => {

			When.naTelaDeCadastro
			.ehPressionadoBotao(ID_BOTAO_SALVAR);

			Then.naTelaDeCadastro
			.messageBoxEhExibida();
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
			.valueStateCampo(ID_COMBOBOX_TIPO, "Error")
			.and
			.valueStateCampo(ID_DATEPICKER_DATA_ENTRADA, "Error")
			.and
			.valueStateCampo(ID_INPUT_AREA, "Error")
			.and
			.valueStateCampo(ID_INPUT_PRECO_METRO_QUADRADO, "Error")
			.and
			.valueStateCampo(ID_TEXTAREA_DETALHES, "Error");

			When.naTelaDeCadastro
			.ehPressionadoBotao(ID_BOTAO_SALVAR);

			Then.naTelaDeCadastro
			.messageBoxEhExibida();
		});
		
		opaTest("Deve cadastrar produto com sucesso", (Given, When, Then) => {

			When.naTelaDeCadastro
			.ehPreenchidaComboBox(ID_COMBOBOX_TIPO, "3")
			.and
			.ehPreenchidoDatePicker(ID_DATEPICKER_DATA_ENTRADA, new Date())
			.and
			.ehPreenchidoInput(ID_INPUT_AREA, "11")
			.and
			.ehPreenchidoInput(ID_INPUT_PRECO_METRO_QUADRADO, "11")
			.and
			.ehPreenchidoInput(ID_TEXTAREA_DETALHES, `TESTE OPA ${new Date().getHours()}:${new Date().getMinutes()}`);

			Then.naTelaDeCadastro
			.valueStateCampo(ID_COMBOBOX_TIPO, "None")
			.and
			.valueStateCampo(ID_DATEPICKER_DATA_ENTRADA, "None")
			.and
			.valueStateCampo(ID_INPUT_AREA, "None")
			.and
			.valueStateCampo(ID_INPUT_PRECO_METRO_QUADRADO, "None")
			.and
			.valueStateCampo(ID_TEXTAREA_DETALHES, "None");

			When.naTelaDeCadastro
			.ehPressionadoBotao(ID_BOTAO_SALVAR);

			Then.naTelaDeCadastro
			.messageBoxEhExibida()
			
			Then.naTelaDeDetalhes
			.paginaDeDetalhesEhCarregada();
		});
	});
});
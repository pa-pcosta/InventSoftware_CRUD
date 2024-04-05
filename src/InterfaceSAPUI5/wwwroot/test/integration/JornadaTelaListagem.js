sap.ui.define([
	"sap/ui/test/opaQunit",
	"./pages/Listagem",
	"./pages/DetalhesProdutoTapecaria",
	"./pages/CadastroProdutoTapecaria"
], (opaTest) => {
	"use strict";

	QUnit.module("LISTAGEM DE PRODUTO DE TAPECARIA", () => {

		opaTest("Deve mostrar registros do tipo TAPETE", (Given, When, Then) => {

			Given.iStartMyApp();

			When.naTelaDeListagem
			.comboBoxEhAberta("listagemComboBox")
			.and
			.ehSelecionadoItemDaComboBoxAberta("listagemComboBox", 0)
			.and
			.comboBoxEhFechada("listagemComboBox");

			Then.naTelaDeListagem
			.listaDeProdutosEhCarregada();
		});

		opaTest("Deve mostrar produtos com descrição = Persa", (Given, When, Then) => {

			When.naTelaDeListagem
			.ehPesquisadoNoSearchField("Persa");

			Then.naTelaDeListagem
			.listaDeProdutosEhCarregada();
		});

		opaTest("Deve navegar para tela de detalhes", (Given, When, Then) => {

			When.naTelaDeListagem
			.oPrimeiroItemDaListaEhSelecionado();

			Then.naTelaDeDetalhes
			.paginaDeDetalhesEhCarregada();

			When.naTelaDeDetalhes
			.botaoVoltarEhPressionado();

			Then.naTelaDeListagem
			.listaDeProdutosEhCarregada();
		});

		opaTest("Deve navegar para tela de cadastro", (Given, When, Then) => {

			When.naTelaDeListagem
			.ehPressionadoBotao("botaoAdicionar");

			Then.naTelaDeCadastro
			.paginaDeCadastroEhCarregada();
			
			When.naTelaDeCadastro
			.ehPressionadoBotao("botaoVoltar");

			Then.naTelaDeListagem
			.listaDeProdutosEhCarregada();

			Then.iTeardownMyApp();
		});
	});
});
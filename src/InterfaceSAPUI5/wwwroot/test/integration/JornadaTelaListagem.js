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

		opaTest("Deve mostrar registros do tipo CORTINA", (Given, When, Then) => {

			When.naTelaDeListagem
			.comboBoxEhAberta("listagemComboBox")
			.and
			.ehSelecionadoItemDaComboBoxAberta("listagemComboBox", 1)
			.and
			.comboBoxEhFechada("listagemComboBox");

			Then.naTelaDeListagem
			.listaDeProdutosEhCarregada();
		});

		opaTest("Deve mostrar registros do tipo ESTOFADO", (Given, When, Then) => {

			When.naTelaDeListagem
			.comboBoxEhAberta("listagemComboBox")
			.and
			.ehSelecionadoItemDaComboBoxAberta("listagemComboBox", 2)
			.and
			.comboBoxEhFechada("listagemComboBox");

			Then.naTelaDeListagem
			.listaDeProdutosEhCarregada();
		});

		opaTest("Deve mostrar registros do tipo OUTROS", (Given, When, Then) => {

			When.naTelaDeListagem
			.comboBoxEhAberta("listagemComboBox")
			.and
			.ehSelecionadoItemDaComboBoxAberta("listagemComboBox", 3)
			.and
			.comboBoxEhFechada("listagemComboBox");

			Then.naTelaDeListagem
			.listaDeProdutosEhCarregada();
		});

		opaTest("Deve mostrar produtos com descrição = Bebê Conforto", (Given, When, Then) => {

			When.naTelaDeListagem
			.ehPesquisadoNoSearchField("Bebê Conforto");

			Then.naTelaDeListagem
			.listaDeProdutosEhCarregada();
		});

		opaTest("Deve mostrar lista vazia ao procurar por registro inexistente", (Given, When, Then) => {

			When.naTelaDeListagem
			.ehPesquisadoNoSearchField("aleatorio");

			Then.naTelaDeListagem
			.listaDeProdutosEhCarregada();
		});

		opaTest("Deve mostrar todos os registros", (Given, When, Then) => {

			When.naTelaDeListagem
			.ehSelecionadoItemDaComboBoxAberta("listagemComboBox", "")
			.and
			.ehPesquisadoNoSearchField("");

			Then.naTelaDeListagem
			.listaDeProdutosEhCarregada();
		});

		opaTest("Deve navegar para tela de detalhes", (Given, When, Then) => {

			When.naTelaDeListagem
			.oPrimeiroItemDaListaEhSelecionado();

			Then.naTelaDeDetalhes
			.paginaDeDetalhesEhCarregadaComRegistroEspecifico("35");

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
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
			.comboBoxComPlaceHolderEspecificoEhAberta("placeHolderComboBoxFiltroTelaListagem")
			.and
			.ehSelecionadoItemDaComboBoxComPlaceHolderEspecificoAberta("placeHolderComboBoxFiltroTelaListagem", 0)
			.and
			.comboBoxComPlaceHolderEspecificoEhFechada("placeHolderComboBoxFiltroTelaListagem");

			Then.naTelaDeListagem
			.listaDeProdutosEhCarregadaComRegistros();
		});

		opaTest("Deve mostrar registros do tipo CORTINA", (Given, When, Then) => {

			When.naTelaDeListagem
			.comboBoxComPlaceHolderEspecificoEhAberta("placeHolderComboBoxFiltroTelaListagem")
			.and
			.ehSelecionadoItemDaComboBoxComPlaceHolderEspecificoAberta("placeHolderComboBoxFiltroTelaListagem", 1)
			.and
			.comboBoxComPlaceHolderEspecificoEhFechada("placeHolderComboBoxFiltroTelaListagem");

			Then.naTelaDeListagem
			.listaDeProdutosEhCarregadaComRegistros();
		});

		opaTest("Deve mostrar registros do tipo ESTOFADO", (Given, When, Then) => {

			When.naTelaDeListagem
			.comboBoxComPlaceHolderEspecificoEhAberta("placeHolderComboBoxFiltroTelaListagem")
			.and
			.ehSelecionadoItemDaComboBoxComPlaceHolderEspecificoAberta("placeHolderComboBoxFiltroTelaListagem", 2)
			.and
			.comboBoxComPlaceHolderEspecificoEhFechada("placeHolderComboBoxFiltroTelaListagem");

			Then.naTelaDeListagem
			.listaDeProdutosEhCarregadaComRegistros();
		});

		opaTest("Deve mostrar registros do tipo OUTROS", (Given, When, Then) => {

			When.naTelaDeListagem
			.comboBoxComPlaceHolderEspecificoEhAberta("placeHolderComboBoxFiltroTelaListagem")
			.and
			.ehSelecionadoItemDaComboBoxComPlaceHolderEspecificoAberta("placeHolderComboBoxFiltroTelaListagem", 3)
			.and
			.comboBoxComPlaceHolderEspecificoEhFechada("placeHolderComboBoxFiltroTelaListagem");

			Then.naTelaDeListagem
			.listaDeProdutosEhCarregadaComRegistros();
		});

		opaTest("Deve mostrar produtos com descrição = Bebê Conforto", (Given, When, Then) => {

			When.naTelaDeListagem
			.ehPesquisadoNoSearchField("searchFieldPlaceholder", "Bebê Conforto");

			Then.naTelaDeListagem
			.listaDeProdutosEhCarregadaComRegistros();
		});

		opaTest("Deve mostrar lista vazia ao procurar por registro inexistente", (Given, When, Then) => {

			When.naTelaDeListagem
			.ehPesquisadoNoSearchField("searchFieldPlaceholder", "aleatorio");

			Then.naTelaDeListagem
			.listaDeProdutosEhCarregadaSemRegistros();
		});

		opaTest("Deve mostrar todos os registros", (Given, When, Then) => {

			When.naTelaDeListagem
			.ehSelecionadoItemDaComboBoxComPlaceHolderEspecificoAberta("placeHolderComboBoxFiltroTelaListagem", "")
			.and
			.ehPesquisadoNoSearchField("searchFieldPlaceholder", "");

			Then.naTelaDeListagem
			.listaDeProdutosEhCarregadaComRegistros();
		});

		opaTest("Deve navegar para tela de detalhes", (Given, When, Then) => {

			When.naTelaDeListagem
			.oPrimeiroItemDaListaEhSelecionado();

			Then.naTelaDeDetalhes
			.paginaDeDetalhesEhCarregadaComRegistroEspecifico("35");

			When.naTelaDeDetalhes
			.botaoVoltarEhPressionado();

			Then.naTelaDeListagem
			.listaDeProdutosEhCarregadaComRegistros();
		});

		opaTest("Deve navegar para tela de cadastro", (Given, When, Then) => {

			When.naTelaDeListagem
			.ehPressionadoBotaoComTitulo("botaoAdicionarNovoProduto");

			Then.naTelaDeCadastro
			.paginaDeCadastroEhCarregada();
			
			When.naTelaDeCadastro
			.ehPressionadoBotao("botaoVoltar");

			Then.naTelaDeListagem
			.listaDeProdutosEhCarregadaComRegistros();

			Then.iTeardownMyApp();
		});
	});
});
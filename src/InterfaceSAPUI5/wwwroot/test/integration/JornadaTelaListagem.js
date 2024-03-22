sap.ui.define([
	"sap/ui/test/opaQunit",
	"./pages/Listagem",
	"./pages/DetalhesProduto"
], (opaTest) => {
	"use strict";

	QUnit.module("TelaListagem", () => {

		opaTest("Deve mostrar registros do tipo TAPETE", (Given, When, Then) => {

			Given.iStartMyUIComponent({
				componentConfig: {
					name: "ui5.controle_de_estoque"
				}
			});

			When.naTelaDeListagem
			.comboBoxEhAberta("listagemComboBox")
			.and
			.ehSelecionadoItemDaComboBoxAberta("listagemComboBox", 0)
			.and
			.comboBoxEhFechada("listagemComboBox");

			Then.naTelaDeListagem
			.listaDeProdutosEhCarregada(7);
		});

		opaTest("Deve mostrar produtos com descrição = Persa", (Given, When, Then) => {

			When.naTelaDeListagem
			.ehPesquisadoNoSearchField("listagemSearchField", "Persa");

			Then.naTelaDeListagem
			.listaDeProdutosEhCarregada(1);
		});

		opaTest("Deve navegar para tela de detalhes", (Given, When, Then) => {

			When.naTelaDeListagem
			.oPrimeiroItemDaListaEhSelecionado();

			Then.naTelaDeCadastro
			.paginaDeDetalhesEhCarregada(35);
		});
	});
});
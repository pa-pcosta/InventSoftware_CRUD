sap.ui.define([
	"sap/ui/test/opaQunit",
	"./pages/Listagem"
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
	});
});
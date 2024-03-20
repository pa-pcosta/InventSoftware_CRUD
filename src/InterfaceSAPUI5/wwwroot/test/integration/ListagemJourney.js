sap.ui.define([
	"sap/ui/test/opaQunit",
	"./pages/Listagem"
], function (opaTest) {
	"use strict";

	QUnit.module("Posts");

	opaTest("Deve exibir lista com todos os items", function (Given, Then) {
		// Arrangements
		// Given.iStartMyApp({
		// 	componentConfig: {
		// 		name: "ui5.Controle_De_Estoque"
		// 	}
		// });

		// Assertions
		Then.naTelaDeListagem.aListaDeveConterTodosRegistros();
	});
});
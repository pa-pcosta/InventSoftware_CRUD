QUnit.config.autostart = false;

sap.ui.require([
	"sap/ui/test/opaQunit",
	"sap/ui/test/Opa5",
	"sap/ui/test/actions/Press"
], function (opaTest, opa5, Press) {
	"use strict";

	QUnit.module("Navigation");

	opa5.extendConfig({
		viewNamespace: "ui5.Controle_De_Estoque.View.",
		viewName:"TelaListagem",
		autoWait: true,
		asyncPolling: true
	})

	opaTest("Deve exibir MessageBox", (Given, When, Then) => {
		
		Given.iStartMyUIComponent({
			componentConfig: {
				name: "ui5.Controle_De_Estoque"
			}
		});

		When.waitFor({
			id: "botaoAdicionar",
			actions: new Press(),
			errorMessage: "botaoAdicionar não encontrado na view"
		});

		Then.waitFor({
			controlType: "sap.m.MessageBox",
			success() {
				opa5.assert.ok(true, "The dialog is open");
			},
			errorMessage: "Did not find the dialog control"
		});
		 
        Then.iTeardownMyApp();
	});

	QUnit.start();
});
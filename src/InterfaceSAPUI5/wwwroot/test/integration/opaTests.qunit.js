QUnit.config.autostart = false;

sap.ui.getCore().attachInit(() => {
	"use strict";

	sap.ui.require([
        "ui5/Controle_De_Estoque/test/integration/ListagemJourney"
	], () => {
        QUnit.start();
	});
});
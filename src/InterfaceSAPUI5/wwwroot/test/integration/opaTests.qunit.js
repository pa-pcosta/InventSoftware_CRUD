QUnit.config.autostart = false;

sap.ui.getCore().attachInit(() => {
	"use strict";

	sap.ui.require([
        "ui5/controle_de_estoque/test/integration/JornadaTelaListagem"
	], () => {
        QUnit.start();
	});
});
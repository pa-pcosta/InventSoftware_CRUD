QUnit.config.autostart = false;

sap.ui.require(
	[
		"sap/ui/core/Core",
		"ui5/controle_de_estoque/test/integration/TodasJornadas"
	], 
	async function (Core) {
		"use strict";

		await Core.ready();

		QUnit.start();
	}
);

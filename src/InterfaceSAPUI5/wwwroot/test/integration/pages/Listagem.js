sap.ui.define([
    "sap/ui/test/Opa5",
	"sap/ui/test/actions/Press"
],(Opa5, Press) => {
    "use strict";

    const nomeDaView = "TelaListagem";
    
    Opa5.createPageObjects({
		naTelaDeListagem: {
			actions: {
				oBotaoAdicionarEhAcionado() {
					return this.waitFor({
						id: "botaoAdicionar",
						viewName: nomeDaView,
						actions: new Press(),
						errorMessage: "botaoAdicionar não encontrado na view"
					});
				}
			},

			assertions: {
				umDialogoDeveAparecer() {
					return this.waitFor({
						controlType: "sap.m.MessageBox",
                        viewName: nomeDaView,
						success() {
							// we set the view busy, so we need to query the parent of the app
							Opa5.assert.ok(true, "The dialog is open");
						},
						errorMessage: "Did not find the dialog control"
					});
				}
			}
		}
	});
});
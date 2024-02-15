sap.ui.define([
	"sap/ui/core/mvc/Controller"
], (Controller) => {
	"use strict";

	return Controller.extend("ui5.Controle_De_Estoque.controller.DetalhesProdutoTapecaria", {
		
        onInit() {
		    var roteador = this.getOwnerComponent().getRouter();
		    roteador.getRoute("detalhes").attachMatched(this.aoCoincidirRota, this);
		},

		aoCoincidirRota(evento) {
            
            this.vinculaProdutoTapecariaNaView(evento);
		},

        vinculaProdutoTapecariaNaView (evento) {

			var argumentos = evento.getParameter("arguments");
			var view = this.getView();

			view.bindElement({
				path : "/detalhes(" + argumentos.Id + ")",
				events : {
					change: this._onBindingChange.bind(this),
					dataRequested: function (evento) {
						view.setBusy(true);
					},
					dataReceived: function (evento) {
						view.setBusy(false);
					}
				}
			});
            
        },

		_onBindingChange : function (evento) {
			// No data for the binding
			if (!this.getView().getBindingContext()) {
				this.getRouter().getTargets().display("notFound");
			}
		},

        async setarModeloTapecaria (url) {
			
			return fetch(url)
				.then(data => {
					return data.json();
				})
				.then(modelo => { this.getView().setModel(new JSONModel(modelo), "produtoTapecaria"); });
		}
	});
});
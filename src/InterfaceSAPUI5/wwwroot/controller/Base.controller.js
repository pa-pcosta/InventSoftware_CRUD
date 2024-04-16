sap.ui.define([
	"sap/ui/core/mvc/Controller",
	"sap/ui/model/json/JSONModel",
	"sap/m/MessageBox",
	"sap/ui/core/BusyIndicator"
], (Controller, JSONModel, MessageBox, BusyIndicator) => {
	"use strict";

	return Controller.extend("ui5.controle_de_estoque.controller.Base", {
		
        vincularRota(nomeRota, aoCoincidirRota){
			this.getOwnerComponent().getRouter().getRoute(nomeRota).attachPatternMatched(aoCoincidirRota, this);
        },

        definirModelo(nomeModelo, dados = null){
			if (dados == null)
			{
				this.getView().setModel(new JSONModel({}), nomeModelo);
			}
			else
			{
            	this.getView().setModel(new JSONModel(dados), nomeModelo);
			}
        },
		
		obterModelo(nomeModelo)
		{
			return this.getView().getModel(nomeModelo).getData();
		},

		navegarPara (rota, parametro){
			const roteador = this.getOwnerComponent().getRouter();

			roteador.navTo(rota, parametro);
		},

		obterMensagemI18n (mensagem, placeholders = null) {
			const pacoteDeTexto = this.getOwnerComponent().getModel("i18n").getResourceBundle();
			
			if (placeholders != null)
			{
			return pacoteDeTexto.getText(mensagem, placeholders);
			}
			else
			{ 
				return pacoteDeTexto.getText(mensagem);
			}
		},

		exibirEspera(funcao){
			try
			{
				const delayBusyIndicator = 0;
				BusyIndicator.show(delayBusyIndicator);

				return funcao()
					.catch(erro => MessageBox.error(erro, {
						id: "messageBoxErro"
					}))
					.finally(() => BusyIndicator.hide());
			}
			catch (execao)
			{
				BusyIndicator.hide();
			}
		},

		exibirMensagemDeConfirmacao(mensagem, funcao)
		{
			MessageBox.confirm (mensagem, {
				id: "messageBoxConfirmacao",
				onClose: (clique) => {
					funcao(clique);
				}
			})
		},

		exibirMensagemDeSucesso(mensagem, funcao)
		{
			MessageBox.success(mensagem, {
				id: "messageBoxSucesso",
				onClose: (clique) => {
					funcao(clique);
				}
			})
		}
	});
});
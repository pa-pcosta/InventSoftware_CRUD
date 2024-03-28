sap.ui.define([
	"sap/ui/test/Opa5",
	"sap/ui/test/actions/Press",
	'sap/ui/test/matchers/PropertyStrictEquals'
], (Opa5, 
	Press,
	PropertyStrictEquals) => {
	"use strict";

	const NOME_DA_VIEW = "ui5.controle_de_estoque.view.DetalhesProdutoTapecaria";

	Opa5.createPageObjects({
		naTelaDeDetalhes: {
			actions: {
				botaoVoltarEhPressionado() {
					return this.waitFor({
						viewName: NOME_DA_VIEW,
						controlType: "sap.m.Button",
						matchers: new PropertyStrictEquals({
							name: "icon",
							value: "" 
						}),
						actions: new Press(),
						success: function () {
							Opa5.assert.ok(true, "Botão voltar pressionado com sucesso");
						},
						errorMessage: "Botão voltar não foi encontrado na view"
					});
				},

				ehPressionadoBotao (idBotao) {
					return this.waitFor({
						id: idBotao,
						viewName: NOME_DA_VIEW,
						actions: new Press(),
						success: (idBotao) => {
							Opa5.assert.ok(true, `Botao com id '${idBotao}' pressionado com sucesso`)
						},
						errorMessage: `Botão com id '${idBotao} não foi encontrado na view'`
					});
				}
			},

			assertions: {
				paginaDeDetalhesEhCarregada () {
					return this.waitFor({
						id: "tituloSimpleForm",
						viewName: NOME_DA_VIEW,
						success: () => {
							Opa5.assert.ok(true, "Página de Detalhes do produto foi carregada");
						},
						errorMessage: "Página de Detalhes do produto não foi carregada"
					})
				},

				messageBoxEhExibida () {
					return this.waitFor({
						controlType: "sap.m.Dialog",
						searchOpenDialogs: true,
						success: (messageBoxes) => {
							messageBoxes.forEach((messageBox) => {
								if (messageBox.getButtons().length > 0) {
									let okButton = messageBox.getButtons()[0];
									okButton.firePress();
									Opa5.assert.ok(true, "Ação 'OK' da caixa de mensagem disparada com sucesso");
								} else {
									Opa5.assert.ok(false, "A caixa de mensagem não possui botão 'OK'");
								}
							});
						},
						errorMessage: "A caixa de mensagem não foi encontrada na visualização"
					});
				},
			}
		}
	});
});
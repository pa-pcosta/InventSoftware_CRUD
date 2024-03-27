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
							Opa5.assert.ok(true, "Botão de navegação pressionado com sucesso");
						},
						errorMessage: "Botão VOLTAR não foi encontrado na view"
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
						errorMessage: `Falha ao tentar pressionar botão com id '${idBotao}'`
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
				}
			}
		}
	});
});
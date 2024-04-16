sap.ui.define([
	"sap/ui/test/Opa5",
	"sap/ui/test/actions/Press",
	"sap/ui/test/matchers/PropertyStrictEquals",
	"sap/ui/test/matchers/AggregationContainsPropertyEqual"
], (Opa5, 
	Press,
	PropertyStrictEquals,
	AggregationContainsPropertyEqual) => {
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
						id: "paginaDeDetalhes",
						viewName: NOME_DA_VIEW,
						matchers: new PropertyStrictEquals({
							name: "title",
							value: "Detalhes do Produto" 
						}),
						success: () => {
							Opa5.assert.ok(true, "Página de Detalhes do produto foi carregada");
						},
						errorMessage: "Página de Detalhes do produto não foi carregada"
					})
				},
				
				paginaDeDetalhesEhCarregadaComRegistroEspecifico (idDoRegistroEsperado) {
					return this.waitFor({
						controlType: "sap.m.Title",
						viewName: NOME_DA_VIEW,
						matchers: new PropertyStrictEquals({
							name: "text",
							value: `ID ${idDoRegistroEsperado}`
						}),
						success: (title) => {
							Opa5.assert.ok(true, "Página de Detalhes do produto foi carregada com produto esperado")
						},
						errorMessage: "Página de Detalhes do produto não foi carregada"
					})
				},

				messageBoxEhExibida (idMessageBox, titulo, texto) {
					return this.waitFor({
						id: idMessageBox,
						matchers: 
							new AggregationContainsPropertyEqual({
								aggregationName: "content",
                            	propertyName: "text",
                            	propertyValue: texto
							})
						,
						success: (messageBox) => {
							let botao = messageBox.getButtons();
							botao[0].firePress();
							Opa5.assert.ok(true, `MessageBox ${titulo} exibida com texto "${texto}"`);
						},
						errorMessage: "A caixa de mensagem não foi encontrada na visualização"
					});
				},
			}
		}
	});
});
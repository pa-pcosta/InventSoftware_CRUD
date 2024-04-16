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
						controlType: "sap.m.Page",
						matchers: {
							i18NText: {
								propertyName: "title",
								key: "tituloTelaDetalhes"
							}
						},
						actions: (pagina) => {
							pagina.fireNavButtonPress();
						},
						success: function () {
							Opa5.assert.ok(true, "Botão voltar pressionado com sucesso");
						},
						errorMessage: "Botão voltar não foi encontrado na view"
					});
				},

				ehPressionadoBotaoComTitulo (chaveI18n) {
					return this.waitFor({
						controlType: "sap.m.Button",
						viewName: NOME_DA_VIEW,
						matchers: {
							i18NText: {
								propertyName: 'text',
								key: chaveI18n
							}
						},
						viewName: NOME_DA_VIEW,
						actions: new Press(),
						success: () => {
						Opa5.assert.ok(true, `Botao com titulo '${chaveI18n}' pressionado com sucesso`)
						},
						errorMessage: `Falha ao tentar pressionar botão com id '${chaveI18n}'`
					});
				}
			},

			assertions: {
				paginaDeDetalhesEhCarregadaComRegistroCriado (descricaoEsperada) {
					return this.waitFor({
						id: "textDetalhes",
						viewName: NOME_DA_VIEW,
						check: (campoText) => {
							let descricao = campoText.getText();
							return descricao.includes(descricaoEsperada);
						},
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

				messageBoxEhExibida (idMessageBox, texto) {
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
							Opa5.assert.ok(true, `MessageBox exibida com texto "${texto}"`);
						},
						errorMessage: "A caixa de mensagem não foi encontrada na visualização"
					});
				},
			}
		}
	});
});
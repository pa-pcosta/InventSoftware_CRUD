sap.ui.define([
	"sap/ui/test/Opa5",
	"sap/ui/test/actions/Press",
	'sap/ui/test/matchers/PropertyStrictEquals'
], (Opa5, 
	Press,
	PropertyStrictEquals) => {
	"use strict";

	const NOME_DA_VIEW = "ui5.controle_de_estoque.view.CadastroProdutoTapecaria";

	Opa5.createPageObjects({
		naTelaDeCadastro: {
			actions: {
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
				paginaDeCadastroEhCarregada () {
					return this.waitFor({
						id: "botaoSalvar",
						viewName: NOME_DA_VIEW,
						success: () => {
							Opa5.assert.ok(true, "Página de Cadastro De Produto carregada com sucesso");
						},
						errorMessage: "Falha ao carregar página de Cadastro De Produto"
					})
				}
			}
		}
	});
});
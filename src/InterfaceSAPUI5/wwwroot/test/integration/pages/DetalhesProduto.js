sap.ui.define([
	"sap/ui/test/Opa5",
	"sap/ui/test/actions/Press",
	'sap/ui/test/matchers/AggregationLengthEquals'
], (Opa5, 
	Press,
	AggregationLengthEquals) => {
	"use strict";

	const NOME_DA_VIEW = "ui5.controle_de_estoque.view.DetalhesProdutoTapecaria";

	Opa5.createPageObjects({
		naTelaDeCadastro: {
			actions: {
			
			},

			assertions: {
				paginaDeDetalhesEhCarregada (idProdutoTapecaria) {
					return this.waitFor({
						id: "viewDetalhesProdutoTapecaria",
						viewName: NOME_DA_VIEW,
						success: () => {
							try {
								let produtoTapecaria = this.getView().getModel("produtoTapecaria").getData();

								if (produtoTapecaria.id == idProdutoTapecaria){
									Opa5.assert.ok(true, "Página de Detalhes do produto foi carregada");
								}
							} catch (error) {
								Opa5.assert.ok(false, error.message);
							}
						},
						errorMessage: "Página de Detalhes do produto não foi carregada"
					})
				}
			}
		}
	});
});
sap.ui.define([
	"sap/ui/test/Opa5",
	"sap/ui/test/actions/Press",
	'sap/ui/test/matchers/AggregationLengthEquals'
], (Opa5, 
	Press,
	AggregationLengthEquals) => {
	"use strict";

	const NOME_DA_VIEW = "ui5.controle_de_estoque.view.TelaListagem";

	Opa5.createPageObjects({
		naTelaDeListagem: {
			actions: {
				botaoAdicionarEhPressionado() {
					return this.waitFor({
						id: "botaoAdicionar",
						viewName: NOME_DA_VIEW,
						actions: new Press(),
						errorMessage: "BOTÃO NÃO ENCONTRADO NA VIEW"
					});
				},

				comboBoxEhAberta(idComboBox) {
					return this.waitFor({
						id: idComboBox,
						viewName: NOME_DA_VIEW,
						success: function (comboBox) {
							comboBox.open();
							Opa5.assert.ok(NOME_DA_VIEW, `A combobox foi aberta com sucesso`)
						},
						errorMessage: `A combobox não foi aberta`
					})
				},

				ehSelecionadoItemDaComboBoxAberta (idComboBox, indice) {
					return this.waitFor({
						id: idComboBox,
						viewName: NOME_DA_VIEW,
						actions: (comboBox) => {
							try {
								comboBox.setSelectedKey(indice);
								comboBox.fireChange();

								Opa5.assert.ok(true, `Indice ${indice} foi selecionado na comboBox.`);
							} catch (error) {
								Opa5.assert.ok(false, error.message);
							}
						},
						errorMessage: `ComboBox não encontrada na view`
					})
				},

				comboBoxEhFechada (idComboBox) {
					return this.waitFor({
						id: idComboBox,
						viewName: NOME_DA_VIEW,
						success: function (comboBox) {
							comboBox.close();
							Opa5.assert.ok(NOME_DA_VIEW, `A combobox foi fechada com sucesso.`);
						},
						errorMessage: `A combobox não foi fechada com sucesso`
					});
				},

				ehPesquisadoNoSearchField (idSearchField, texto) {
					return this.waitFor({
						id: idSearchField,
						viewName: NOME_DA_VIEW,
						success: (searchField) => {
							searchField.setValue(texto);
							searchField.fireLiveChange();
						},
						errorMessage: `SearchField não encontrado na view`
					})
				},

				oPrimeiroItemDaListaEhSelecionado(){
					return this.waitFor({
						id: "listaProdutosTapecaria",
						viewName: NOME_DA_VIEW,
						success: (lista) => {
							let produtoTapecaria = lista.at(0);
							produtoTapecaria = new Press();
						}
					})
				}
			},

			assertions: {
				listaDeProdutosEhCarregada (quantidadeDeRegistrosDoTipoSelecionado) {
					return this.waitFor({
						id: "listaProdutosTapecaria",
						viewName: NOME_DA_VIEW,
						matchers: new AggregationLengthEquals({
							name: "items",
							length: quantidadeDeRegistrosDoTipoSelecionado
						}),
						success: function () {
							Opa5.assert.ok(true, `Lista de produtos do tipo TAPETE foi carregada com ${quantidadeDeRegistrosDoTipoSelecionado}`);
						},
						errorMessage: "The table does not contain all items."
					})
				}
			}
		}
	});
});
sap.ui.define([
	"sap/ui/test/Opa5",
	"sap/ui/test/actions/Press",
	'sap/ui/test/matchers/AggregationFilled'
], (Opa5, 
	Press,
	AggregationFilled) => {
	"use strict";

	const NOME_DA_VIEW = "ui5.controle_de_estoque.view.TelaListagem";

	Opa5.createPageObjects({
		naTelaDeListagem: {
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
				},

				comboBoxEhAberta(idComboBox) {
					return this.waitFor({
						id: idComboBox,
						viewName: NOME_DA_VIEW,
						success: function (comboBox) {
							comboBox.open();
							Opa5.assert.ok(NOME_DA_VIEW, `A combobox foi aberta com sucesso`);
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
							Opa5.assert.ok(true, `Filtro por [${texto}] executada no searchField`);
						},
						errorMessage: `SearchField não encontrado na view`
					})
				},

				oPrimeiroItemDaListaEhSelecionado(){
					return this.waitFor({
						id: "listaProdutosTapecaria",
						viewName: NOME_DA_VIEW,
						success: (lista) => {
							let produtoTapecaria = lista.getItems()[0];
							produtoTapecaria.firePress();
						}
					})
				}
			},

			assertions: {
				listaDeProdutosEhCarregada () {
					return this.waitFor({
						id: "listaProdutosTapecaria",
						viewName: NOME_DA_VIEW,
						matchers: new AggregationFilled({
							name: "items"
						}),
						success: function () {
							Opa5.assert.ok(true, "Lista de produtos tapecaria foi carregada");
						},
						errorMessage: "Lista de produtos tapecaria não foi carregada"
					})
				}
			}
		}
	});
});
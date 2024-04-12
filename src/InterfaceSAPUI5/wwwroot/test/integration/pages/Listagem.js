sap.ui.define([
	"sap/ui/test/Opa5",
	"sap/ui/test/actions/Press",
	"sap/ui/test/matchers/AggregationFilled",
	"sap/ui/test/matchers/AggregationEmpty"
], (Opa5, 
	Press,
	AggregationFilled,
	AggregationEmpty) => {
	"use strict";

	const NOME_DA_VIEW = "ui5.controle_de_estoque.view.TelaListagem";

	Opa5.createPageObjects({
		naTelaDeListagem: {
			actions: {
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
				},

				comboBoxEhAberta(idComboBox) {
					return this.waitFor({
						id: idComboBox,
						viewName: NOME_DA_VIEW,
						success: function (comboBox) {
							comboBox.open();
							Opa5.assert.ok(NOME_DA_VIEW, `A combobox foi aberta com sucesso`);
						},
						errorMessage: `ComboBox não encontrada na view`
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

								Opa5.assert.ok(true, `Indice ${indice} foi selecionado na comboBox ${idComboBox}`);
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
							Opa5.assert.ok(NOME_DA_VIEW, `A combobox ${idComboBox} foi fechada com sucesso.`);
						},
						errorMessage: `ComboBox não encontrada na view`
					});
				},

				ehPesquisadoNoSearchField (texto) {
					return this.waitFor({
						controlType: "sap.m.SearchField",
						viewName: NOME_DA_VIEW,
						success: (searchFields) => {
							let searchField = searchFields[0];

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
							Opa5.assert.ok(true, "Primeiro registro da lista pressionado com sucesso");
						},
						errorMessage: "A lista de produtos não foi encontrada na view"
					})
				},

				oUltimoItemDaListaEhSelecionado() {
					return this.waitFor({
						id: "listaProdutosTapecaria",
						viewName: NOME_DA_VIEW,
						success: (lista) => {
							let itens = lista.getItems();
							let ultimoItem = itens[itens.length - 1];
							ultimoItem.firePress();
							Opa5.assert.ok(true, "Último registro da lista pressionado com sucesso");
						},
						errorMessage: "A lista de produtos não foi encontrada na view"
					});
				}
			},

			assertions: {
				listaDeProdutosEhCarregadaComRegistros() {
					return this.waitFor({
						controlType:"sap.m.List",
						viewName: NOME_DA_VIEW,
						matchers: new AggregationFilled({
							name: "items"
						}),
						success: () => {
							Opa5.assert.ok(true, `Lista de produtos tapecaria foi carregada com registros`);
						},
						errorMessage: "Lista de produtos tapecaria não foi carregada"
					})
				},

				listaDeProdutosEhCarregadaSemRegistros(){
					return this.waitFor({
						controlType:"sap.m.List",
						viewName: NOME_DA_VIEW,
						matchers: new AggregationEmpty({
							name: "items"
						}),
						success: () => {
							Opa5.assert.ok(true, `Lista de produtos tapecaria foi carregada sem registros`);
						},
						errorMessage: "Lista de produtos tapecaria não foi carregada"
					})
				}
			}
		}
	});
});
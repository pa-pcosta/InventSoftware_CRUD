sap.ui.define([
	"sap/ui/test/Opa5",
	"sap/ui/test/actions/Press",
	"sap/ui/test/matchers/PropertyStrictEquals",
	"sap/ui/test/matchers/AggregationContainsPropertyEqual"
], (Opa5, Press, PropertyStrictEquals, AggregationContainsPropertyEqual) => {
	"use strict";

	const NOME_DA_VIEW = "ui5.controle_de_estoque.view.CadastroProdutoTapecaria";

	Opa5.createPageObjects({
		naTelaDeCadastro: {
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

                ehPressionadoBotaoComIcone (iconeBotao) {
					return this.waitFor({
						controlType: "sap.m.Button",
						matchers: new PropertyStrictEquals({
							name: "icon",
							value: iconeBotao
						}),
						actions: new Press(),
						success: () => {
							Opa5.assert.ok(true, `Botao com icone "${iconeBotao}" pressionado com sucesso`)
						},
						errorMessage: `Botão com id "${iconeBotao}" não foi encontrado na view`
					});
				},

				ehPreenchidaComboBox (idCombo, valor) {
					return this.waitFor({
						id: idCombo,
						viewName: NOME_DA_VIEW,
						success: (comboBox) => {
							comboBox.setSelectedKey(valor);
							comboBox.fireChange();
							Opa5.assert.ok(true, `ComboBox com id '${idCombo}' preenchida com valor ${valor}`)
						},
						errorMessage: `ComboBox com id '${idCombo} não foi encontrada na view'`
					});
				},

				ehPreenchidoDatePicker (idDatePicker, data) {
					return this.waitFor({
						id: idDatePicker,
						viewName: NOME_DA_VIEW,
						success: (datePicker) => {
							datePicker.setDateValue(data);
							datePicker.fireChange();
							Opa5.assert.ok(true, `DatePicker com id '${idDatePicker}' preenchido com valor ${data}`)
						},
						errorMessage: `DatePicker com id '${idDatePicker}' não foi encontrado na view`
					});
				},

				ehPreenchidoInput (idInput, valor) {
					return this.waitFor({
						id: idInput,
						viewName: NOME_DA_VIEW,
						success: (campoInput) => {
							campoInput.setValue(valor);
							campoInput.fireChange();
							Opa5.assert.ok(true, `Input com id '${idInput}' preenchido com valor ${valor}`)
						},
						errorMessage: `Input com id '${idInput}' não foi encontrado na view`
					});
				}
			},

			assertions: {
				paginaDeCadastroEhCarregadaComTitulo(chaveI18n) {
					return this.waitFor({
						controlType:"sap.m.Title",
						viewName: NOME_DA_VIEW,
						matchers: {
							i18NText: {
								propertyName: 'text',
								key: chaveI18n
							}
						},
						success: () => {
							Opa5.assert.ok(true, `Página de Cadastro De Produto carregada com título "${chaveI18n}"`);
						},
						errorMessage: "Falha ao carregar página de Cadastro De Produto"
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

				valueStateCampo (idCampo, valueState) {
					return this.waitFor({
						id: idCampo,
						viewName: NOME_DA_VIEW,
						success: (campo) => {
							if (campo.getValueState() == valueState) {
								Opa5.assert.ok(true, `ValueState do campo '${idCampo}' corresponde ao valor ${valueState}`);
							}
							else {
								Opa5.assert.ok(true, `ValueState do campo '${idCampo}' diferente do valor ${valueState}`);
							}
						},
						errorMessage: `Campo com id '${idCampo}' não foi encontrado na view`
					});
				}
			}
		}
	});
});
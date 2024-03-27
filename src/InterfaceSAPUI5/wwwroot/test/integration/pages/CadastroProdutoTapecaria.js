sap.ui.define([
	"sap/ui/test/Opa5",
	"sap/ui/test/actions/Press"
], (Opa5, 
	Press) => {
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
						errorMessage: `Falha ao tentar preencher ComboBox com id '${idCombo}'`
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
						errorMessage: `Falha ao tentar preencher DatePicker com id '${idDatePicker}'`
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
						errorMessage: `Falha ao tentar preencher Input com id '${idInput}'`
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
						errorMessage: `Falha ao tentar pressionar botão com id '${idCampo}'`
					});
				}
			}
		}
	});
});
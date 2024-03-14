sap.ui.define(["sap/m/MessageBox"], (MessageBox) => {
	"use strict";
    let _baseController;
    let _listaDeErros = [];
	
    return {

        inicializaValidador(baseController){
            _baseController = baseController;
        },

        validarTodos (view){
            _listaDeErros = [];

            let comboBox = view.byId("cadastroComboBoxTipo");
            let datePicker = view.byId("cadastroDatePickerDataEntrada");
            let inputArea = view.byId("cadastroInputArea");
            let inputPreco = view.byId("cadastroInputPrecoMetroQuadrado");
            let inputDetalhes = view.byId("cadastroInputDetalhes");

            this.validarTipo(comboBox);
            this.validarDataEntrada(datePicker);
            this.validarTamanho(inputArea);
            this.validarPrecoMetroQuadrado(inputPreco);
            this.validarDetalhes(inputDetalhes);

            if (_listaDeErros.length > 0)
            {
                throw (MessageBox.error(_baseController.obterMensagemI18n("mensagemFalhaDeCadastro")));
            }
        },

        validarTipo(comboBox) {
            let valorComboBox = comboBox.getSelectedKey();

            if(valorComboBox=="")
            {
                let mensagem = _baseController.obterMensagemI18n("erroValidacaoTipo");

                _listaDeErros.push(mensagem);
                comboBox.setValueState("Error");
                comboBox.setValueStateText(mensagem);
            }
            else
            {
                comboBox.setValueState("None");
            }
        },

        validarDataEntrada(datePicker) {
            let valorDatePicker = datePicker.getDateValue();
            let hoje = new Date();
            
            if (valorDatePicker == null)
            {
                let mensagem = _baseController.obterMensagemI18n("erroValidacaoDataEntradaNula");

                _listaDeErros.push(mensagem);
                datePicker.setValueState("Error");
                datePicker.setValueStateText(mensagem);
            }
            else if (valorDatePicker > hoje)
            {
                let mensagem = _baseController.obterMensagemI18n("erroValidacaoDataEntradaMaiorQueHoje");

                _listaDeErros.push(mensagem);
                datePicker.setValueState("Error");
                datePicker.setValueStateText(mensagem);
            }
            else
            {
                datePicker.setValueState("None");
            }
        },

        validarTamanho(inputArea) {
            let valorInputArea = inputArea.getValue();
            let possuiApenasNumeros = /^\d+$/.test(valorInputArea);

            if (!possuiApenasNumeros)
            {
                let mensagem = _baseController.obterMensagemI18n("erroValidacaoArea");

                _listaDeErros.push(mensagem);
                inputArea.setValueState("Error");
                inputArea.setValueStateText(mensagem);
            }
            else
            {
                inputArea.setValueState("None");
            }
        },

        validarPrecoMetroQuadrado(inputPreco) {
            let valorInputPreco = inputPreco.getValue();
            let possuiApenasNumeros = /^\d+$/.test(valorInputPreco);

            if (!possuiApenasNumeros)
            {
                let mensagem = _baseController.obterMensagemI18n("erroValidacaoPrecoMetroQuadrado");

                _listaDeErros.push(mensagem);
                inputPreco.setValueState("Error");
                inputPreco.setValueStateText(mensagem);
            }
            else
            {
                inputPreco.setValueState("None");
            }
        },

        validarDetalhes(inputDetalhes) {
            let tamanhoInputDetalhes = inputDetalhes.getValue().length;
            let maximoDeCaracteres = 50;

            if (tamanhoInputDetalhes > maximoDeCaracteres)
            {
                let mensagem = _baseController.obterMensagemI18n("erroValidacaoDetalhes", [maximoDeCaracteres]);
                
                _listaDeErros.push(mensagem);
                inputDetalhes.setValueState("Error");
                inputDetalhes.setValueStateText(mensagem);
            }
            else
            {
                inputDetalhes.setValueState("None");
            }
        },

        redefinirEstadoDosInputs(view){
            var campos = ["cadastroComboBoxTipo",
				"cadastroDatePickerDataEntrada",
				"cadastroInputArea",
				"cadastroInputPrecoMetroQuadrado",
				"cadastroInputDetalhes"
			];

            campos.forEach(
				function(idCampo) {
                var campo = view.byId(idCampo);
                if (campo) {
                    campo.setValueState("None");
                }
            });
        }
	};
});

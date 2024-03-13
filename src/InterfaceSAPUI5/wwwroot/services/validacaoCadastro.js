sap.ui.define([], () => {
	"use strict";
    let _listaDeErros = [];
	
    return {

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

            return _listaDeErros;
        },

        validarTipo(comboBox) {
            let valorComboBox = comboBox.getSelectedKey();

            if(valorComboBox=="")
            {
                _listaDeErros.push("O produto precisa ter um tipo");
                comboBox.setValueState("Error");
                comboBox.setValueStateText("O produto precisa ter um tipo");
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
                _listaDeErros.push("Insira uma data");
                datePicker.setValueState("Error");
                datePicker.setValueStateText("Insira uma data");
            }
            else if (valorDatePicker > hoje)
            {
                _listaDeErros.push("A data de registro não pode ser maior do que a atual");
                datePicker.setValueState("Error");
                datePicker.setValueStateText("A data de registro não pode ser maior do que a atual");
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
                _listaDeErros.push("Este campo aceita apenas números");
                inputArea.setValueState("Error");
                inputArea.setValueStateText("Este campo aceita apenas números");
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
                _listaDeErros.push("Este campo aceita apenas números");
                inputPreco.setValueState("Error");
                inputPreco.setValueStateText("Este campo aceita apenas números");
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
                _listaDeErros.push(`Digite no máximo ${maximoDeCaracteres} caracteres`);
                inputDetalhes.setValueState("Error");
                inputDetalhes.setValueStateText(`Digite no máximo ${maximoDeCaracteres} caracteres`);
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

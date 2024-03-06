sap.ui.define([], () => {
	"use strict";
    let _listaDeErros = [];
	
    return {

        validarTipo(evento) {
            let comboBox = evento.getSource();
            let valorComboBox = comboBox.getSelectedKey();

            if(valorComboBox==""){
                _listaDeErros.push("O produto precisa ter um tipo");
                comboBox.setValueState("Error");
                comboBox.setValueStateText("O produto precisa ter um tipo");
            }
        },

        validarDataEntrada(evento) {
            let datePicker = evento.getSource();
            let valorDatePicker = datePicker.getDateValue();
            let hoje = new Date();
            
            if (valorDatePicker > hoje)
            {
                _listaDeErros.push("A data de registro não pode ser maior do que a atual");
                datePicker.setValueState("Error");
                datePicker.setValueStateText("A data de registro não pode ser maior do que a atual");
            }
        },

        validarTamanho(evento) {
            let campoInput = evento.getSource();
            let valorCampoInput = campoInput.getValue();
            let possuiApenasNumeros = /^\d+$/.test(valorCampoInput);

            if (!possuiApenasNumeros)
            {
                _listaDeErros.push("Este campo aceita apenas números");
                campoInput.setValueState("Error");
                campoInput.setValueStateText("Este campo aceita apenas números");
            }

            console.log(_listaDeErros);
        }
	};
});

sap.ui.define([], () => {
	"use strict";

	return {
		enumTipoTapecaria(indice) {
			const oResourceBundle = this.getOwnerComponent().getModel("i18n").getResourceBundle();

			switch (indice) {
				case 0:
					return oResourceBundle.getText("tipoTapecaria0");
				case 1:
					return oResourceBundle.getText("tipoTapecaria1");
				case 2:
					return oResourceBundle.getText("tipoTapecaria2");
				case 3:
					return oResourceBundle.getText("tipoTapecaria3");
				default:
					return indice;
			}
		},

		precoTotal(precoMetroQuadrado, area) {

			let precoTotal = precoMetroQuadrado * area;
			
			const variaveisDeTexto = this.getOwnerComponent().getModel("i18n").getResourceBundle();

			return variaveisDeTexto.getText("simboloMoeda") + " " + parseFloat(precoTotal).toFixed(2);
		},

		exibirIconeReferenteAoTipo (indice){
			
			switch (indice) {
				case 0:
					return "../assets/icons/rug.png";
				case 1:
					return "../assets/icons/curtains.png";
				case 2:
					return "../assets/icons/cushion.png";
				case 3:
					return "../assets/icons/others.png";
				default:
					return "../assets/icons/broken-image.png";
			}
		},

		converteBooleanParaSimOuNao (boolean){

			const variaveisDeTexto = this.getOwnerComponent().getModel("i18n").getResourceBundle();

			if (boolean == true)
			{
				return variaveisDeTexto.getText("sim");
			}
			else
			{
				return variaveisDeTexto.getText("nao");
			}
		}
	};
});

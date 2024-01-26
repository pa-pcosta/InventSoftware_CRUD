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
			
			const oResourceBundle = this.getOwnerComponent().getModel("i18n").getResourceBundle();

			return oResourceBundle.getText("simboloMoeda") + " " + parseFloat(precoTotal).toFixed(2);
		}

	};
});

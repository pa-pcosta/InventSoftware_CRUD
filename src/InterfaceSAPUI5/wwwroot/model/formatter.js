sap.ui.define([], () => {
	"use strict";

	return {
		statusText(sStatus) {
			const oResourceBundle = this.getOwnerComponent().getModel("i18n").getResourceBundle();

			switch (sStatus) {
				case 0:
					return oResourceBundle.getText("tipoTapecaria0");
				case 1:
					return oResourceBundle.getText("tipoTapecaria1");
				case 2:
					return oResourceBundle.getText("tipoTapecaria2");
				case 3:
					return oResourceBundle.getText("tipoTapecaria3");
				default:
					return sStatus;
			}
		}
	};
});

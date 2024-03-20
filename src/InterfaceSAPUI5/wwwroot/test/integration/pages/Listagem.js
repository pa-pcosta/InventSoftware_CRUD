sap.ui.define([
    'sap/ui/test/Opa5',
    'sap/ui/test/matchers/AggregationLengthEquals',
    'sap/ui/test/matchers/I18NText',
    'sap/ui/test/actions/Press'
],
    function (Opa5,
          AggregationLengthEquals,
          I18NText,
          Press) {
    "use strict";

    var nomeDaView = "telaListagem",
        idLista = "listaProdutosTapecaria";

    Opa5.createPageObjects({
        naTelaDeListagem: {
            assertions: {
                aListaDeveConterTodosRegistros: function () {
                    return this.waitFor({
                        id: idLista,
                        viewName: nomeDaView,
                        matchers: new AggregationLengthEquals({
                            name: "items",
                            length: 24
                        }),
                        success: function () {
                            Opa5.assert.ok(true, "A lista possui 24 items");
                        },
                        errorMessage: "A lista não possui 24 items"
                    });
                }
            }
        }
    });
});
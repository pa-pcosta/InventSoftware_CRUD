sap.ui.define([
	"sap/ui/test/opaQunit",
	"./pages/DetalhesProdutoTapecaria",
	"./pages/Listagem",
	"./pages/CadastroProdutoTapecaria"
], (opaTest) => {
	"use strict";

	const ID_BOTAO_REMOVER = "botaoRemover";
	const ID_BOTAO_EDITAR = "botaoEditar";

	QUnit.module("Página de DETALHES de produto de tapecaria", () => {
        
        opaTest("Deve exibir tela de DETALHES", (Given, When, Then) => {

            Given.iStartMyUIComponent({
                componentConfig: {
                    name: "ui5.controle_de_estoque"
                }
            });

            When.naTelaDeListagem
            .oUltimoItemDaListaEhSelecionado();

            Then.naTelaDeDetalhes
            .paginaDeDetalhesEhCarregada ();
        });

        opaTest("Deve navegar para tela de LISTAGEM", (Given, When, Then) => {

			When.naTelaDeDetalhes
			.botaoVoltarEhPressionado();

			Then.naTelaDeListagem
			.listaDeProdutosEhCarregada();

            When.naTelaDeListagem
            .oUltimoItemDaListaEhSelecionado();

            Then.naTelaDeDetalhes
            .paginaDeDetalhesEhCarregada ();
		});

        opaTest("Deve exibir tela de CADASTRO na rota de edição", (Given, When, Then) => {

			When.naTelaDeDetalhes
			.ehPressionadoBotao(ID_BOTAO_EDITAR);

			Then.naTelaDeCadastro
			.paginaDeCadastroEhCarregada();

            When.naTelaDeCadastro
            .ehPressionadoBotao("botaoVoltar")

            Then.naTelaDeDetalhes
            .paginaDeDetalhesEhCarregada ();
		});

        opaTest("Deve remover registro e navegar para tela de listagem", (Given, When, Then) => {

			When.naTelaDeDetalhes
			.ehPressionadoBotao(ID_BOTAO_REMOVER);

			Then.naTelaDeDetalhes
			.messageBoxEhExibida()
            .and
            .messageBoxEhExibida();

            Then.naTelaDeListagem
            .listaDeProdutosEhCarregada();

            Then.iTeardownMyApp();
		});
	});
});
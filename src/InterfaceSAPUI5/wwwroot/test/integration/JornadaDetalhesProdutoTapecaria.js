sap.ui.define([
	"sap/ui/test/opaQunit",
	"./pages/DetalhesProdutoTapecaria",
	"./pages/Listagem",
	"./pages/CadastroProdutoTapecaria"
], (opaTest) => {
	"use strict";

	const ID_BOTAO_REMOVER = "botaoRemover";
	const ID_BOTAO_EDITAR = "botaoEditar";
    const ID_MESSAGEBOX_CONFIRMACAO = "messageBoxConfirmacao";
	const ID_MESSAGEBOX_SUCESSO = "messageBoxSucesso";

	QUnit.module("DETALHES DE PRODUTO DE TAPECARIA", () => {
        
        opaTest("Deve exibir tela de detalhes", (Given, When, Then) => {

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

        opaTest("Deve navegar para tela de listagem", (Given, When, Then) => {

			When.naTelaDeDetalhes
			.botaoVoltarEhPressionado();

			Then.naTelaDeListagem
			.listaDeProdutosEhCarregada();

            When.naTelaDeListagem
            .oUltimoItemDaListaEhSelecionado();

            Then.naTelaDeDetalhes
            .paginaDeDetalhesEhCarregada ();
		});

        opaTest("Deve navegar para tela de cadastro na rota de edição", (Given, When, Then) => {

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
			.messageBoxEhExibida(ID_MESSAGEBOX_CONFIRMACAO, "Confirmação", "Após excluir o registro não será possível recuperar os dados. Deseja continuar?")
            .and
            .messageBoxEhExibida(ID_MESSAGEBOX_SUCESSO, "Êxito", "Produto removido com sucesso.");

            Then.naTelaDeListagem
            .listaDeProdutosEhCarregada();

            Then.iTeardownMyApp();
		});
	});
});
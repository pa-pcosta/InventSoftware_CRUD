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
    const DESCRICAO_REGISTRO_TESTE = "TESTE OPA";

	QUnit.module("DETALHES DE PRODUTO DE TAPECARIA", () => {
        
        opaTest("Deve exibir tela de detalhes", (Given, When, Then) => {

            Given.iStartMyApp({
                hash: "detalhes/35"
            });

            Then.naTelaDeDetalhes
            .paginaDeDetalhesEhCarregada (DESCRICAO_REGISTRO_TESTE);
        });

        opaTest("Deve navegar para tela de listagem", (Given, When, Then) => {

			When.naTelaDeDetalhes
			.botaoVoltarEhPressionado();

			Then.naTelaDeListagem
			.listaDeProdutosEhCarregada();

            When.naTelaDeListagem
            .oUltimoItemDaListaEhSelecionado();

            Then.naTelaDeDetalhes
            .paginaDeDetalhesEhCarregada (DESCRICAO_REGISTRO_TESTE);
		});

        opaTest("Deve navegar para tela de cadastro na rota de edição", (Given, When, Then) => {

			When.naTelaDeDetalhes
			.ehPressionadoBotao(ID_BOTAO_EDITAR);

			Then.naTelaDeCadastro
			.paginaDeCadastroEhCarregada();

            When.naTelaDeCadastro
            .ehPressionadoBotao("botaoVoltar")

            Then.naTelaDeDetalhes
            .paginaDeDetalhesEhCarregada (DESCRICAO_REGISTRO_TESTE);
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

            When.naTelaDeListagem
            .ehPesquisadoNoSearchField (DESCRICAO_REGISTRO_TESTE)

            Then.naTelaDeListagem
            .listaDeProdutosEhCarregada();

            Then.iTeardownMyApp();
		});
	});
});
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
            .paginaDeDetalhesEhCarregadaComRegistroEspecifico ("35");
        });

        opaTest("Deve navegar para tela de listagem", (Given, When, Then) => {

			When.naTelaDeDetalhes
			.botaoVoltarEhPressionado();

			Then.naTelaDeListagem
			.listaDeProdutosEhCarregadaComRegistros();

            When.naTelaDeListagem
            .oUltimoItemDaListaEhSelecionado();

            Then.naTelaDeDetalhes
            .paginaDeDetalhesEhCarregadaComRegistroCriado(DESCRICAO_REGISTRO_TESTE);
		});

        opaTest("Deve navegar para tela de cadastro na rota de edição", (Given, When, Then) => {

			When.naTelaDeDetalhes
			.ehPressionadoBotaoComTitulo("botaoEditar")

			Then.naTelaDeCadastro
			.paginaDeCadastroEhCarregadaComTitulo("tituloTelaCadastro")

            When.naTelaDeCadastro
            .ehPressionadoBotaoComIcone("sap-icon://nav-back")

            Then.naTelaDeDetalhes
            .paginaDeDetalhesEhCarregadaComRegistroCriado (DESCRICAO_REGISTRO_TESTE);
		});

        opaTest("Deve remover registro e navegar para tela de listagem", (Given, When, Then) => {

			When.naTelaDeDetalhes
			.ehPressionadoBotaoComTitulo("botaoDeletar");

			Then.naTelaDeDetalhes
			.messageBoxEhExibida(ID_MESSAGEBOX_CONFIRMACAO, "Após excluir o registro não será possível recuperar os dados. Deseja continuar?")
            .and
            .messageBoxEhExibida(ID_MESSAGEBOX_SUCESSO, "Produto removido com sucesso.");

            Then.naTelaDeListagem
            .listaDeProdutosEhCarregadaComRegistros();

            When.naTelaDeListagem
            .ehPesquisadoNoSearchField ("searchFieldPlaceholder", DESCRICAO_REGISTRO_TESTE)

            Then.naTelaDeListagem
            .listaDeProdutosEhCarregadaSemRegistros();

            Then.iTeardownMyApp();
		});
	});
});
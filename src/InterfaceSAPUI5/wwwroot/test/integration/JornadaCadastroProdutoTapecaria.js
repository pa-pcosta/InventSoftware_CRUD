sap.ui.define([
	"sap/ui/test/opaQunit",
	"./pages/CadastroProdutoTapecaria",
	"./pages/Listagem"
], (opaTest) => {
	"use strict";

	const ID_BOTAO_VOLTAR = "botaoVoltar";
	const ID_BOTAO_ADICIONAR = "botaoAdicionar";
	const ID_BOTAO_CANCELAR = "botaoCancelar";
	const ID_BOTAO_SALVAR = "botaoSalvar";

	QUnit.module("Cadastro de produto de tapecaria", () => {

		opaTest("Deve exibir tela de CADASTRO", (Given, When, Then) => {

			Given.iStartMyUIComponent({
				componentConfig: {
					name: "ui5.controle_de_estoque"
				}
			});

			When.naTelaDeListagem
			.ehPressionadoBotao("botaoAdicionar");

			Then.naTelaDeCadastro
			.paginaDeCadastroEhCarregada ();
		});

		// opaTest("Deve retornar para tela de LISTAGEM", (Given, When, Then) => {

		// 	When.naTelaDeCadastro
		// 	.ehPressionadoBotao(ID_BOTAO_VOLTAR);

		// 	Then.naTelaDeListagem
		// 	.listaDeProdutosEhCarregada();

		// 	When.naTelaDeListagem
		// 	.ehPressionadoBotao(ID_BOTAO_ADICIONAR);

		// 	Then.naTelaDeCadastro
		// 	.paginaDeCadastroEhCarregada();
		// });

		// opaTest("Deve cancelar cadastro e retornar para tela de LISTAGEM", (Given, When, Then) => {

		// 	When.naTelaDeCadastro
		// 	.ehPressionadoBotao(ID_BOTAO_CANCELAR);

		// 	Then.naTelaDeListagem
		// 	.listaDeProdutosEhCarregada();

		// 	When.naTelaDeListagem
		// 	.ehPressionadoBotao(ID_BOTAO_ADICIONAR);

		// 	Then.naTelaDeCadastro
		// 	.paginaDeCadastroEhCarregada();
		// });

		opaTest("Deve retornar erro ao tentar cadastrar com formulário vazio", (Given, When, Then) => {

			When.naTelaDeCadastro
			.ehPressionadoBotao(ID_BOTAO_SALVAR);

			Then.naTelaDeCadastro
			.messageBoxDeErroEhExibida();
		});
	});
});
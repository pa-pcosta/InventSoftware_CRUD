sap.ui.define([], () => {
	"use strict";
	
    return {

        async obterDadosDoServidor (url){
            let resposta = await fetch(url);
            let dados = await resposta.json();
            
            return dados;
        },

        async enviarDadosParaServidor (url, metodoHttp, objetoBody){
            
            let resposta = 
                await fetch(url, {
                    method: metodoHttp,
                    body: JSON.stringify(novoProdutoTapecaria),
                    headers: {
                        "Content-type": "application/json; charset=UTF-8"
                    }
                })

            
        }
	};
});

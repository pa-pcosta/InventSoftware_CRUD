sap.ui.define([], () => {
	"use strict";
	
    return {

        obterDadosDoServidor: async function (url){
            return fetch(url)
            .then(resposta => this.lerResposta(resposta));
        },

        enviarDadosParaServidor (url, metodoHttp, objetoBody){
            
            return fetch(url, {
                method: metodoHttp,
                body: JSON.stringify(objetoBody),
                headers: {
                    "Content-type": "application/json; charset=UTF-8"
                }
            })
            .then(resposta => this.lerResposta(resposta));
        },

        lerResposta(resposta){
            if(resposta.status == 400) return Promise.reject("Erro na requisição");
            if(resposta.status == 404) return Promise.reject("Recurso não encontrado");
 
            return resposta.json();
        }
	};
});

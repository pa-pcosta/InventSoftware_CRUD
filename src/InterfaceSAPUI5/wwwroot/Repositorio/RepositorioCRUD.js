sap.ui.define([], () => {
	"use strict";
    const urlApiTapecaria = "api/Tapecaria";
	
    return {
        
        criar(produtoTapecaria)
        {
            return fetch(urlApiTapecaria, {
                method: 'POST',
                body: JSON.stringify(produtoTapecaria),
                headers: {
                    "Content-type": "application/json; charset=UTF-8"
                }
            })
            .then(resposta => this.lerResposta(resposta));
        },

        obterTodos(filtro)
        {
            let url = urlApiTapecaria;

            if (filtro){
                url += filtro;
            }

            return fetch(url)
            .then(resposta => this.lerResposta(resposta));
        },

        obterPorId(id)
        {
            let url = `${urlApiTapecaria}/${id}`;

            return fetch(url)
            .then(resposta => this.lerResposta(resposta));
        },

        obterEnumTipoTapecaria()
        {
            let url = urlApiTapecaria + "/enumTipoTapecaria";

            return fetch(url)
            .then(resposta => this.lerResposta(resposta));
        },

        atualizar(produtoTapecaria)
        {
            return fetch(urlApiTapecaria, {
                method: 'PUT',
                body: JSON.stringify(produtoTapecaria),
                headers: {
                    "Content-type": "application/json; charset=UTF-8"
                }
            })
            .then(resposta => this.lerResposta(resposta));
        },

        remover(id)
        {
            let url = `${urlApiTapecaria}/${id}`;

            return fetch(url, {
                method: 'DELETE',
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

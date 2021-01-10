using System;
using System.Collections.Generic;
using System.Text;

namespace BelezaNaWeb.Application.DTOs
{
    public class ResponseDTO<TEntity>
    {
        public ResponseDTO() { }
        public ResponseDTO(int statusCode, string mensagem, TEntity body, Object erro)
        {
            StatusCode = statusCode;
            Mensagem = mensagem;
            Body = body;
            Erro = erro;
        }

        public int StatusCode { get; set; }
        public string Mensagem { get; set; }
        public TEntity Body { get; set; }
        public Object Erro { get; set; }
    }
}
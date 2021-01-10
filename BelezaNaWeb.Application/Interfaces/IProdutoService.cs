using BelezaNaWeb.Application.DTOs;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BelezaNaWeb.Application.Interfaces
{
    public interface IProdutoService
    {
        Task<ProdutoDTO> CadastrarProduto(ProdutoDTO produtoDTO);
        Task<ProdutoDTO> AtualizarProduto(ProdutoDTO produtoDTO);
        Task<ProdutoDTO> DeletarProduto(ProdutoDTO produtoDTO);
        Task<ProdutoDTO> ObterProduto(ProdutoDTO produtoDTO);
    }
}

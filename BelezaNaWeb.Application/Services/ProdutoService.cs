using AutoMapper;
using BelezaNaWeb.Application.DTOs;
using BelezaNaWeb.Application.Interfaces;
using BelezaNaWeb.Domain.Entities;
using BelezaNaWeb.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BelezaNaWeb.Application.Services
{
    public class ProdutoService : IProdutoService
    {
        private readonly IProdutoRepository iProdutoRepository;
        private readonly IMapper iMapper;

        public ProdutoService(IProdutoRepository iProdutoRepository, IMapper iMapper)
        {
            this.iProdutoRepository = iProdutoRepository;
            this.iMapper = iMapper;
        }

        #region async Task<ProdutoDTO> ObterProduto(ProdutoDTO produtoDTO)
        public async Task<ProdutoDTO> ObterProduto(ProdutoDTO produtoDTO)
        {
            ProdutoEntity produtoEntity = await iProdutoRepository.GetByIdCompletAsync(produtoDTO.Sku);
            if (produtoEntity == null)
                return null;

            if (produtoEntity.IsMarketable)
            {
                produtoEntity.ProdutoInventarioEntity.Quantity += -1;

                produtoEntity.IsMarketable = produtoEntity.ProdutoInventarioEntity.Quantity > 0;

                produtoEntity.ProdutoInventarioEntity.ProdutoArmazemEntities
                    .OrderByDescending(a => a.Quantity)
                    .FirstOrDefault()
                    .Quantity += -1;

                await iProdutoRepository.Update(produtoEntity);
            }


            return iMapper.Map<ProdutoDTO>(produtoEntity);
        }
        #endregion

        #region async Task<ProdutoDTO> CadastrarProduto(ProdutoDTO produtoDTO)
        public async Task<ProdutoDTO> CadastrarProduto(ProdutoDTO produtoDTO)
        {
            ProdutoEntity produtoEntity = await iProdutoRepository.GetByIdAsync(produtoDTO.Sku);
            if (produtoEntity != null)
                return null;

            produtoEntity = iMapper.Map<ProdutoEntity>(produtoDTO);
            produtoEntity = await iProdutoRepository.Insert(produtoEntity);

            return iMapper.Map<ProdutoDTO>(produtoEntity);
        }
        #endregion

        #region async Task<ProdutoDTO> AtualizarProduto(ProdutoDTO produtoDTO)
        public async Task<ProdutoDTO> AtualizarProduto(ProdutoDTO produtoDTO)
        {
            ProdutoEntity produtoEntity = await iProdutoRepository.GetByIdAsync(produtoDTO.Sku);
            if (produtoEntity == null)
                return null;

            produtoEntity = iMapper.Map<ProdutoEntity>(produtoDTO);
            produtoEntity = await iProdutoRepository.Update(produtoEntity);

            return iMapper.Map<ProdutoDTO>(produtoEntity);
        }
        #endregion

        #region async Task<ProdutoDTO> DeletarProduto(ProdutoDTO produtoDTO)
        public async Task<ProdutoDTO> DeletarProduto(ProdutoDTO produtoDTO)
        {
            ProdutoEntity produtoEntity = await iProdutoRepository.GetByIdAsync(produtoDTO.Sku);
            if (produtoEntity == null)
                return null;

            produtoEntity = await iProdutoRepository.Delete(produtoEntity);

            return iMapper.Map<ProdutoDTO>(produtoEntity);
        } 
        #endregion
    }
}

using BelezaNaWeb.Domain.Entities;
using BelezaNaWeb.Domain.Interfaces;
using BelezaNaWeb.Infraestructure.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BelezaNaWeb.Infraestructure.Repositories
{
    public class ProdutoRepository: BaseRepository<ProdutoEntity>, IProdutoRepository
    {
        private readonly BelezaNaWebContext belezaNaWebContext;
        public ProdutoRepository(BelezaNaWebContext belezaNaWebContext): base(belezaNaWebContext)
        {
            this.belezaNaWebContext = belezaNaWebContext;
        }

        public async Task<ProdutoEntity> GetByIdCompletAsync(string id)
        {
            ProdutoEntity produtoEntity = await belezaNaWebContext.Set<ProdutoEntity>()
                .Include(i => i.ProdutoInventarioEntity)
                .Include(i => i.ProdutoInventarioEntity.ProdutoArmazemEntities)
                .FirstOrDefaultAsync(f => f.Sku == id);

            return produtoEntity;
        }
    }
}

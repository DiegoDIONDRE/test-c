using BelezaNaWeb.Domain.Entities;
using BelezaNaWeb.Domain.Interfaces;
using BelezaNaWeb.Infraestructure.Context;
using System;
using System.Collections.Generic;
using System.Text;

namespace BelezaNaWeb.Infraestructure.Repositories
{
    public class ProdutoArmazemRepository: BaseRepository<ProdutoArmazemEntity>, IProdutoArmazemRepository
    {
        private readonly BelezaNaWebContext belezaNaWebContext;

        public ProdutoArmazemRepository(BelezaNaWebContext belezaNaWebContext): base(belezaNaWebContext)
        {
            this.belezaNaWebContext = belezaNaWebContext;
        }
    }
}

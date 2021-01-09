using BelezaNaWeb.Domain.Entities;
using BelezaNaWeb.Domain.Interfaces.Repositories;
using BelezaNaWeb.Infraestructure.Context;
using System;
using System.Collections.Generic;
using System.Text;

namespace BelezaNaWeb.Infraestructure.Repositories
{
    public class ProdutoRepository: BaseRepository<ProdutoEntity>, IProdutoRepository
    {
        private readonly BelezaNaWebContext belezaNaWebContext;
        public ProdutoRepository(BelezaNaWebContext belezaNaWebContext): base(belezaNaWebContext)
        {
            this.belezaNaWebContext = belezaNaWebContext;
        }
    }
}

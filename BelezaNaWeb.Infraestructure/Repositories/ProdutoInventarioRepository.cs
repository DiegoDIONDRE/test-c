using BelezaNaWeb.Domain.Entities;
using BelezaNaWeb.Domain.Interfaces.Repositories;
using BelezaNaWeb.Infraestructure.Context;
using System;
using System.Collections.Generic;
using System.Text;

namespace BelezaNaWeb.Infraestructure.Repositories
{
    public class ProdutoInventarioRepository: BaseRepository<ProdutoInventarioEntity>, IProdutoInventarioRepository
    {
        private readonly BelezaNaWebContext belezaNaWebContext;

        public ProdutoInventarioRepository(BelezaNaWebContext belezaNaWebContext): base(belezaNaWebContext)
        {
            this.belezaNaWebContext = belezaNaWebContext;
        }
    }
}

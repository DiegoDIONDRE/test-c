using BelezaNaWeb.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BelezaNaWeb.Domain.Interfaces
{
    public interface IProdutoRepository: IBaseRepository<ProdutoEntity>
    {
        Task<ProdutoEntity> GetByIdCompletAsync(string id);
    }
}

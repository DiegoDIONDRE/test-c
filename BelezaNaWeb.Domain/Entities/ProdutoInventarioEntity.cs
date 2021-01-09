using System;
using System.Collections.Generic;
using System.Text;

namespace BelezaNaWeb.Domain.Entities
{
    public class ProdutoInventarioEntity: BaseEntity
    {
        public int Quantity { get; set; }
        public bool IsMarketable { get; set; }
        
        public virtual ProdutoEntity ProdutoEntity { get; set; }
        public virtual ICollection<ProdutoArmazemEntity> ProdutoArmazemEntities { get; set; }
    }
}

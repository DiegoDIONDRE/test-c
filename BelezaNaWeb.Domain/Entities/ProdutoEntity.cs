using System;
using System.Collections.Generic;
using System.Text;

namespace BelezaNaWeb.Domain.Entities
{
    public class ProdutoEntity: BaseEntity
    {
        public string Name { get; set; }

        public virtual ProdutoInventarioEntity ProdutoInventarioEntity { get; set; }
        public virtual ICollection<ProdutoArmazemEntity> ProdutoArmazemEntities { get; set; }
    }
}

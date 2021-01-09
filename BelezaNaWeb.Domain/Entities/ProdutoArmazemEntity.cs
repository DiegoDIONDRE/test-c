using System;
using System.Collections.Generic;
using System.Text;

namespace BelezaNaWeb.Domain.Entities
{
    public class ProdutoArmazemEntity: BaseEntity
    {
        public string Locality { get; set; }
        public int Quantity { get; set; }
        public string Type { get; set; }

        public virtual ProdutoInventarioEntity ProdutoInventarioEntity { get; set; }
    }
}

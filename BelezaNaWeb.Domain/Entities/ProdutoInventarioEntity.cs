using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace BelezaNaWeb.Domain.Entities
{
    public class ProdutoInventarioEntity: BaseEntity
    {
        public int Quantity { get; set; }

        [ForeignKey("Sku")]
        public virtual ProdutoEntity ProdutoEntity { get; set; }
        public virtual ICollection<ProdutoArmazemEntity> ProdutoArmazemEntities { get; set; }

    }
}

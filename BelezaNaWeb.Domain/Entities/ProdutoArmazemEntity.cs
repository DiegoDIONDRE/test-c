using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace BelezaNaWeb.Domain.Entities
{
    public class ProdutoArmazemEntity: BaseEntity
    {
        [Key]
        [Column(Order = 1)]
        public string Type { get; set; }

        [Key]
        [Column(Order = 2)]
        public string Locality { get; set; }
        public int Quantity { get; set; }

        [ForeignKey("Sku")]
        public virtual ProdutoInventarioEntity ProdutoInventarioEntity { get; set; }
    }
}

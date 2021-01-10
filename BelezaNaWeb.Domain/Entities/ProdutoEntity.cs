using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace BelezaNaWeb.Domain.Entities
{
    public class ProdutoEntity: BaseEntity
    {
        public string Name { get; set; }
        public bool IsMarketable { get; set; }

        public virtual ProdutoInventarioEntity ProdutoInventarioEntity { get; set; }
    }
}

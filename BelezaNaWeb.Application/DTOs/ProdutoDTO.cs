using System;
using System.Collections.Generic;
using System.Text;

namespace BelezaNaWeb.Application.DTOs
{
    public class ProdutoDTO: BaseDTO
    {
        public string Name { get; set; }
        public ProdutoInventarioDTO Inventory { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Text;

namespace BelezaNaWeb.Application.DTOs
{
    public class ProdutoInventarioDTO: BaseDTO
    {
        public int Quantity { get; set; }
        public bool IsMarketable { get; set; }

        public List<ProdutoArmazemDTO> Warehouses { get; set; }
    }
}

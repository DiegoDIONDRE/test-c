using System;
using System.Collections.Generic;
using System.Text;

namespace BelezaNaWeb.Application.DTOs
{
    public class ProdutoArmazemDTO: BaseDTO
    {
        public string Locality { get; set; }
        public int Quantity { get; set; }
        public string Type { get; set; }
    }
}

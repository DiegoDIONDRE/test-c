using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace BelezaNaWeb.Application.DTOs
{
    public class ProdutoDTO: BaseDTO
    {
        [Required(ErrorMessage = "Campo {0} obrigatório!")] public string Sku { get; set; }
        [Required(ErrorMessage = "Campo {0} obrigatório!")] public string Name { get; set; }
        public ProdutoInventarioDTO Inventory { get; set; }
        public bool IsMarketable { get; set; }
    }
}

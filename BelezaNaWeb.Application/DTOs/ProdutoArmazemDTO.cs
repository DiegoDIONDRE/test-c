using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace BelezaNaWeb.Application.DTOs
{
    public class ProdutoArmazemDTO: BaseDTO
    {
        [Required(ErrorMessage = "Campo {0} obrigatório")] 
        [StringLength(35, ErrorMessage = "Campo {0} aceita somente {1} caracteres")]
        public string Locality { get; set; }

        [Required(ErrorMessage = "Campo {0} obrigatório")] 
        public int Quantity { get; set; }

        [Required(ErrorMessage = "Campo {0} obrigatório")]
        [StringLength(50, ErrorMessage = "Campo {0} aceita somente {1} caracteres")]
        public string Type { get; set; }
    }
}

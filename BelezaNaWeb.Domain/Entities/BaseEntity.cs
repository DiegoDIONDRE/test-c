using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace BelezaNaWeb.Domain.Entities
{
    public abstract class BaseEntity
    {
        [Key]
        public string Sku { get; set; }
    }
}

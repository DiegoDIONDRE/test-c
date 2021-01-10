using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace BelezaNaWeb.Domain.Entities
{
    public abstract class BaseEntity
    {
        [Key, Column(Order = 0)]
        public string Sku { get; set; }
    }
}

using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace store.DataLayer.Model
{
    public class Sale
    {
        [Key]
        public Guid Id { get; set; }
        public Guid ProductId { get; set; }
        public int Quantity { get; set; }
        public DateTime? LastModifiedDate { get; set; }
        [MaxLength(100)]
        public string? LastModifiedUser { get; set; }
    }
}

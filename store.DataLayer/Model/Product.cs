using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace store.DataLayer.Model
{
    public  class Product
    {
        [Key]
        public Guid Id { get; set; }
        public Guid CategoryId { get; set; }
        public string? ProductCode { get; set; }
        [MaxLength(100)]
        public string Name { get; set; }
        [MaxLength(500)]
        public string Description { get; set; }
        [Column(TypeName = "decimal(18,2)")]
        public decimal Price { get; set; }
        public int Quantity { get; set; }        
        public DateTime? LastModifiedDate { get; set; }
        [MaxLength(100)]
        public string? LastModifiedUser { get; set; }
    }
}

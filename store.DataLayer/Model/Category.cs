using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace store.DataLayer.Model
{
    public class Category
    {
        public Guid Id { get; set; }
        [MaxLength(100)]
        public string Name { get; set; }
        [MaxLength(500)]
        public string Description { get; set; }
        public DateTime? LastModifiedDate { get; set; }
        [MaxLength(100)]
        public string? LastModifiedUser { get; set; }
        public List<Product> Products { get; set; }
    }

}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace store.DataLayer.Model
{
    public class ProductCategory
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime? LastModifiedDate { get; set; }
        [MaxLength(100)]
        public string? LastModifiedUser { get; set; }
    }
}
}

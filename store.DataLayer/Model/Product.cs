using System.ComponentModel.DataAnnotations;

namespace store.DataLayer.Model
{
    public  class Product
    {
        [Key]
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public int Quantity { get; set; }
    }
}

using System.ComponentModel.DataAnnotations;

namespace store.DataLayer.Model
{
    public class Customer
    {
        
        public Guid Id { get; set; }
        [MaxLength(100)]
        public string FirstName { get; set; }
        [MaxLength(100)]
        public string LastName { get; set; }
        [MaxLength(500)]
        public string Email { get; set; }
        [MaxLength(100)]
        public string Address { get; set; }
        [MaxLength(100)]
        public string Phone { get; set; }
        public DateTime? LastModifiedDate { get; set; }
        [MaxLength(100)]
        public string? LastModifiedUser { get; set; }
        public List<Order> Orders { get; set; }
    }
}


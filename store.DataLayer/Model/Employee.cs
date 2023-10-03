using System.ComponentModel.DataAnnotations;

namespace store.DataLayer.Model
{
    public class Employee
    {
        public Guid Id { get; set; }
        [MaxLength(13)]
        [MinLength(13)]
        public string? IdNr { get; set; }
        public string? PassportNr { get; set; }
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
    }
}

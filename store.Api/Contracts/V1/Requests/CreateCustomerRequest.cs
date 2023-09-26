using System.ComponentModel.DataAnnotations;

namespace store.Api.Contracts.V1.Requests
{
    public class CreateCustomerRequest
    {

        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
     
        public string Phone { get; set; }
       
        public string? LastModifiedUser { get; set; }
    }
}

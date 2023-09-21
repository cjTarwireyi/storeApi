using store.DataLayer.Model;
using System.ComponentModel.DataAnnotations;

namespace store.Api.Contracts.V1.Responses
{
    public class GetCategoryResponse
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime? LastModifiedDate { get; set; }
        public string? LastModifiedUser { get; set; }
    }
}

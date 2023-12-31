﻿namespace store.Api.Contracts.V1.Responses
{
    public class GetCategoryResponse
    {
        public string? Name { get; set; }
        public string? Description { get; set; }    
        public Guid Id { get; set; }

        public DateTime? LastModifiedDate { get; set; }
        public string? LastModifiedUser { get; set; }
    }
}

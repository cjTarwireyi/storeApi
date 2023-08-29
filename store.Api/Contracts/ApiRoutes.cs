namespace store.Api.Contracts
{
    public static class ApiRoutes
    {
        private const string root = "api";
        private const string version = "v1";
        private const  string Base = $"{root}/{version}";
        public static class Products
        {
            public const string GetAll = $"{Base}/products/";
        
            public const string Get ="{productId}";
        }
    }
}

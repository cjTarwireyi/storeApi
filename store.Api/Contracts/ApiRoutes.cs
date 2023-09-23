namespace store.Api.Contracts
{
    public static class ApiRoutes
    {
        private const string root = "api";
        private const string version = "v1";
        private const  string Base = $"{root}/{version}";
        public static class Products
        {
            public const string GetAll = $"{Base}/product/";
        
            public const string Get ="{productId}";
        }
        public static class Category
        {
            public const string GetAll = $"{Base}/category/";
        
            public const string Get ="{categoryId}";
        }
        public static class Order
        {
            public const string GetAll = $"{Base}/order/";
        
            public const string Get ="{orderId}";
        }
    }
}

namespace store.Api.Contracts
{
    public static class ApiRoutes
    {
        private const string root = "api";
        private const string version = "v1";
        private const  string Base = $"{root}/{version}";
        public static class ProductsRoutes
        {
            public const string GetAll = $"{Base}/product/";
        
            public const string Get ="{productId}";
        }
        public static class CategoryRoutes
        {
            public const string GetAll = $"{Base}/category/";
        
            public const string Get ="{categoryId}";
        }
        public static class OrderRoutes
        {
            public const string GetAll = $"{Base}/order/";
        
            public const string Get ="{orderId}";
        }
        public static class CustomerRoutes
        {
            public const string GetAll = $"{Base}/customer/";
        
            public const string Get ="{customerId}";
        }
    }
}

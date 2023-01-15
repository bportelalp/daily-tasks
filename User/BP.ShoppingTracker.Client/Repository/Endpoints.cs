namespace BP.ShoppingTracker.Client.Repository
{
    public static class EndpointProduct
    {
        public const string ProductController = "api/product";
        public const string ProductCategory = ProductController + "/product-category";
        public const string ProductType = ProductController + "/product-type";
        public const string MeasureType = ProductController + "/measure-type";
        public const string FormatType = ProductController + "/format-type";
        public const string Format = ProductController + "/format";
        public const string Company = ProductController + "/company";
        public const string Brand = ProductController + "/brand";
    }

    public static class EndpointAccounts
    {
        public const string AccountController = "api/accounts";
        public const string Users = AccountController + "/users";
        public const string Roles = AccountController + "/roles";
        public const string SetUserRole = AccountController + "/set-user-role";
        public const string RemoveUserRole = AccountController + "/remove-user-role";
        public const string CreateUser = AccountController + "/create-user";
        public const string Login = AccountController + "/login";
    }
}

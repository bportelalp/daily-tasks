namespace BP.ShoppingTracker.U50.Client.Repository
{
    public struct EndpointProduct
    {
        public static readonly string ENDPOINT_PRODUCT = "api/product";
        public static readonly string PRODUCT_CATEGORY = ENDPOINT_PRODUCT + "/product-category";
        public static readonly string PRODUCT_TYPE = ENDPOINT_PRODUCT + "/product-type";
        public static readonly string MEASURE_TYPE = ENDPOINT_PRODUCT + "/measure-type";
        public static readonly string FORMAT_TYPE = ENDPOINT_PRODUCT + "/format-type";
        public static readonly string FORMAT = ENDPOINT_PRODUCT + "/format";
        public static readonly string COMPANY = ENDPOINT_PRODUCT + "/company";
        public static readonly string BRAND = ENDPOINT_PRODUCT + "/brand";
    }

    public struct EndpointAccounts
    {
        public static readonly string ENDPOINT_ACCOUNTS = "api/accounts";
        public static readonly string CREATE_USER = ENDPOINT_ACCOUNTS + "/create-user";
        public static readonly string LOGIN = ENDPOINT_ACCOUNTS + "/login";

    }
}

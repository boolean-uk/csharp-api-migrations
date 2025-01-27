namespace exercise.pizzashopapi.Enums
{
    public enum ProductType
    {
        Pizza,
        Burger,
        Fries,
        Drinks
    }

    public static class ProductInfo
    {
        public static Dictionary<ProductType, Tuple<int, int>> ProductPrepTimes = new Dictionary<ProductType, Tuple<int, int>>
        {
            { ProductType.Pizza, new Tuple<int, int>(3, 12) },
            { ProductType.Burger, new Tuple<int, int>(2, 10) },
            { ProductType.Fries, new Tuple<int, int>(0, 10) },
            { ProductType.Drinks, new Tuple<int, int>(1, 0) },
        };

    }
}

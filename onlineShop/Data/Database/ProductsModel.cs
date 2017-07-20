namespace onlineShop.Data.Database
{
    using System.Data.Entity;

    public class ProductsModel : DbContext
    {
        // Your context has been configured to use a 'ProductsModel' connection string from your application's 
        // configuration file (App.config or Web.config). By default, this connection string targets the 
        // 'onlineShop.Data.Database.ProductsModel' database on your LocalDb instance. 
        // 
        // If you wish to target a different database and/or database provider, modify the 'ProductsModel' 
        // connection string in the application configuration file.
        public ProductsModel()
            : base("name=ProductsModel")
        {
        }

        public virtual DbSet<Products.Product> Products { get; set; }
    }
}
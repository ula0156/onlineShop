namespace onlineShop.Data.Database
{
    using Entities;
    using System.Data.Entity;

    public class StocksModel : DbContext
    {
        // Your context has been configured to use a 'StocksModel' connection string from your application's 
        // configuration file (App.config or Web.config). By default, this connection string targets the 
        // 'onlineShop.Data.Database.StocksModel' database on your LocalDb instance. 
        // 
        // If you wish to target a different database and/or database provider, modify the 'StocksModel' 
        // connection string in the application configuration file.
        public StocksModel()
            : base("name=StocksModel")
        {
        }

        // Add a DbSet for each entity type that you want to include in your model. For more information 
        // on configuring and using a Code First model, see http://go.microsoft.com/fwlink/?LinkId=390109.

        public virtual DbSet<Stock> Stocks { get; set; }
    }
}
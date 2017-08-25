namespace onlineShop.Data.Database
{
    using Entities;
    using onlineShop.core.Entities;
    using System.Data.Entity;

    public class ReservationsModel : DbContext
    {
        // Your context has been configured to use a 'ReservationsModel' connection string from your application's 
        // configuration file (App.config or Web.config). By default, this connection string targets the 
        // 'onlineShop.Data.Database.ReservationsModel' database on your LocalDb instance. 
        // 
        // If you wish to target a different database and/or database provider, modify the 'ReservationsModel' 
        // connection string in the application configuration file.
        public ReservationsModel()
            : base("name=ReservationsModel")
        {
        }

        // Add a DbSet for each entity type that you want to include in your model. For more information 
        // on configuring and using a Code First model, see http://go.microsoft.com/fwlink/?LinkId=390109.

        public virtual DbSet<Reservation> Reservations { get; set; }
        public virtual DbSet<Session> Sessions { get; set; }
        public virtual DbSet<Cart> Carts { get; set; }
    }
}

    
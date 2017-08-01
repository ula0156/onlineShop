using onlineShop.Data;
using onlineShop.Data.Database;
using onlineShop.Data.InMemory;
using onlineShop.Managers;
using onlineShop.Pages;
using onlineShop.Specials;
using System;

namespace onlineShop.App
{
    public static class Application
    {
        private static readonly bool _useInMemoryDatabase = false;
        private static readonly bool _initializeDatabase = false;

        private static void CreateInMemoryProviders(
            out IProductsProvider productsProvider, 
            out IReservationsProvider reservationsProvider, 
            out IStocksProvider stocksProvider)
        {
            // create in-memory databases
            var productsRepository = new InMemoryProductsRepository();
            var stocksRepository = new InMemoryStocksRepository();
            var reservationsRepository = new InMemoryReservationsRepository();

            productsProvider = new InMemoryProductsProvider(productsRepository);
            stocksProvider = new InMemoryStocksProvider(stocksRepository);
            reservationsProvider = new InMemoryReservationProvider(reservationsRepository);
        }

        private static void CreateDatabaseProviders(
            out IProductsProvider productsProvider,
            out IReservationsProvider reservationsProvider,
            out IStocksProvider stocksProvider)
        {
            productsProvider = new DBProductsProvider();
            reservationsProvider = new DBReservationsProvider();
            stocksProvider = new DBStocksProvider();
        }

        public static void Run()
        {
            // Create providers.
            IProductsProvider productsProvider;
            IReservationsProvider reservationsProvider;
            IStocksProvider stocksProvider;

            if (_useInMemoryDatabase)
            {
                CreateInMemoryProviders(out productsProvider, out reservationsProvider, out stocksProvider);
            }
            else
            {
                CreateDatabaseProviders(out productsProvider, out reservationsProvider, out stocksProvider);
            }
            
            // Create additional objects on top of the database.
            var productsManager = new ProductsManager(productsProvider, stocksProvider);

            // Initialize the database so it is not empty when qwe launch the application.
            if (_initializeDatabase)
            {
                DatabaseInitializer databaseInitializer = new DatabaseInitializer();
                databaseInitializer.InitializeDatabase(productsManager);
            }
            
            // has methods to act on databases through productsProvider and stocksProvider
            var reservationsManager = new ReservationsManager(stocksProvider, reservationsProvider);
           
            Cart cart = new Cart(productsProvider, reservationsManager);
            NavigationData navData = new NavigationData();
            ExpiredReservationsManager expiredReservationsManager = new ExpiredReservationsManager(reservationsProvider);
            navData.ProductsReader = productsProvider;
            navData.StocksReader = stocksProvider;
            navData.Cart = cart;

            IPage currentPage = new MainPage();
            while (currentPage != null)
            {
                string menu = currentPage.OnNavigatedTo(navData);
                Console.WriteLine(menu);

                string userInput = Console.ReadLine();
                var newPage = currentPage.OnUserInput(userInput);
                navData.PreviousPages.Push(currentPage);
                currentPage = newPage;

                Console.Clear();
            }
        }
    }
}

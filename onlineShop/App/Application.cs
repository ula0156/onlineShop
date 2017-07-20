using onlineShop.App;
using onlineShop.Data;
using onlineShop.Data.InMemory;
using onlineShop.Managers;
using onlineShop.Pages;
using onlineShop.Reservations;
using System;

namespace onlineShop.App
{
    public static class Application
    {
        public static void Run()
        {
            // create in-memory databases
            DatabaseInitializer inventoryReader = new DatabaseInitializer();
            var productsProvider = new InMemoryProductsProvider(inventoryReader.Descriptions);
            var stocksProvider = new InMemoryStocksProvider(inventoryReader.Stocks);

            // has methods to act on databases through productsProvider and stocksProvider
            var productsManager = new ProductsManager(productsProvider, stocksProvider);
            var reservationsProvider = new InMemoryReservationProvider(new InMemoryReservationsRepository());
            var reservationsManager = new ReservationsManager(stocksProvider, reservationsProvider);
           
            Cart cart = new Cart(productsProvider, reservationsManager);
            NavigationData navData = new NavigationData();
            navData.Cart = cart;
            navData.ProductsReader = productsProvider;
            navData.StocksReader = stocksProvider;

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

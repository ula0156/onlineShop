using onlineShop.App;
using OnlineShop.Data;
using OnlineShop.Pages;
using OnlineShop.Reservations;
using System;

namespace OnlineShop.App
{
    public static class Application
    {
        public static void Run()
        {
            InventoryReader inventoryReader = new InventoryReader();
            ProductsDescriptions productDescriptions = inventoryReader.Descriptions;
            ProductsStocks productStocks = inventoryReader.Stocks;

            ReservedInventory reservedInventory = new ReservedInventory();
            ReservationManager reservationManager = new ReservationManager(productStocks, reservedInventory);
            Cart cart = new Cart(productDescriptions, reservationManager);
            NavigationData navData = new NavigationData();
            navData.Cart = cart;
            navData.ProductsDescriptions = productDescriptions;
            navData.Stocks = productStocks;

            IPage page = new MainPage();
            while (page != null)
            {
                string menu = page.OnNavigatedTo(navData);
                Console.WriteLine(menu);

                string userInput = Console.ReadLine();
                var newPage = page.OnUserInput(userInput);
                navData.PreviousPages.Push(page);
                page = newPage;

                Console.Clear();
            }
        }
    }
}

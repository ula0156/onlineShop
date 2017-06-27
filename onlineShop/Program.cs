using System;

namespace onlineShop
{
    class Program
    {
        // This is the main entry point in your application. This is where the program
        // starts executing code.
        static void Main(string[] args)
        {
            // We create an inventory and an empty cart to start with.
            Inventory inventory = new Inventory();
            Cart cart = new Cart();

            // The first page that we navigate when we launch the application is the 
            // main page
            // We declare the currentPage variable as IPage because it starts by
            // referencing a MainPage object, but after the user selects an option it
            // can reference a CartPage, or a ProductPage. 
            // This is where it is useful that all actual pages are also of type IPage
            // and that each IPage behaves the same in the sense that it has those 
            // 2 methods: GetContent and OnUserInput.
            IPage currentPage = new MainPage(inventory, cart);

            // We always repeat the same steps in order to navigate between pages.
            while (true)
            {
                // Get the content of the current page.
                string pageContent = currentPage.GetContent();

                // Display it for the user
                Console.WriteLine(pageContent);

                // Ask the user to enter his text.
                Console.Write("\nEnter your selection: ");

                // We read the text from the user.
                string userInput = Console.ReadLine();

                // We pass the text to the page in order to process it. The page
                // might do some action based on what the user selected and will return 
                // the new page that we have to navigate to.
                currentPage = currentPage.OnUserInput(userInput);

                // We add a separator before we go and display the content of the new page.
                Console.WriteLine("------------------");
            }
        }
    }
}
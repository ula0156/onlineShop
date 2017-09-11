# onlineShop

**1. Introduction**
----

This project implements an online shop for books and music.

Following functionalities are available:

- User registration.
- Searching for a particular product.
- Session and cart management. 

Checkout is not currently implemented.

**2. Tools and technologies used**:
----
	- Visual Studio 2017
	- Web frameworks
		- Asp.NET MVC
		- Bootstrap
	- Database
		- Microsoft SQL Server
		- Entity Framework 6
	- Azure Web Apps
	
	
**3. Architecture**. 
------
**This solution consists of 2 projects: core and web.**
	
* **Core**

	Core implements data models, data access and most of the business logic.
	Following data models were implemented:
	- Reservations model
	- Carts model
	- Sessions model
	- Products model
	- Stocks model
	
	The factory method design pattern was used together with an interface abstraction layer in order to be easy to change the database technologies without requiring significant changes to the rest of the code.
	
	One of the core parts of the project is the business logic around product reservations. The products reservation system responsibility is to reserve a product for a certain amount of time when the customers adds the product to the cart, and remove the reservation if the checkout does not happen in time. 
	
	This ensures that the customers can reserve the products for some time, in case there is a high demand for that specific item, but also that the item does not get stuck into the cart of a customer that doesn't want to buy it anymore.
	
	When the customer will navigate to the checkout page, the system will try to renew all the reservations and will inform the customer in case of failure.
	
	The cart management happens separately from the reservations management. This makes sure that even if the product reservations expire, the user does not lose track of the items that it added to the cart. The carts are removed based on session inactivity.
	
* **Web** 

	The web project contains the HTTP specific code: models, views and controllers.
	
			• Models:
				- Home View Model
				- Cart View Model
				- Search View Model
			• Views: 
				 - Home view, displays main page  
				 - Books view, display list of available books
				 - Songs view, display list of available songs
				 - Cart view, display list of products added to the cart. 
			• Controllers:
				 - Home controller
				 - Books controller
				 - Songs controller
				 - Cart controller
				 - Search controller
				
**Future improvements**:

* Add checkout page
* Personalize content based on user purchase history as well as trends (currently we only update the content based on special occasions)
* Improve UI design
* Add admin page to manage products/promotions/stocks


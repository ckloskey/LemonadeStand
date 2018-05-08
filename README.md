# LemonadeStand

User Stories:

1. Weather system that includes a forecast and actual weather, so that I can get a predicted forecast for a day or week and then what the actual weather is on the given day.

2. Price of product as well as weather/temperature should affect demand, so that if the price is too high, sales will decrease, or if the price is too low, sales will increase, etc.

3. Each customer to be a separate object with its own chance of buying a glass of lemonade, so that how much lemonade is purchased and how much a customer is willing to pay will vary from customer to customer.

4. Game to be playable for at least seven days.

5. Daily profit or loss displayed at the end of each day, so that I know how much money my lemonade stand has made. I also want my total profit or loss to be a running total that is displayed at the end of each day, so that I know how much money my lemonade stand has made.

6. Connect console application to a database so that I can save “high scores” in the form of a player’s name and their final score (profit).

7. As a developer, I want to implement the SOLID design principles as well as C# best practices in my project, so that project is as well-designed as possible.
	7A. For the sake of open/closed principle, I had created a "supply" class for all ingredients a player can buy. This way, it was easier to to set different expiration dates for each ingredient object and left it open for more ingredient objects to be implemented in future development.
	7B. For the sake of Single responsibilty principle, I have made the methods in the UserInterface class more versatile to reduce the amount of code used and avoid having similar methods performing the same functionality.
	 For example, there are a few prompt for user input but each prompt can expect different valid responses. The ValidUserInput method takes in the user input and a list of valid options (specified when called and lists can be adjusted/changed later) to validate accordingly.
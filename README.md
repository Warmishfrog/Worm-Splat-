# WormSplatter
 
This is a programming exercise on Splatting Worms in C#.
The project makes use of "Window Forms", the graphical GUI class library included as a part of Microsoft .NET 

The project achieves the following features:
•Each worm has a length value that is initialised to a value of 100%
•Each worm has a Splat() method that takes an integer parameter between 0 and 100.
•When Splat() is called the length of the worm is reduced by a percentage of the worm's current length.
•Each worm colour has a minimum percentage they can achieve at which point they are "dead".
•When a worm is dead no further deductions are recorded but the Splat() method is still functional.
•The program creates a single list containing 5 of each type of worm.
•A Splat() method works for each worm and returns their current length
•Each worm has a button and status represented
•When the button is clicked a random value between 0 and 80 is generated and applied to the worm using the Splat() method.
•The length of the worm is updated with each press of the button.

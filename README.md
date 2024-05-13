# Recipe Manager

This is a simple console-based recipe manager written in C#. It allows users to enter the details of a recipe, including ingredients and steps, and perform various actions such as scaling the recipe, resetting quantities, clearing the recipe, and displaying the recipe.
## Features

- Enter the details of a recipe, including ingredients and steps.
- Display the full recipe in a neat format.
- Scale the recipe by a factor of 0.5 (half), 2 (double), or 3 (triple).
- Reset quantities to the original values.
- Clear all data to enter a new recipe.
- No persistence of user data between runs; data is stored in memory while the software is running.
## How to Use

1. Run the program.
2. Enter the name of the recipe.
3. Enter the number of ingredients.
4. For each ingredient, enter the name, quantity, and unit of measurement.
5. Enter the number of steps.
6. For each step, enter a description of what the user should do.
7. Once the recipe is entered, you can perform actions such as scaling, resetting, clearing, or displaying the recipe.
8. To exit the program, enter 'exit' when prompted for an action.

## Updates
Added Calorie Tracking: The application now tracks the total calories of a recipe and notifies users when it exceeds 300.
Enhanced User Interface: Added color highlights to menus and messages for improved readability and user experience

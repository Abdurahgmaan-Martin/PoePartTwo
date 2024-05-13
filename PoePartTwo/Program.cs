using System;
using System.Collections.Generic;

// Class to represent an ingredient
class Ingredient
{
    public string Name { get; set; } // Name of the ingredient
    public double Quantity { get; set; } // Quantity of the ingredient
    public string Unit { get; set; } // Unit of measurement for the ingredient
}

// Class to represent a recipe
class Recipe
{
    private List<Ingredient> originalIngredients; // Store original ingredients for reset

    public string Name { get; set; } // Name of the recipe
    public List<Ingredient> Ingredients { get; set; } // List of ingredients
    public List<string> Steps { get; set; } // List of steps

    // Constructor
    public Recipe()
    {
        Ingredients = new List<Ingredient>();
        Steps = new List<string>();
        originalIngredients = new List<Ingredient>();
    }

    // Method to add an ingredient to the recipe
    public void AddIngredient(string name, double quantity, string unit)
    {
        // Add the ingredient to the list of ingredients
        Ingredients.Add(new Ingredient { Name = name, Quantity = quantity, Unit = unit });
        // Store a copy of the ingredient for resetting
        originalIngredients.Add(new Ingredient { Name = name, Quantity = quantity, Unit = unit });
    }

    // Method to add a step to the recipe
    public void AddStep(string step)
    {
        // Add the step to the list of steps
        Steps.Add(step);
    }

    // Method to display the recipe
    public void Display()
    {
        Console.WriteLine($"Recipe: {Name}"); // Display the name of the recipe
        Console.WriteLine("Ingredients:");
        foreach (var ingredient in Ingredients)
        {
            Console.WriteLine($"- {ingredient.Quantity} {ingredient.Unit} of {ingredient.Name}");
        }

        Console.WriteLine("\nSteps:");
        for (int i = 0; i < Steps.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {Steps[i]}");
        }
    }

    // Method to scale the recipe by a factor
    public void Scale(double factor)
    {
        foreach (var ingredient in Ingredients)
        {
            ingredient.Quantity *= factor;
        }
    }

    // Method to reset the quantities of ingredients to their original values
    public void Reset()
    {
        for (int i = 0; i < Ingredients.Count; i++)
        {
            Ingredients[i].Quantity = originalIngredients[i].Quantity;
        }
    }

    // Method to clear the recipe
    public void Clear()
    {
        Ingredients.Clear();
        Steps.Clear();
    }
}
class Program
{
    static void Main(string[] args)
    {
        Recipe recipe = new Recipe();

        // Input recipe name
        Console.Write("Enter the name of the recipe: ");
        recipe.Name = Console.ReadLine();

        // Input number of ingredients
        Console.Write("Enter the number of ingredients: ");
        int numIngredients;
        while (!int.TryParse(Console.ReadLine(), out numIngredients) || numIngredients <= 0)
        {
            Console.WriteLine("Please enter a valid number greater than 0 for the number of ingredients.");
            Console.Write("Enter the number of ingredients: ");
        }

        // Input ingredients
        for (int i = 0; i < numIngredients; i++)
        {
            Console.Write("Enter ingredient name: ");
            string name = Console.ReadLine();

            double quantity;
            while (true)
            {
                Console.Write("Enter quantity: ");
                if (double.TryParse(Console.ReadLine(), out quantity) && quantity > 0)
                {
                    break;
                }
                else
                {
                    Console.WriteLine("Please enter a valid quantity greater than 0.");
                }
            }

            Console.Write("Enter unit of measurement: ");
            string unit = Console.ReadLine();

            recipe.AddIngredient(name, quantity, unit);
        }// Input number of steps
        Console.Write("Enter the number of steps: ");
        int numSteps;
        while (!int.TryParse(Console.ReadLine(), out numSteps) || numSteps <= 0)
        {
            Console.WriteLine("Please enter a valid number greater than 0 for the number of steps.");
            Console.Write("Enter the number of steps: ");
        }

        // Input steps
        for (int i = 0; i < numSteps; i++)
        {
            Console.Write($"Enter step {i + 1}: ");
            string step = Console.ReadLine();
            recipe.AddStep(step);
        }
        // Display recipe
        Console.WriteLine();
        recipe.Display();

        // Handle user actions
        while (true)
        {
            Console.WriteLine("\nEnter 'scale', 'reset', 'clear', 'display' or 'exit': ");
            string action = Console.ReadLine().ToLower();

            switch (action)
            {
                case "scale":
                    double factor;
                    while (true)
                    {
                        Console.Write("Enter scale factor (0.5, 2, or 3): ");
                        string input = Console.ReadLine();
                        if (double.TryParse(input, out factor) && (factor == 0.5 || factor == 2 || factor == 3))
                        {
                            break;
                        }
                        else
                        {
                            Console.WriteLine("Please enter a valid scale factor (0.5, 2, or 3).");
                        }
                    }

                    recipe.Scale(factor);

                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("\nScaled Recipe:");
                    Console.ResetColor();
                    recipe.Display();
                    break;

                case "reset":
                    recipe.Reset();
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine("\nReset to original quantities.");
                    Console.ResetColor();
                    recipe.Display();
                    break;

                case "clear":
                    recipe.Clear();
                    Console.ForegroundColor = ConsoleColor.Blue;
                    Console.WriteLine("\nCleared recipe.");
                    Console.ResetColor();
                    break;

                case "display":
                    Console.ForegroundColor = ConsoleColor.Magenta;
                    Console.WriteLine();
                    recipe.Display();
                    Console.ResetColor();
                    break;

                case "exit":
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("\nExiting...");
                    Console.ResetColor();
                    Environment.Exit(0);
                    break;

                default:
                    Console.WriteLine("Invalid input. Please try again.");
                    break;
            }
        }
    }
}



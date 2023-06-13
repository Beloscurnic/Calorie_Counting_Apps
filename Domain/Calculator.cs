using System;

namespace Domain
{
    internal static class Calculator
    {
        public static double Protein(FoodProduct foodProduct, double weight)
        {
            double proteinContent = 0.0;

            switch (foodProduct)
            {
                case FoodProduct.Apple:
                    proteinContent = 0.3;
                    break;
                case FoodProduct.Banana:
                    proteinContent = 1.1;
                    break;
                case FoodProduct.Bread:
                    proteinContent = 7.5;
                    break;
                case FoodProduct.Butter:
                    proteinContent = 0.9;
                    break;
                case FoodProduct.Cheese:
                    proteinContent = 25.0;
                    break;
                case FoodProduct.Chicken:
                    proteinContent = 31.0;
                    break;
                case FoodProduct.Chocolate:
                    proteinContent = 5.5;
                    break;
                case FoodProduct.Coffee:
                    proteinContent = 0.3;
                    break;
                case FoodProduct.Egg:
                    proteinContent = 6.3;
                    break;
                case FoodProduct.Fish:
                    proteinContent = 20.0;
                    break;
                case FoodProduct.Grapes:
                    proteinContent = 0.6;
                    break;
                case FoodProduct.Hamburger:
                    proteinContent = 12.0;
                    break;
                case FoodProduct.Milk:
                    proteinContent = 3.3;
                    break;
                case FoodProduct.Orange:
                    proteinContent = 1.0;
                    break;
                case FoodProduct.Pasta:
                    proteinContent = 12.5;
                    break;
                case FoodProduct.Pizza:
                    proteinContent = 11.0;
                    break;
                case FoodProduct.Potato:
                    proteinContent = 2.0;
                    break;
                case FoodProduct.Rice:
                    proteinContent = 7.0;
                    break;
                case FoodProduct.Salad:
                    proteinContent = 1.2;
                    break;
                case FoodProduct.Tomato:
                    proteinContent = 0.9;
                    break;
                default:
                    Console.WriteLine("Unknown food product.");
                    break;
            }

            double totalProteinContent = proteinContent * weight / 100;

            return totalProteinContent;
        }

        public static double Fat(FoodProduct product, double weight)
        {
            double fatContent = 0.0;

            switch (product)
            {
                case FoodProduct.Apple:
                    fatContent = 0.4;
                    break;
                case FoodProduct.Banana:
                    fatContent = 0.2;
                    break;
                case FoodProduct.Bread:
                    fatContent = 2.0;
                    break;
                case FoodProduct.Butter:
                    fatContent = 81.0;
                    break;
                case FoodProduct.Cheese:
                    fatContent = 33.0;
                    break;
                case FoodProduct.Chicken:
                    fatContent = 14.0;
                    break;
                case FoodProduct.Chocolate:
                    fatContent = 31.0;
                    break;
                case FoodProduct.Coffee:
                    fatContent = 0.6;
                    break;
                case FoodProduct.Egg:
                    fatContent = 5.0;
                    break;
                case FoodProduct.Fish:
                    fatContent = 5.0;
                    break;
                case FoodProduct.Grapes:
                    fatContent = 0.2;
                    break;
                case FoodProduct.Hamburger:
                    fatContent = 16.0;
                    break;
                case FoodProduct.Milk:
                    fatContent = 3.7;
                    break;
                case FoodProduct.Orange:
                    fatContent = 0.2;
                    break;
                case FoodProduct.Pasta:
                    fatContent = 1.5;
                    break;
                case FoodProduct.Pizza:
                    fatContent = 12.0;
                    break;
                case FoodProduct.Potato:
                    fatContent = 0.1;
                    break;
                case FoodProduct.Rice:
                    fatContent = 0.3;
                    break;
                case FoodProduct.Salad:
                    fatContent = 0.2;
                    break;
                case FoodProduct.Tomato:
                    fatContent = 0.2;
                    break;
            }

            double totalFat = fatContent * weight / 100;
            return totalFat;
        }

        public static double Carbohydrates(FoodProduct product, double weight)
        {
            double carbohydrates = 0.0;

            switch (product)
            {
                case FoodProduct.Apple:
                    carbohydrates = 11.4;
                    break;
                case FoodProduct.Banana:
                    carbohydrates = 22.0;
                    break;
                case FoodProduct.Bread:
                    carbohydrates = 49.0;
                    break;
                case FoodProduct.Butter:
                    carbohydrates = 0.1;
                    break;
                case FoodProduct.Cheese:
                    carbohydrates = 1.3;
                    break;
                case FoodProduct.Chicken:
                    carbohydrates = 0.0;
                    break;
                case FoodProduct.Chocolate:
                    carbohydrates = 60.0;
                    break;
                case FoodProduct.Coffee:
                    carbohydrates = 0.0;
                    break;
                case FoodProduct.Egg:
                    carbohydrates = 0.6;
                    break;
                case FoodProduct.Fish:
                    carbohydrates = 0.0;
                    break;
                case FoodProduct.Grapes:
                    carbohydrates = 16.0;
                    break;
                case FoodProduct.Hamburger:
                    carbohydrates = 31.0;
                    break;
                case FoodProduct.Milk:
                    carbohydrates = 4.8;
                    break;
                case FoodProduct.Orange:
                    carbohydrates = 8.2;
                    break;
                case FoodProduct.Pasta:
                    carbohydrates = 74.7;
                    break;
                case FoodProduct.Pizza:
                    carbohydrates = 42.0;
                    break;
                case FoodProduct.Potato:
                    carbohydrates = 17.5;
                    break;
                case FoodProduct.Rice:
                    carbohydrates = 77.7;
                    break;
                case FoodProduct.Salad:
                    carbohydrates = 1.2;
                    break;
                case FoodProduct.Tomato:
                    carbohydrates = 3.9;
                    break;
                default:
                    return 0.0;
            }

            double carbohydratesInWeight = (carbohydrates / 100) * weight;

            return carbohydratesInWeight;
        }

        public static double Calories(FoodProduct product, double weight)
        {
            double caloriesPer100g;

            switch (product)
            {
                case FoodProduct.Apple:
                    caloriesPer100g = 52;
                    break;
                case FoodProduct.Banana:
                    caloriesPer100g = 96;
                    break;
                case FoodProduct.Bread:
                    caloriesPer100g = 265;
                    break;
                case FoodProduct.Butter:
                    caloriesPer100g = 717;
                    break;
                case FoodProduct.Cheese:
                    caloriesPer100g = 402;
                    break;
                case FoodProduct.Chicken:
                    caloriesPer100g = 165;
                    break;
                case FoodProduct.Chocolate:
                    caloriesPer100g = 546;
                    break;
                case FoodProduct.Coffee:
                    caloriesPer100g = 2;
                    break;
                case FoodProduct.Egg:
                    caloriesPer100g = 155;
                    break;
                case FoodProduct.Fish:
                    caloriesPer100g = 206;
                    break;
                case FoodProduct.Grapes:
                    caloriesPer100g = 69;
                    break;
                case FoodProduct.Hamburger:
                    caloriesPer100g = 250;
                    break;
                case FoodProduct.Milk:
                    caloriesPer100g = 42;
                    break;
                case FoodProduct.Orange:
                    caloriesPer100g = 43;
                    break;
                case FoodProduct.Pasta:
                    caloriesPer100g = 131;
                    break;
                case FoodProduct.Pizza:
                    caloriesPer100g = 266;
                    break;
                case FoodProduct.Potato:
                    caloriesPer100g = 77;
                    break;
                case FoodProduct.Rice:
                    caloriesPer100g = 130;
                    break;
                case FoodProduct.Salad:
                    caloriesPer100g = 5;
                    break;
                case FoodProduct.Tomato:
                    caloriesPer100g = 18;
                    break;
                default:
                    throw new ArgumentException("Unknown food product.");
            }

            return caloriesPer100g * (weight / 100);
        }
    }
}

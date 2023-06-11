using System;
using System.ComponentModel.DataAnnotations;

namespace Domain
{
    public class CalorieIntake
    {
        [Key]
        public Guid Id { get; }
        public DateTime Date { get; }
        public FoodProduct Product { get; set; }
        public int Weight { get; set; }
        public double Proteins { get; }
        public double Fat { get; }
        public double Carbohydrates { get; }
        public double Calories { get; }

        public CalorieIntake(FoodProduct Product, int Weight)
        {
            Id = new Guid();
            Date = DateTime.Now;
            this.Product = Product;
            this.Weight = Weight;
            Proteins = Calculator.Protein(Product, Weight);
            Fat = Calculator.Fat(Product, Weight);
            Carbohydrates = Calculator.Carbohydrates(Product, Weight);
            Calories = Calculator.Calories(Product, Weight);
        }
    }
}

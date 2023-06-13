using System;
using System.ComponentModel.DataAnnotations;

namespace Domain
{
    public class CalorieIntake
    {
        [Key]
        public Guid Id { get; }
        [Required]
        public Guid UserId { get; set; }
        [Required]
        public DateTime Date { get; set; }
        [Required]
        public FoodProduct Product { get; set; }
        [Required]
        public int Weight { get; set; }
        public double Proteins { get; set; }
        public double Fat { get; set; }
        public double Carbohydrates { get; set; }
        public double Calories { get; set; }

        public CalorieIntake(FoodProduct Product, int Weight, Guid UserId)
        {
            Id = Guid.NewGuid();
            this.UserId = UserId;
            Date = DateTime.Now;
            this.Product = Product;
            this.Weight = Weight;
            Proteins = Calculator.Protein(Product, Weight);
            Fat = Calculator.Fat(Product, Weight);
            Carbohydrates = Calculator.Carbohydrates(Product, Weight);
            Calories = Calculator.Calories(Product, Weight);
        }

        public CalorieIntake(FoodProduct Product, int Weight)
        {
            Id = Guid.NewGuid();
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

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp2
{
    internal class IngredientClass
    {
        public IngredientClass()
        {

        }
        public IngredientClass(double number, string name, double quantity, string unitOfMeasurement, double calories, string foodGroup)
        {
            Number = number;
            Name = name;
            Quantity = quantity;
            UnitOfMeasurement = unitOfMeasurement;
            Calories = calories;
            FoodGroup = foodGroup;
        }

        public double Number { get; set; }
        public string Name { get; set; }

        public double Quantity { get; set; }

        public string UnitOfMeasurement { get; set; }

        public double Calories { get; set; }

        public string FoodGroup { get; set; }


    }
}
//<summary>
//In this code I created a deafault constructor as well as a constructor with arguments for Ingredient names, unit of measurement, calories and food group
//This class is used to store ingredient instances
//</summary>

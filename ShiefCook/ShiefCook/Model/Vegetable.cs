using ShiefCook.Interface;

namespace ShiefCook.Model
{
    internal class Vegetable : IVegetable
    {
        public string Name { get; set; }

        public int Calories { get; set; }

        public int Weight { get; set; }

        public string Color { get; set; }

        public Vegetable()
        {
        }

        public Vegetable(string name, int calories, int weigth, string color)
        {
            Name = name;
            Calories = calories;
            Weight = weigth;
            Color = color;
        }
    }
}

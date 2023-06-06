using ShiefCook.Interface;

namespace ShiefCook.Model
{
    internal class Vegetable : IVegetable, IComparable
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

        public int CompareTo(object? obj)
        {
            if (obj is Vegetable vegetable)
            {
                return Name.CompareTo(vegetable.Name);
            }
            else
            {
                throw new ArgumentException("Не коректне значення аргументу");
            }
        }
    }
}

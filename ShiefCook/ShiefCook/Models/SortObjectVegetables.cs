using ShiefCook.Model;

namespace ShiefCook.Models
{
    internal class SortObjectVegetables : IComparable
    {
        public int CompareTo(object? obj)
        {
            if (obj is Vegetable vegetable)
            {
                return vegetable.Name.CompareTo(vegetable.Name);
            }
            else
            {
                throw new ArgumentException("Не коректне значення аргументу");
            }
        }
    }
}

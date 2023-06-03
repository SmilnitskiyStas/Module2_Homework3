using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShiefCook.Model
{
    internal static class VegetableExpansion
    {
        public static (Vegetable[], Vegetable[]) Search(this Vegetable vegetable, Vegetable[] vegetables, int caloriesStart = 0, int caloriesEnd = 0, string color = "")
        {
            Vegetable[] vegetablesCalories = new Vegetable[1];
            Vegetable[] vegetablesColor = new Vegetable[1];

            if (caloriesStart != 0 && caloriesEnd != 0)
            {
                vegetablesCalories = SearchByCalories(vegetables, caloriesStart, caloriesEnd);
            }

            if (!string.IsNullOrEmpty(color))
            {
                vegetablesColor = SearchByColor(vegetables, color);
            }

            return (vegetablesCalories, vegetablesColor);
        }

        /// <summary>
        /// Пошук інформації по калорійності.
        /// </summary>
        /// <param name="vegetables">Масив для перевірки.</param>
        /// <param name="caloriesStart">Початкове значення калорійності.</param>
        /// <param name="caloriesEnd">Кінечне значення калорійності.</param>
        /// <returns>Масив співпадіння.</returns>
        private static Vegetable[] SearchByCalories(Vegetable[] vegetables, int caloriesStart = 0, int caloriesEnd = 0)
        {
            Vegetable[] vegetablesSearchCalories = new Vegetable[vegetables.Length];

            int countArray = 0;

            for (int i = 0; i < vegetables.Length; i++)
            {
                if (vegetables[i].Calories >= caloriesStart && vegetables[i].Calories <= caloriesEnd)
                {
                    vegetablesSearchCalories[countArray] = vegetables[i];

                    countArray++;
                }
            }

            Array.Resize(ref vegetablesSearchCalories, countArray);

            return vegetablesSearchCalories;
        }

        /// <summary>
        /// Пошук інформації по кольору.
        /// </summary>
        /// <param name="vegetables">Масив овочів для перевірки</param>
        /// <param name="color">Колір для перевірки</param>
        /// <returns>Масив співпадінь.</returns>
        private static Vegetable[] SearchByColor(Vegetable[] vegetables, string color)
        {
            Vegetable[] vegetablesSearchColor = new Vegetable[vegetables.Length];

            int countArray = 0;

            for (int i = 0; i < vegetables.Length; i++)
            {
                if (vegetables[i].Color.ToLower() == color.ToLower())
                {
                    vegetablesSearchColor[countArray] = vegetables[i];

                    countArray++;
                }
            }

            Array.Resize(ref vegetablesSearchColor, countArray);

            return vegetablesSearchColor;
        }
    }
}

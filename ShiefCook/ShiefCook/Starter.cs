using ShiefCook.Model;
using ShiefCook.Vegetables;

namespace ShiefCook
{
    internal class Starter
    {
        public void Run()
        {
            // Вибираємо кількість овочів для салату.
            Console.WriteLine("Specify the number of vegetables for the salad");
            int countVegetables = int.Parse(Console.ReadLine());

            // Створення салату.
            Vegetable[] vegetables = CreateSalat(countVegetables);

            // Виводе інформацію про склад фруктів.
            SortVegetablesInSalat(vegetables);

            // Чи хочумо шукати інформацію про фрукти.
            Console.WriteLine("Do you want to search product\n1. Yes\n2. No");
            int searchProduct = int.Parse(Console.ReadLine());

            if (searchProduct == 1)
            {
                SearchVegetables(vegetables);
            }

            Console.WriteLine("\nВаше замовлення відправленне для приготування!");

            // Загальна кількість про салат.
            CalculationOfTheMeal(vegetables);
        }

        /// <summary>
        /// Створення салату (Рандомна).
        /// </summary>
        /// <param name="countVegetables">Скільки буде створюватися об'єктів овочів для салату.</param>
        /// <returns>Склад об'єктів для салату.</returns>
        private Vegetable[] CreateSalat(int countVegetables)
        {
            Random random = new Random();

            Vegetable[] vegetables = new Vegetable[countVegetables];

            for (int i = 0; i < countVegetables; i++)
            {
                int calories = random.Next(50, 850);

                int weigth = random.Next(150, 1000);

                // Випадкове створення об'єктів овочів.
                switch (random.Next(0, 9))
                {
                    case 0:
                        Vegetable beet = new Beet("Beet", calories, weigth, "Purple");
                        vegetables[i] = beet;
                        break;
                    case 1:
                        Vegetable beijingCabbage = new BeijingCabbage("Beijing Cabbage", calories, weigth, "Green");
                        vegetables[i] = beijingCabbage;
                        break;
                    case 2:
                        Vegetable cabbage = new Cabbage("Cabbage", calories, weigth, "Green");
                        vegetables[i] = cabbage;
                        break;
                    case 3:
                        Vegetable carrot = new Carrot("Carrot", calories, weigth, "Orange");
                        vegetables[i] = carrot;
                        break;
                    case 4:
                        Vegetable cucumber = new Cucumber("Cucumber", calories, weigth, "Green");
                        vegetables[i] = cucumber;
                        break;
                    case 5:
                        Vegetable onion = new Onion("Onion", calories, weigth, "Orange");
                        vegetables[i] = onion;
                        break;
                    case 6:
                        Vegetable pea = new Pea("Pea", calories, weigth, "Green");
                        vegetables[i] = pea;
                        break;
                    case 7:
                        Vegetable radish = new Radish("Rabish", calories, weigth, "Purple");
                        vegetables[i] = radish;
                        break;
                    case 8:
                        Vegetable tomato = new Tomato("Tomato", calories, weigth, "Red");
                        vegetables[i] = tomato;
                        break;
                }
            }

            return vegetables;
        }

        /// <summary>
        /// Виводемо інформацію про склад овочів в салаті.
        /// </summary>
        /// <param name="vegetables">Масив овочів.</param>
        private void SortVegetablesInSalat(Vegetable[] vegetables)
        {
            string[] vegetableName = new string[vegetables.Length];

            // Отримання іменя овочів для виведення їх на консоль.
            for (int i = 0; i < vegetables.Length; i++)
            {
                for (int y = 0; y < vegetableName.Length; y++)
                {
                    if (vegetableName[y] != vegetables[i].Name)
                    {
                        vegetableName[i] = vegetables[i].Name;
                    }
                }
            }

            Array.Sort(vegetableName);

            Console.WriteLine("\nVegetables included in the salad\n");

            // Відображення масиву овофів в салаті.
            ShowInfoNameVegetables(vegetableName);
        }

        /// <summary>
        /// Шукаємо овочі по характеристикам.
        /// </summary>
        /// <param name="vegetables">Масив овочів.</param>
        private void SearchVegetables(Vegetable[] vegetables)
        {
            Console.WriteLine("\n======================\nYou may miss some of the features\n======================\n");

            // Пошук по калоріям (Начальне та кінечне значення).
            Console.WriteLine("Input Calories to start and end (Example: 155, 350):");
            string[] caloriesStartEnd = Console.ReadLine().Split(',');

            // Пошук по кольору.
            Console.WriteLine("Input color of vegetable");
            string colorVegetableToSearch = Console.ReadLine();

            // Використання розширення класу.
            Vegetable vegetable = new Vegetable();
            (Vegetable[] arrayCalories, Vegetable[] arrayColor) = vegetable.Search(vegetables, int.Parse(caloriesStartEnd[0].Trim()), int.Parse(caloriesStartEnd[1].Trim()), colorVegetableToSearch);

            // Овочі які співпали по калорійності.
            Console.WriteLine("\nShow info calories vegetable:\n");
            ShowInfoVegetable(arrayCalories);

            // Овочі які співпали по кольору.
            Console.WriteLine("\nShow info colors vegetable:\n");
            ShowInfoVegetable(arrayColor);

            // Перевірка на сумісність масиву (Калоріїв, По кольору).
            CompatibilityCheck(arrayCalories, arrayColor);
        }

        /// <summary>
        /// Вивід інформації (Імені) які є в салаті.
        /// </summary>
        /// <param name="vegetables">Масив об'єктів.</param>
        private void ShowInfoVegetable(Vegetable[] vegetables)
        {
            for (int i = 0; i < vegetables.Length; i++)
            {
                Console.WriteLine(vegetables[i].Name);
            }
        }

        /// <summary>
        /// Показує відформатовану інформацію овочів в салаті.
        /// </summary>
        /// <param name="info">Масив овочів.</param>
        private void ShowInfoNameVegetables(string[] info)
        {
            for (int i = 0; i < info.Length; i++)
            {
                Console.WriteLine(info[i]);
            }
        }

        /// <summary>
        /// Сумісність овочів по двум параметрам (калоріям, кольору).
        /// </summary>
        /// <param name="vegetableCalories">Масив овочів по калоріям.</param>
        /// <param name="vegetableColor">Масив овочів по кольору.</param>
        private void CompatibilityCheck(Vegetable[] vegetableCalories, Vegetable[] vegetableColor)
        {
            int count = 0;

            // Перевірка на співпадіння.
            for (int i = 0; i < vegetableCalories.Length; i++)
            {
                for (int y = 0; y < vegetableColor.Length; y++)
                {
                    if (vegetableCalories[i] == vegetableColor[y])
                    {
                        Console.WriteLine($"Compatible vegetables according to the search parameters: {vegetableCalories[i].Name} - {vegetableCalories[i].Color} - {vegetableCalories[i].Calories}");

                        count++;
                    }
                }
            }

            // Якщо не було співпадіння, виводимо інформацію.
            if (count == 0)
            {
                Console.WriteLine("No match was found");
            }

            Console.WriteLine();
        }

        /// <summary>
        /// Загальна інформація про салат.
        /// </summary>
        /// <param name="vegetables">Масив овочів.</param>
        private void CalculationOfTheMeal(Vegetable[] vegetables)
        {
            int countCalories = 0;

            int countWeigth = 0;

            // Збір інформації (калорійності та ваги) салату.
            for (int i = 0; i < vegetables.Length; i++)
            {
                countCalories += vegetables[i].Calories;

                countWeigth += vegetables[i].Weight;
            }

            Console.WriteLine($"Calories - {countCalories}, weigth - {countWeigth}");
        }
    }
}

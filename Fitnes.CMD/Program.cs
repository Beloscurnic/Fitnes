using Fitnes.BL.Controller;
using Fitnes.BL.Model;
using System;

namespace Fitnes.CMD
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Имя пользователя");
            var name = Console.ReadLine();

            var usercontroller = new UserController(name);
            var eatingcontroller = new EatingController(usercontroller.CurrentUser);
            if (usercontroller.IsNewUser)
            {
                Console.WriteLine("Введите пол ");
                var gender = Console.ReadLine();
                var birthDate = ParseDateTime();
                var weight = ParseDouble("вес");
                var height = ParseDouble("рост");

                usercontroller.SetNewUserData(gender, birthDate, weight, height);
            }
            Console.WriteLine(usercontroller.CurrentUser);

            Console.WriteLine("Что вы хотите сделать");
            Console.Write("E- ввести прием пищи: ");
            var key = Console.ReadKey();
            Console.WriteLine();
            if (key.Key == ConsoleKey.E)
            {
               var foods =EnterEating();
                eatingcontroller.Add(foods.Food, foods.Weight);

                foreach(var item in eatingcontroller.Eating.Foods)
                {
                    Console.WriteLine($"\t{item.Key} - {item.Value}");
                }
            }


            Console.ReadLine();


        }

        private static (Food Food, double Weight) EnterEating()
        {
            Console.Write("Введите имя продукта: ");
            var food = Console.ReadLine();

            var calories = ParseDouble("Калории");
            var protein = ParseDouble("Протеины");
            var fats = ParseDouble("жиры");
            var carbohydrates = ParseDouble("Углеводы");

            var weight = ParseDouble("Вес просции");
            var product = new Food(food, calories,protein,fats,carbohydrates);
            return (product, weight);
        }

        private static DateTime ParseDateTime()
        {
            DateTime birthDate;
            while (true)
            {
                Console.WriteLine("дата рождения (dd.MM.yyyy) ");
                if (DateTime.TryParse(Console.ReadLine(), out birthDate))
                {
                    return birthDate;
                }
                else
                {
                    Console.WriteLine("Не верный форматы даты рождения");
                }
            }
        }
        private static double ParseDouble(string name)
        {
            while (true)
            {
                Console.Write($"Введите {name}: ");
                if (double.TryParse(Console.ReadLine(), out double value))
                {
                    return value;
                }
                else
                {
                    Console.WriteLine($"Не верный форматы {name}: ");
                }

            }
        }
    }
}

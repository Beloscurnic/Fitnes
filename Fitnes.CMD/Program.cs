using Fitnes.BL.Controller;
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
            Console.ReadLine();


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
                Console.WriteLine($"Введите {name}: ");
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

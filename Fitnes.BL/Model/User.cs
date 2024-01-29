using System;

namespace Fitnes.BL.Model
{
    /// <summary>
    /// Пользователь
    /// </summary>
    [Serializable]
    public class User
    {
        #region Cвойства 
        public string Name { get;  set; }
        /// <summary>
        /// Пол.
        /// </summary>
        public Gender Gender { get; set; }
        public DateTime BrithDate { get; set; }
        /// <summary>
        /// Вес.
        /// </summary>
        public double Weight { get; set; }
        /// <summary>
        /// Рост.
        /// </summary>
        public double Heigth { get; set; }

        public int Age
        {
            get
            {
                DateTime nowDate = DateTime.Today;
                int age = nowDate.Year - BrithDate.Year;
                if (BrithDate > nowDate.AddYears(-age))
                {
                    age--;
                }
                return age;
            }
        }
        #endregion
        /// <summary>
        /// Создать пользователя
        /// </summary>
        /// <param name="name">Имя</param>
        /// <param name="gender">Пол</param>
        /// <param name="brithdate"> Дата рождения</param>
        /// <param name="weight">Вес</param>
        /// <param name="heigth">Рос</param>
        public User(string name, Gender gender, DateTime brithdate, double weight, double heigth)
        {
            #region Проверка условий
            if (string.IsNullOrWhiteSpace(name))
            {
                throw new ArgumentNullException("Имя пользователя не должно быть null.", nameof(name));
            }
            if (gender is null)
            {
                throw new ArgumentNullException("Пол не должен быть null.", nameof(gender));
            }
            if (brithdate < DateTime.Parse("01.01.1900"))
            {
                throw new ArgumentException("Невозможная дата рождения", nameof(brithdate));
            }
            if (weight <= 0)
            {
                throw new ArgumentException("Невозможный вес человекка меньше нуля.", nameof(weight));
            }
            if (heigth <= 0)
            {
                throw new ArgumentException("Невозможный рост человекка меньше нуля.", nameof(heigth));
            }
            #endregion

            Name = name;
            Gender = gender;
            BrithDate = brithdate;
            Weight = weight;
            Heigth = heigth;
        }

        public User(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                throw new ArgumentNullException("Имя пользователя не должно быть null.", nameof(name));
            }

            Name = name;
        }

        public override string ToString()
        {
            return Name+" "+ Age;
        }
    }
}

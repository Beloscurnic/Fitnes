using System;

namespace Fitnes.BL.Model
{
    /// <summary>
    /// Пользователь
    /// </summary>
    public class User
    {
        #region Cвойства 
        public string Name { get; private set; }
        /// <summary>
        /// Пол.
        /// </summary>
        public Gender Gender { get; private set; }
        public DateTime Brithdate { get; }
        public double Weight1 { get; }
        public double Heigth1 { get; }
        public DateTime BrithDate { get; private set; }
        /// <summary>
        /// Вес.
        /// </summary>
        public double Weight { get; set; }
        /// <summary>
        /// Рост.
        /// </summary>
        public double Heigth { get; set; }
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
            Brithdate = brithdate;
            Weight1 = weight;
            Heigth1 = heigth;
        }

        public override string ToString()
        {
            return Name;
        }
    }
}

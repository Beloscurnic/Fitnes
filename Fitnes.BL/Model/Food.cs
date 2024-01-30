using System;

namespace Fitnes.BL.Model
{
    [Serializable]
    public class Food
    {
        public string Name { get; }
        /// <summary>
        /// Вес.
        /// </summary>
        public double Weight { get; }
        /// <summary>
        /// Белки
        /// </summary>
        public double Proteins { get; }
        /// <summary>
        /// Жеры
        /// </summary>        public double Fats { get; }
        /// <summary>
        /// Углеводы
        /// </summary>        public double Carbohydrates { get; }
        /// <summary>
        /// Каллории за 100 грамм 
        /// </summary>        public double Calories { get; }
        public double Protein { get; }

        private double CalloriesOneGramm { get { return Calories / 100.0; } }
        private double ProteinsOneGramm { get { return Proteins / 100.0; } }
        private double FatsOneGramm { get { return Fats / 100.0; } }
        private double CarbohydratesOneGramm
        {
            get => Carbohydrates / 100.0;
        }        public Food(string name) : this(name, 0, 0, 0, 0)
        {
        }        public Food(string name, double calories, double protein, double fats, double carbohydrates)
        {
            if (name is null)
            {
                throw new ArgumentNullException(nameof(name));
            }

            Name = name;
            Calories = calories / 100.0;
            Protein = protein / 100.0;
            Fats = fats / 100.0;
            Carbohydrates = carbohydrates / 100.0;
        }        public override string ToString()
        {
            return Name ;
        }    }
}

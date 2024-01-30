using Fitnes.BL.Model;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Fitnes.BL.Controller
{
    public class EatingController : ControllerBase
    {
        private const string FOOD_FILE_NAME = "foods.dat";
        private const string Eatings_FILE_NAME = "Eating.dat";
        private readonly User user;

        public IList<Food> Foods { get; }
        public Eating Eating { get; }

        public EatingController(User user)
        {
            this.user = user ?? throw new ArgumentNullException("Пользователь не должен быть пустым", nameof(user));

            Foods = GetAllFoods();
            Eating = GetEating();
        }

        public void Add(Food food, double weight)
        {
            var product = Foods.SingleOrDefault(f => f.Name == food.Name);
            if (product == null)
            {
                Foods.Add(food);
                Eating.Add(food, weight);
                Save();
            }
            else
            {
                Eating.Add(product, weight);
                Save();
            }
        }
        private Eating GetEating()
        {
            return Load<Eating>(Eatings_FILE_NAME) ?? new Eating(user);
        }

        private IList<Food> GetAllFoods()
        {
            return Load<List<Food>>(FOOD_FILE_NAME) ?? new List<Food>();
        }

        private void Save()
        {
            Save(FOOD_FILE_NAME, Foods);
            Save(Eatings_FILE_NAME, Eating);
        }
    }
}

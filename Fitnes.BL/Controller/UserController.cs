using Fitnes.BL.Model;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Fitnes.BL.Controller
{
    public class UserController : ControllerBase

    {
        private const string USER_FILE_NAME = "users.dat";
        public IList<User> Users { get; }
        public User CurrentUser { get; }

        public bool IsNewUser { get; } = false;

        public UserController(string username)
        {
            if (string.IsNullOrWhiteSpace(username))
            {
                throw new ArgumentNullException("Имя пользователя не должно быть пустым", nameof(username));
            }
            Users = GetUsersData();
            CurrentUser = Users.SingleOrDefault(u => u.Name == username);
            if (CurrentUser == null)
            {
                CurrentUser = new User(username);
                Users.Add(CurrentUser);
                IsNewUser = true;
                Save();
            }

        }
        /// <summary>
        /// Получить сохраненый список пользователя
        /// </summary>
        /// <returns> Пользователь приложения</returns>

        private IList<User> GetUsersData()
        {
            return Load<List<User>>(USER_FILE_NAME) ?? new List<User>();
        }

        public void Save()
        {
            Save(USER_FILE_NAME, Users);
        }

        public void SetNewUserData(string gendername, DateTime birthDate, double weight = 1, double height = 1)
        {
            // Проверка 
            CurrentUser.Gender = new Gender(gendername);
            CurrentUser.BrithDate = birthDate;
            CurrentUser.Heigth = height;
            CurrentUser.Weight = weight;
            Save();

        }

    }

}

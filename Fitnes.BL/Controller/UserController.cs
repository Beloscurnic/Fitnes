using Fitnes.BL.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;

namespace Fitnes.BL.Controller
{
    public class UserController
    {
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
            var formatter = new BinaryFormatter();
            using (var fs = new FileStream("users.dat", FileMode.OpenOrCreate))
            {
                if (formatter.Deserialize(fs) is List<User> users)
                {
                    return users;
                }
                else
                {
                    return new List<User>();
                }
                //TODO: Если пользователя не прочитали 

            }
        }
        public void Save()
        {
            var formatter = new BinaryFormatter();
            using (var fs = new FileStream("users.dat", FileMode.OpenOrCreate))
            {
                formatter.Serialize(fs, Users);
            }

        }

        public void SetNewUserData(string gendername, DateTime birthDate, double weight=1, double height=1)
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

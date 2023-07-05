using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using File_ConsoleC.Manager.Interface;
using File_ConsoleC.Model.Entities;
using File_ConsoleC.Model.Enum;

namespace File_ConsoleC.Manager.Implementation
{
    public class UserManager : IUserManager
    {
        private string Path = @"C:\Users\Uthman\Desktop\File-ConsoleC\Files\user.txt";
        public static List<User> UserDb = new List<User>()
         {
 new User(1,"Uthman", "Uthman","sal","uth","01034649670", DateOnly.Parse("1960-10-01"), Gender.Male,"SuperAdmin")
        };
        public User Get(string email)
        {
            foreach (var user in UserDb)
            {
                if (user.Email == email)
                {
                    return user;
                }
            }

            return null;
        }


        public User Login(string email, string password)
        {
            foreach (var user in UserDb)
            {
                if (user.Email == email && user.Password == password)
                {
                    return user;
                }
            }
            return null;
        }

        public User Add(User user)
        {
            using (var streamWriter = new StreamWriter(Path, true))
            {
                streamWriter.WriteLine(user.ToString());
            }
            UserDb.Add(user);
            return user;
        }
        public void LoadDataFromFile()
        {
            var data = File.ReadAllLines(Path);
            foreach (var item in data)
            {
                UserDb.Add(ConvertToUserObject(item));
            }
        }
        private User ConvertToUserObject(string data)
        {
            var newData = data.Split(' ');
            Enum.TryParse(newData[7], out Gender val);
            return new User(int.Parse(newData[0]), newData[1], newData[2], newData[3], newData[4], newData[5], DateOnly.Parse(newData[6]), val, newData[8]);
        }
        public void UpdateDataInFile()
        {
            // Clear the contents of the file
            File.WriteAllText(Path, "");

            // Write each customer to the file
            foreach (var user in UserDb)
            {
                using (var streamWriter = new StreamWriter(Path, true))
                {
                    streamWriter.WriteLine(user.ToString());
                }
            }
        }
    }
}
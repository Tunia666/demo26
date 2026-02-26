using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace demo26
{
    internal class LoginClass
    {
        public static UserRole Role { get; set; } = UserRole.Guest;
        public static string UserName { get; set; } = "Гость";

        public enum UserRole
        {
            Guest,
            Client,
            Manager,
            Admin
        }
    }
}

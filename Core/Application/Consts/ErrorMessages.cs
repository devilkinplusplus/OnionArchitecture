using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Consts
{
    public static class ErrorMessages
    {
        public static string EmptyEmailMessage = "Email cannot be empty";
        public static string EmptyUsernameMessage = "Username cannot be empty";
        public static string InvalidEmailMessage= "Email address is invalid";
        public static string InvalidUsernameMessage= "Username must be between 3 and 16 characters";

        public static string EmptyNameMessage = "Name cannot be empty";
        public static string InvalidNameMessage = "Name must be between 3 and 20 characters";
        public static string EmptyLastNameMessage = "Lastname cannot be empty";
        public static string InvalidLastNameMessage = "Lastname must be between 3 and 35 characters";
    }
}

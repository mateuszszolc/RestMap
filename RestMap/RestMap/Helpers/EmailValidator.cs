using System;
using System.Collections.Generic;
using System.Text;

namespace RestMap.Validator
{
    public static class EmailValidator
    {
        public static bool IsEmailValid(string email)
        {
            if (!email.Contains("@") || !email.Contains("."))
            {
                return false;
            }

            return true;
        }
    }
}

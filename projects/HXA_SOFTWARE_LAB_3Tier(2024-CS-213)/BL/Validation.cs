using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HXA_SOFTWARE_LAB.BL
{
    public static class Validation
    {
        public static bool EmailValidation(string email)
        {
            int rateIdx = -1, dotIdx = -1;
            int emailLen = email.Length;

            for (int i = 0; i < emailLen; i++)
                if (email[i] == ' ') return false;

            if (email == "" || emailLen < 5)
                return false;

            for (int i = 0; i < emailLen; i++)
            {
                if (email[i] == '@')
                {
                    if (rateIdx != -1)
                        return false;
                    rateIdx = i;
                }
                else if (email[i] == '.')
                    dotIdx = i;
                else if (email[i] == ' ')
                    return false;
            }

            if (rateIdx == -1 || dotIdx == -1 || rateIdx == 0 || rateIdx > dotIdx - 2 || dotIdx == emailLen - 1)
                return false;

            return true;
        }
        public static bool PasswordValidation(string password)
        {
            bool hasSpecial = false, hasNumber = false, hasLetter = false;
            int passwordLen = password.Length;

            for (int i = 0; i < passwordLen; i++)
                if (password[i] == ' ') return false;

            if ((passwordLen < 8) || (passwordLen > 16) || (password == ""))
                return false;

            for (int i = 0; i < passwordLen; i++)
            {
                char a = password[i];

                if ((a > 64 && a < 91) || (a > 96 && a < 123))
                    hasLetter = true;

                if (a > 47 && a < 58)
                    hasNumber = true;

                else if ((a >= 33 && a <= 47) || (a >= 58 && a <= 64) || (a >= 91 && a <= 96) || (a >= 123 && a <= 126))
                    hasSpecial = true;
            }

            return hasSpecial && hasNumber && hasLetter;
        }

    }
}

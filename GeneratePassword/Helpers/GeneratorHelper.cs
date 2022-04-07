using GeneratePassword.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GeneratePassword.Helpers
{
    public static class GeneratorHelper
    {

        public static string GeneratePassword(int maxLen, bool Caps, bool Symb, bool numbs)
        {
            Random rand = new Random();

            string output = "";
            int minCaps = 1;
            int minSymbols = 1;
            int minNumbers = 1;
            if (Caps == true)
            {
                output += GetCaps(minCaps);

            }

            if (Symb)
            {
                output += GetSymbols(minSymbols);
            }
           

            if (numbs)
            {
                output += GetNumbers(minNumbers);
            }

       
            int minRemaining = maxLen - (output.Length);
            
            output += GetRemaining(minRemaining);

           

            Random randAll = new Random();

            // Create new string from the reordered char array
            //https:///stackoverflow.com/questions/4739903/shuffle-string-c-sharp
            string outputFinal = new string(output.ToCharArray()
                .OrderBy(s => (randAll.Next(2) % 2) == 0).ToArray());

           


            return outputFinal;
        }




        private static string GetSymbols(int minSymbols)
        {
            string output = "";
            string symbols = "!@#$%&*)(";
            Random randSymbols = new Random();


            for (int i = 0; i < minSymbols; i++)
            {
                int numSymbols = randSymbols.Next(symbols.Length);
                output += symbols[numSymbols];
            }
            return output;
        }

        private static string GetNumbers(int minNumbers)
        {
            string output = "";
            string numbers = "1234567890";
            Random randNumbers = new Random();


            for (int i = 0; i < minNumbers; i++)
            {
                int numNumbers = randNumbers.Next(numbers.Length);
                output += numbers[numNumbers];
            }
            return output;
        }

        private static string GetCaps(int minCaps)
        {
            string selectCharacters = "abcdefghijklmnopqrstuvwxyz";
            string output = "";
            string caps = selectCharacters.ToUpper();
            Random randCaps = new Random();


            for (int i = 0; i < minCaps; i++)
            {
                int numCaps = randCaps.Next(caps.Length);
                output += caps[numCaps];
            }
            return output; //XX
        }
        private static string GetRemaining(int minRem)
        {
            string selectCombined = "abcdefghijklmnopqrstuvwxyz!@#$%&*)(1234567890ABCDEFGHIJKLMNOPQRSTUVWXYZ";
            string output = "";
           
            Random randRem = new Random();


            for (int i = 0; i < minRem; i++)
            {
                int numCaps = randRem.Next(selectCombined.Length);
                output += selectCombined[numCaps];
            }
            return output; //XX
        }

        // future refactoring

        public static bool IsStrong(string password)
        {
            bool hasUpper = false; bool hasLower = false; bool hasDigit = false;
            for (int i = 0; i < password.Length && !(hasUpper && hasLower && hasDigit); i++)
            {
                char c = password[i];
                if (!hasUpper) hasUpper = char.IsUpper(c);
                if (!hasLower) hasLower = char.IsLower(c);
                if (!hasDigit) hasDigit = char.IsDigit(c);

            }
            return hasUpper && hasLower && hasDigit;
        }

        public static bool GetStrength(string password)
        {
            bool hasLower = false; bool hasUpper = false; bool hasSymbol = false; bool hasDigit = false;
            for (int i = 0; i < password.Length; i++)
            {
                hasUpper = Char.IsUpper(password[i]);
                hasDigit = Char.IsDigit(password[i]);
                hasLower = Char.IsLower(password[i]);
                hasSymbol = ContainsSpecialChars(password[i].ToString());

            }

            return hasUpper && hasSymbol && hasDigit && hasLower;

        }

        private static bool ContainsSpecialChars(string value)
        {
            char[] symbolList = { '!', '@', '#', '$', '%', '&', '*', ')', '(' };
            return symbolList.Any(value.Contains);
        }

    }
}

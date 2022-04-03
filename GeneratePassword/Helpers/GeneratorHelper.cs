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


    }
}

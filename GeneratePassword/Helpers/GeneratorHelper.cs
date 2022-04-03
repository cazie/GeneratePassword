using GeneratePassword.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GeneratePassword.Helpers
{
    public class GeneratorHelper
    {

        public string GeneratePassword(int maxLen, bool Caps, bool Symb, bool numbs)
        {

            string selectCharacters = "abcdefghijklmnopqrstuvwxyz";
            string symbs = "!@#$%&*)(!@#$%&*)(";
            string numbers = "12345678901234567890";


            string selectChoice = "";


            Random rand = new Random();
            Random randCaps = new Random();
            Random randSymbols = new Random();
            Random randNumbers = new Random();

            string output = "";
            int minCaps = 2;
            int minSymbols = 2;
            int minNumbers = 2;
            if (Caps == true)
            {
                selectCharacters = selectCharacters.ToUpper();

                for (int i = 0; i < minCaps; i++)
                {
                int numCaps = randCaps.Next(minCaps);
                output += numCaps;
                }
             

            }

            if (Symb == false)
            {
                symbs = "";
                

            }
            else
            {
               
                    selectCharacters += symbs;

                for (int i = 0; i < minSymbols; i++)
                {
                    int numSymbols = randSymbols.Next(minSymbols);
                    output += numSymbols;
                }
            }

            if (numbs == false)
            {
                numbers = "";
            }
            else
            {
                selectCharacters += numbers;
                for (int i = 0; i < minNumbers; i++)
                {
                    int numNumbers = randNumbers.Next(minNumbers);
                    output += numNumbers;
                }
            }
            selectChoice = selectCharacters + output;

            for (int i = 0; i < maxLen - (output.Length); i++)
            {

                int num = rand.Next(selectCharacters.Length);

                output += selectChoice[num];

            }
            return output;
        }

     
    }
}

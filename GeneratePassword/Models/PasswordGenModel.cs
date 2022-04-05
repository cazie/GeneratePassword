using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GeneratePassword.Models
{
    public class PasswordGenModel
    {

        //public string Letters { get; set; }
        //public string Numbers { get; set; }
        //public string Symbols { get; set; }
        public int MaxLength { get; set; }

        public bool IsStrong { get; set; }

        public string GeneratedPassword { get; set; }

        public bool UseCaps { get; set; }

        public bool UseSymb { get; set; }

        public bool UseNumbers { get; set; }


    }

    //public enum Strength
    //{
    //    Weak,
    //    Medium,
    //    Strong
    //}
}

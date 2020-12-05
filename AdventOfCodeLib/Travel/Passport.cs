using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace AdventOfCodeLib.Travel
{
    public class Passport
    {
        public static Dictionary<string, Regex> FieldValidator { get; set; }
        public Dictionary<string, string> Data { get; set; }
        static Passport()
        {
            FieldValidator = new Dictionary<string, Regex>
            {
                {"byr", new Regex("^((19[2-9][0-9])|200[0-2])$")},
                {"iyr" , new Regex("^(20(([1][0-9])|20))$")},
                {"eyr" , new Regex("^(20((2[0-9])|30))$")},
                {"hgt" , new Regex("^((1(([5-8][0-9])|9[0-3])cm)|((59|6[0-9]|7[0-6])in))$")},
                {"hcl" , new Regex("^(#[0-9a-f]{6})$")},
                {"ecl" , new Regex("^(amb|blu|brn|gry|grn|hzl|oth)$")},
                {"pid" , new Regex("^([0-9]{9})$")},
                {"cid" , new Regex(".*")}
            };
        }

        public Passport(string text)
        {
            Data = text.Split(' ')
                       .Where(w => !string.IsNullOrWhiteSpace(w))
                       .Select(s => s.Split(':'))
                       .ToDictionary(s => s[0], s => s[1]);
        }
        
        public bool IsPresent => Data.Count(k => IsMandatoryField(k.Key)) == 7;
        public bool IsValid => IsEachFieldValid();

        private bool IsEachFieldValid()
        {
            foreach (var tuple in Data)
            {
                var key = tuple.Key;
                var fieldValue = tuple.Value;

                var fieldValidator = FieldValidator[key];

                if (!fieldValidator.IsMatch(fieldValue))
                {
                    return false;
                }
            }

            return true;
        }


        private bool IsMandatoryField(string arg)
        {
            switch( arg) {
                case "byr":
                case "iyr":
                case "eyr":
                case "hgt":
                case "hcl":
                case "ecl":
                case "pid":
                    return true;

                default: return false;
            }
        }
    }
}

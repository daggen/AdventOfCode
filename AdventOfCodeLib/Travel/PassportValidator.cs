using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AdventOfCodeLib.Matchers;

namespace AdventOfCodeLib.Travel
{
    public class PassportValidator
    {
        public PassportValidator()
        {
            FieldValidator = new Dictionary<string, IMatcher>
            {
                {"byr", new IntMatcher(1920, 2002)},
                {"iyr" , new IntMatcher(2010, 2020)},
                {"eyr" , new IntMatcher(2020, 2030)},
                {"hgt" , new CombinedAnyMatcher(new IntWithUnitMatcher("cm", 150, 193),
                                                new IntWithUnitMatcher("in", 59,76))},
                {"hcl" , new RegexMatcher("^(#[0-9a-f]{6})$")},
                {"ecl" , new RegexMatcher("^(amb|blu|brn|gry|grn|hzl|oth)$")},
                {"pid" , new RegexMatcher("^([0-9]{9})$")},
                {"cid" , new RegexMatcher(".*")}
            };
        }

        private Dictionary<string, IMatcher> FieldValidator { get; }

        public bool IsFieldValuesValid(Passport passport)
        {
            foreach (var tuple in passport.Fields)
            {
                var key = tuple.Key;
                var fieldValue = tuple.Value;

                var fieldValidator = FieldValidator[key];

                if (!fieldValidator.Match(fieldValue))
                {
                    return false;
                }
            }

            return true;
        }

        public bool IsAllMandatoryFieldsPresent(Passport passport) => passport.Fields.Count(k => IsMandatoryField(k.Key)) == 7;

        public bool IsValidPassport(Passport passport) =>
            IsAllMandatoryFieldsPresent(passport) && IsFieldValuesValid(passport);

        private static bool IsMandatoryField(string arg)
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

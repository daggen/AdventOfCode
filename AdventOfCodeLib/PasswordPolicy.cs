using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace AdventOfCodeLib
{
    public class PasswordPolicy
    {
        private static readonly Regex s_Rx;

        static PasswordPolicy()
        {
            s_Rx = new Regex(@"(\d+)-(\d+) ([a-z]): (\w+)");
        }

        public PasswordPolicy(string row)
        {
            var match = s_Rx.Match(row);
            if (!match.Success)
            {
                throw new ArgumentException($"Not possible to parse {row}");
            }

            Minimum = int.Parse(match.Groups[1].ToString());
            Maximum = int.Parse(match.Groups[2].ToString());
            Character = match.Groups[3].ToString()[0];
            Password = match.Groups[4].ToString();
        }

        public string Password { get; set; }

        public int Minimum { get; set; }
        public int Maximum { get; set; }
        public char Character { get; set; }
        public bool IsValid()
        {
            var nbr = Password.Count(c => c == Character);
            return nbr >= Minimum && nbr <= Maximum;
        }

        public bool IsValid2()
        {
            try
            {
                return Password[Minimum - 1] == Character ^ Password[Maximum - 1] == Character;
            }
            catch (IndexOutOfRangeException)
            {
                throw new ArgumentException($"{Password} with minimum {Minimum} and max {Maximum} could not be validated");
            }
        }
    }
}

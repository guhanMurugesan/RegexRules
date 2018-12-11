using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace RegexRules
{
    class Program
    {
        static void Main(string[] args)
        {
            //(ILT_Gme)\:{1}\s(\w*)\s*(Var)\:*\s*(\d*)?\s?(Lev|Group|\$)?\:?\s?(\w[0x]?\d*\.?\d*)?\s?(\$|Lev)?\:?\s?(\d*\.?\d*)?\s?(\$)?(\d*\.?\d*)?

            //ILT_Gme: 0x3ED0 Var: 99 $4500.48
            //ILT_Gme: 0x3ED0 Var: 99
            //ILT_Gme: 0x3ED0 Var: 99 Lev: 2 $32.24
            //ILT_Gme: 0x3ED0 Var: 99 Group: 0x2345 Lev: 1 $413.37

            RegexMatcher matcher = new RegexMatcher() { RegexExpression = @"(ILT_Gme)\:{1}\s(\w*)\s*(Var)\:*\s*(\d*)?\s?(Lev|Group|\$)?\:?\s?(\w[0x]?\d*\.?\d*)?\s?(\$|Lev)?\:?\s?(\d*\.?\d*)?\s?(\$)?(\d*\.?\d*)?", CaptureRegexGroup = new CaptureRegexGroup() { Variables = "ILT_Gme,Lev,Var,Group,$" } };

            foreach (var item in matcher.Match(@"ILT_Gme: 0x3ED0 Var: 99 $4500.48"))
            {
                Console.WriteLine("{0}={1}",item.Key,item.Value);
            }

            Console.ReadLine();

        }

        private static void Intialize(IList<string> keys)
        {
            keys.Add("ILT_Gme");
            keys.Add("Var");
            keys.Add("Lev");
            keys.Add("$");
            keys.Add("Group");
        }
    }
}

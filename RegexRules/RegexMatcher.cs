using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace RegexRules
{
    public class RegexMatcher
    {
        private string _RegexExpression;
        private IHandleGroups _CaptureRegexGroup;

        public RegexMatcher()
        {

        }

        public string RegexExpression { set { _RegexExpression = value; } }

        public IHandleGroups CaptureRegexGroup { set { _CaptureRegexGroup = value; } }

        public IDictionary<string, string> Match(string input)
        {
            Regex rx = new Regex(_RegexExpression); 
            Match match = rx.Match(input);
            if (match.Success)
            {
                return _CaptureRegexGroup.GetCaptureVariables(match);
            }
            return null;
            
        }
       
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RegexRules
{
    public class CaptureRegexGroup:IHandleGroups
    {
        private string _Variables;

        public CaptureRegexGroup()
        {

        }

        public string Variables { set { _Variables = value; } }

        public IDictionary<string, string> GetCaptureVariables(System.Text.RegularExpressions.Match match)
        {
            var keys = _Variables.Split(',').ToList();
            IDictionary<string, string> capturedVariables = new Dictionary<string, string>();
            for (int i = 1; i < match.Groups.Count; i++)
            {
                if (keys.Contains(match.Groups[i].Value))
                {
                    capturedVariables.Add(new KeyValuePair<string, string>(match.Groups[i].Value, match.Groups[i + 1].Value));
                    i++;
                }
            }
            return capturedVariables;
        }
       
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace QuestionnaireNotepad.DataParsing
{
    class RecordDispatcher
    {
        static public string SanitizeString(string param)
        {

            /*
            IDictionary<string, string> SanitizeSequence = new Dictionary<string, string>
            {
                { @"([\\\;\:\,])", @"\\$1" },
                { @"\n", @"\\n" }
            };
            */

            string retval = param;
            Regex SanitizePattern = new Regex(@"([\\\;\:\,])");
            retval = SanitizePattern.Replace(retval, @"\$1");

            SanitizePattern = new Regex(@"\r\n?|\n");
            retval = SanitizePattern.Replace(retval, @"\n");

            return retval;
        }

        static public string ParseRecord(string param)
        {

            /*
            IDictionary<string, string> SanitizeSequence = new Dictionary<string, string>
            {
                { @"([\\\;\:\,])", @"\\$1" },
                { @"\n", @"\\n" }
            };
            */

            string retval = param;
            Regex SanitizePattern = new Regex(@"(?<!\\)\\n");
            retval = SanitizePattern.Replace(retval, System.Environment.NewLine);

            SanitizePattern = new Regex(@"(\\)(?=[\;\:\,])");
            retval = SanitizePattern.Replace(retval, "");

            SanitizePattern = new Regex(@"(\\{2})");
            retval = SanitizePattern.Replace(retval, @"\");

            return retval;
        }
    }
}

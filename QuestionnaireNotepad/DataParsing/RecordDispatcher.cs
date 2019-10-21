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
        static List<(Regex, string)> SanitizeRxSeq = new List<(Regex regex, string replacement)>()
        {
            (new Regex(@"([\\\;\:\,])"), @"\$1"),
            (new Regex(@"\r\n?|\n"), @"\n")
        };

        static List<(Regex, string)> ParseRxSeq = new List<(Regex regex, string replacement)>()
        {
            (new Regex(@"(?<!\\)\\n"), System.Environment.NewLine),
            (new Regex(@"(\\)(?=[\;\:\,])"), ""),
            (new Regex(@"(\\{2})"), @"\")
        };

        static public string SanitizeString(string param)
        {
            string retval = param;
            foreach (var (regex, replacement) in SanitizeRxSeq)
            {
                retval = regex.Replace(retval, replacement);
            }

            return retval;
        }

        static public string ParseRecord(string param)
        {
            string retval = param;
            foreach (var (regex, replacement) in ParseRxSeq)
            {
                retval = regex.Replace(retval, replacement);
            }

            return retval;
        }
    }
}

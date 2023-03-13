using System.Text.RegularExpressions;

namespace Teammate.Utils
{
    public class SimpleHtmlHelper
    {
        public static string StripHtml(string? input)
        {
            return input == null ? string.Empty : Regex.Replace(input, "<.*?>", string.Empty);
        }
    }
}

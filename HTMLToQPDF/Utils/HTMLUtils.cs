﻿using System.Text.RegularExpressions;
using System.Web;

namespace HTMLQuestPDF.Utils
{
    internal static class HTMLUtils
    {
        private static readonly string spaceAfterLineElementPattern = @$"\S<\/({string.Join("|", HTMLMapSettings.LineElements)})> ";

        public static string PrepareHTML(string value)
        {
            var result = RemoveSpacesBetweenElements(value);
            result = ReplaceNonBreakingSpaces(result);
            result = HttpUtility.HtmlDecode(result);
            result = RemoveExtraSpacesAndBreaks(result);
            result = RemoveSpacesAroundBr(result);
            result = WrapSpacesAfterLineElement(result);
            return result;
        }

        public static string ReplaceNonBreakingSpaces(string value)
        {
            var ret = value.Replace("&nbsp;", " ");
            return ret;
        }
        private static string RemoveExtraSpacesAndBreaks(string html)
        {
            return Regex.Replace(html, @"[ \r\n]+", " ");
        }

        private static string RemoveSpacesBetweenElements(string html)
        {
            return Regex.Replace(html, @">\s+<", _ => @"><").Replace("<space></space>", "<space> </space>");
        }

        private static string RemoveSpacesAroundBr(string html)
        {
            return Regex.Replace(html, @"\s+<\/?br\s*\/?>\s+", _ => @$"<br>");
        }

        private static string WrapSpacesAfterLineElement(string html)
        {
            return Regex.Replace(html, spaceAfterLineElementPattern, m => $"{m.Value.Substring(0, m.Value.Length - 1)}<space> </space>");
        }
    }
}
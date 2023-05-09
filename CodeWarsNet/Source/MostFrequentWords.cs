using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace CodeWars.Source
{
    public class MostFrequentWords
    {
        //public static string[] FindMostFrequentWords(string text)
        //{
        //    var pattern = "[^a-z']+";
        //    var split = Regex.Split(text.ToLowerInvariant(), pattern);
        //    var result = split.Where(str => !String.IsNullOrWhiteSpace(str) && Regex.IsMatch(str, "[a-z]+")).GroupBy(str => str).OrderByDescending(group=>group.Count()).Take(3).Select(grouping=>grouping.Key);

        //    return result.ToArray();
        //}

        public static List<string> FindMostFrequentWords(string s)
        {
            var pattern = "'*[a-z]+[a-z']*";
            var result = Regex
                .Matches(s, pattern, RegexOptions.IgnoreCase)
                .GroupBy(match => match.Value.ToLowerInvariant())
                .OrderByDescending(group=>group.Count())
                .Take(3)
                .Select(grouping=>grouping.Key);

            return result.ToList();
        }
    }
}

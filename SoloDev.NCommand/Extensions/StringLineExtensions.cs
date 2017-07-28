using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoloDev.NCommand.Extensions
{
    internal static class StringLineExtensions
    {
        internal static string GetExecutorName(this string wholeLine)
        {
            return wholeLine.GetFirst();
        }
        internal static string GetCommandName(this string wholeLine)
        {
            return wholeLine.GetRest().GetFirst();
        }

        internal static string GetFirst(this string line, char split = ' ')
        {
            return line.Split(split).FirstOrDefault();
        }

        internal static string GetRest(this string line, char split = ' ')
        {
            return string.Join(split.ToString(), line.Split(split).Skip(1));
        }

        internal static Dictionary<string, string> GetCommandParameters(this string wholeLine)
        {
            var dictionary = new Dictionary<string, string>();

           wholeLine
                .Split(new string[] { "--" }, StringSplitOptions.RemoveEmptyEntries)
                .Skip(1)
                .ToList()
                .ForEach(x =>
                {
                    var key = x.GetFirst().Trim();
                    var value = x.GetRest().Trim();
                    dictionary.Add(key, value);
                });
            

            return dictionary;
        }
    }
}

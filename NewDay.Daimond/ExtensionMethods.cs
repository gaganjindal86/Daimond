using System;
using System.Linq;

namespace NewDayDaimond
{
    public static class ExtensionMethods
    {
        public static String MultilineReverse(this String input)
        {
            var lines = input.Split(Environment.NewLine).Where(x => !string.IsNullOrEmpty(x));
            var revertedLines = lines.Reverse();
            var result = String.Join(Environment.NewLine, revertedLines) + Environment.NewLine;
            return result;
        }
    }
}
using System;

namespace TreasuryChallenge.utils
{
    public static class TreasuryUtils
    {
        public static string GetChar()
        {
            Random random = new Random();
            var chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ".ToCharArray(0, 26);

            return chars[random.Next(25)].ToString();
        }

        public static bool FoundChar(string content, string charGenerated) 
        {
            return content.ToUpper().Contains(charGenerated.ToUpper());
        }
    }
}
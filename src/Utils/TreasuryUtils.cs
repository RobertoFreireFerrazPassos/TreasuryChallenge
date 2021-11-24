using System;
using System.Linq;
using TreasuryChallenge.Common;

namespace TreasuryChallenge.utils
{
    public static class TreasuryUtils
    {
        public static String GenerateCode()
        {
            String response = "";
            bool[] used = new bool[26];

            char[] chars = Constants.LETTERS_OF_THE_ALPHABET.ToCharArray(0, 26);
            Random random = new Random();

            while (response.Length < 7)
            {
                int letterPosition = random.Next(25);
                if (!used[letterPosition])
                {
                    used[letterPosition] = true;
                    response += chars[letterPosition];
                }
            }

            return response;
        }
    }
}
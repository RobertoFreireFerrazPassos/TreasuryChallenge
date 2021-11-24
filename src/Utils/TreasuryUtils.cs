using System;
using System.Linq;
using TreasuryChallenge.Common;

namespace TreasuryChallenge.utils
{
    public static class TreasuryUtils
    {
        public static String GenerateCode(int maxLengthContent)
        {
            String response = Constants.EMPTY_STRING;
            int numberOfChars = 26;
            bool[] used = new bool[numberOfChars];

            char[] chars = Constants.LETTERS_OF_THE_ALPHABET.ToCharArray(0, numberOfChars);
            Random random = new Random();

            while (response.Length < maxLengthContent)
            {
                int letterPosition = random.Next(numberOfChars - 1);
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
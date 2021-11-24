using System.Text;
using TreasuryChallenge.Common;
using TreasuryChallenge.utils;

namespace TreasuryChallenge.Model
{
    public class Content : IContent
    {
        public int MaxLengthContent { get; private set; }
        public int NumberOfLines { get; private set; }
        public Content(int maxLengthContent, int numberOfLines) {
            this.MaxLengthContent = maxLengthContent;
            this.NumberOfLines = numberOfLines;
        }

        public StringBuilder Generate() {
            StringBuilder stringContent = new StringBuilder();
            for (int i = 0; i < NumberOfLines; i++)
            {
                stringContent.AppendLine(GenerateCode());
            };

            return stringContent;
        }        

        private string GenerateCode()
        {
            string content = Constants.EMPTY_STRING;
            
            while (content.Length < MaxLengthContent)
            {
                string charGenerated = TreasuryUtils.GetChar();

                if(!TreasuryUtils.FoundChar(content, charGenerated))
                {
                    content += charGenerated;
                }
            }
            return content;
        }
    }
}

using System.IO;
using TreasuryChallenge.Common;
using TreasuryChallenge.utils;

namespace TreasuryChallenge.Model
{
    public class TXTFile: TemplateFile
    {
        public string FileName { get; private set; }
        public int MaxLengthContent { get; private set; }
        public TXTFile(string fileName, int maxLengthContent)
        {
            this.FileName = fileName;
            this.MaxLengthContent = maxLengthContent;
        }
        public void WriteFile(int inputValue)
        {
            string fileName = this.FileName + Constants.TXT_EXTENSION;  

            using (StreamWriter write = new StreamWriter(fileName))
            {
                for (int i = 0; i < inputValue; i++)
                {
                    write.WriteLine(GenerateContent());
                };
            };
        }
        public string GenerateContent(string content = Constants.EMPTY_STRING)
        {
            if (content.Length == this.MaxLengthContent) return content;

            string charGenerated = TreasuryUtils.GetChar();

            if(content.Length != 0)
            {
                bool found = TreasuryUtils.FoundChar(content, charGenerated);
                while(found)
                {
                    charGenerated = TreasuryUtils.GetChar();
                    found = TreasuryUtils.FoundChar(content, charGenerated);
                }
            }
            return GenerateContent(content + charGenerated);
        }
    }
}
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TreasuryChallenge.Interface;
using TreasuryChallenge.utils;

namespace TreasuryChallenge.Services
{
    public class ContentService : IContentService
    {
        public int LengthContent { get; private set; }
        private int NumberOfLines;
        public IStringBuilderService StringBuilderService { get; private set; }

        public int GetNumberOfLines() {
            return NumberOfLines;
        }
        public ContentService(IStringBuilderService stringBuilderService, int lengthContent, int numberOfLines) {
            StringBuilderService = stringBuilderService;
            LengthContent = lengthContent;
            NumberOfLines = numberOfLines;
        }

        public StringBuilder Generate() {
            for (int i = 0; i < NumberOfLines; i++)
            {
                AddCodeToContent();
            };

            return StringBuilderService.GetStringContent();
        }

        private void AddCodeToContent()
        {
            bool saved = false;
            while (!saved)
            {
                saved = StringBuilderService.Append(CodeUtils.Generate(this.LengthContent));
            }
        }
    }
}

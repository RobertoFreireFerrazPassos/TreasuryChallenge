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

        public int GetNumberOfLines() {
            return NumberOfLines;
        }
        public ContentService(int lengthContent, int numberOfLines) {
            this.LengthContent = lengthContent;
            this.NumberOfLines = numberOfLines;
        }

        public StringBuilder Generate()
        {
            StringBuilder stringContent = new StringBuilder();
            int numProcs = Environment.ProcessorCount;
            int numberOfTimes = numProcs;

            Dictionary<int, int> linesPerTasklist = getListLinesPerTask(numberOfTimes);

            ConcurrentDictionary<int, StringBuilder> stringContentList = 
                new ConcurrentDictionary<int, StringBuilder>(numberOfTimes, numberOfTimes);
            
            Parallel.For(0, numberOfTimes, i =>
            {
                stringContentList[i] = GenerateStringBuilder(linesPerTasklist.GetValueOrDefault(i));
            });

            foreach (StringBuilder stringItem in stringContentList.Values) {
                stringContent.Append(stringItem);
            }

            return stringContent;
        }

        private Dictionary<int, int> getListLinesPerTask(int numberOfTimes) {
            int lines = NumberOfLines / numberOfTimes;
            int rest = NumberOfLines % numberOfTimes;

            Dictionary<int, int> list = new Dictionary<int, int>();

            for (int i = 0; i < numberOfTimes; i++)
            {
                if (i == numberOfTimes - 1)
                {
                    list.Add(i, lines + rest);
                    continue;
                }
                list.Add(i, lines);
            }

            return list;
        }

        private StringBuilder GenerateStringBuilder(int lines) {
            StringBuilder stringContent = new StringBuilder();
            for (int i = 0; i < lines; i++)
            {
                stringContent.AppendLine(CodeUtils.Generate(this.LengthContent));
            };
            return stringContent;
        }
    }
}

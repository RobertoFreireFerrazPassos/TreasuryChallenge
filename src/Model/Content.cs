using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
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

        public StringBuilder GenerateStringBuilder(int lines) {
            StringBuilder stringContent = new StringBuilder();
            for (int i = 0; i < lines; i++)
            {
                stringContent.AppendLine(TreasuryUtils.GenerateCode(this.MaxLengthContent));
            };
            return stringContent;
        }
    }
}

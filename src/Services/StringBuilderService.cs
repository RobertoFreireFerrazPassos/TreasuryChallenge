using System.Collections.Generic;
using System.Text;
using TreasuryChallenge.Interface;

namespace TreasuryChallenge.Services
{
    public class StringBuilderService : IStringBuilderService
    {
        private StringBuilder stringContent = new StringBuilder();
        private HashSet<string> stringContentList = new HashSet<string>();

        public bool Append(string value) {
            bool added = stringContentList.Add(value);

            if (added) stringContent.AppendLine(value);

            return added;
        }

        public StringBuilder GetStringContent() {
            return stringContent;
        }
    }
}

using System;
using TreasuryChallenge.Common;
using TreasuryChallenge.Model;

namespace TreasuryChallenge.controller
{
    public class WriteFileController 
    {
        public IFile File { get; }
        public IContent Content { get; }

        public WriteFileController(
            IFile file,
            IContent content)
        {
            File = file;
            Content = content;
        }
        public void WriteCodeInFile(int inputValue)
        {
            try
            {
                var content = Content.Generate();
                File.WriteFile(Constants.FILE_NAME, content);
                Console.WriteLine(string.Format(Constants.FILE_WITH_0_LINES_WAS_GENERATED, inputValue));
            }
            catch (Exception ex)
            {
                Console.WriteLine(Constants.ERROR_TO_GENERATE_FILE + ex.Message);
            }
        }
    }
}

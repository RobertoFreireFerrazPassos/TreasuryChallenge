using TreasuryChallenge.Common;
using TreasuryChallenge.Model;
using TreasuryChallenge.Utils;

namespace TreasuryChallenge.controller
{
    public class WriteFileController 
    {
        public int InputValue { get; private set; }
        public WriteFileController(int inputValue)
        {
            this.InputValue = inputValue;
        }
        public void WriteCodeInFile(TemplateFile templateFile)
        {
            try
            {
                templateFile.WriteFile(this.InputValue);
                System.Console.WriteLine(string.Format(Constants.FILE_WITH_0_LINES_WAS_GENERATED, this.InputValue));
            }
            catch (System.Exception ex)
            {
                System.Console.WriteLine(Constants.ERROR_TO_GENERATE_FILE + ex.Message);
            }
        }
    }
}

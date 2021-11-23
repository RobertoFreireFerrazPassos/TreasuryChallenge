using TreasuryChallenge.Model;

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
                System.Console.WriteLine($"A file with {this.InputValue} lines was generated.");
            }
            catch (System.Exception ex)
            {
                System.Console.WriteLine($"Error to generete File: {ex.Message}");
            }
        }
    }
}

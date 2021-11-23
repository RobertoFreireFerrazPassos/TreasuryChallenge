using TreasuryChallenge.Common;

namespace TreasuryChallenge.Model
{
    public interface TemplateFile
    {
        void WriteFile(int inputValue);
        string GenerateContent(string content = Constants.EMPTY_STRING);
    }
}
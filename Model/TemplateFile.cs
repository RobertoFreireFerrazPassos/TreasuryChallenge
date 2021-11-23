namespace TreasuryChallenge.Model
{
    public interface TemplateFile
    {
        void WriteFile(int inputValue);
        string GenerateContent(string content = "");
    }
}
using System.Text;

namespace TreasuryChallenge.Model
{
    public interface IFileService
    {
        public void WriteFile(string fileName, StringBuilder stringContent);
    }
}
using System.Text;

namespace TreasuryChallenge.Model
{
    public interface IFile
    {
        public void WriteFile(string fileName, StringBuilder stringContent);
    }
}
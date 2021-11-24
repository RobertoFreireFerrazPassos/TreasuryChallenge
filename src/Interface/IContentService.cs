using System.Text;

namespace TreasuryChallenge.Model
{
    public interface IContentService
    {
        public StringBuilder Generate();
        public int GetNumberOfLines();
    }
}

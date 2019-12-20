using System.Threading.Tasks;

namespace Advent2019.Intcode
{
    public interface IInput
    {
        Task<int> GetNextAsync();
    }
}
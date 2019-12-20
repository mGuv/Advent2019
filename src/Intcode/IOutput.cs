using System.Threading.Tasks;

namespace Advent2019.Intcode
{
    public interface IOutput
    {
        Task WriteAsync(int value);
    }
}
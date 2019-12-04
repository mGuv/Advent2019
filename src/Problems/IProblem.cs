using System.Threading;
using System.Threading.Tasks;

namespace Advent2019.Problems
{
    public interface IProblem
    {
        int Day { get; }
        string Title { get; }
        string Part1Title { get; }
        string Part2Title { get; }

        Task RunPart1Async(CancellationToken cancellationToken);
        Task RunPart2Async(CancellationToken cancellationToken);
    }
}
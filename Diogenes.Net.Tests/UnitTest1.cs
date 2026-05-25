using Diogenes.Web;
using Microsoft.Extensions.Logging.Abstractions;
using System.Text;

namespace Diogenes.Web.Tests;

public class RunnerTests
{
    [Fact]
    public void Run_ReturnsNumbersZeroToNine()
    {
        var runner = new Runner(NullLogger<Runner>.Instance);

        var result = runner.Run();

        Assert.Equal(Enumerable.Range(0, 10), result);
    }
}
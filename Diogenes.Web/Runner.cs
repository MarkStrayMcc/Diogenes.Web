namespace Diogenes.Web;

public interface IRunner
{
    IReadOnlyList<int> Run();
}

public class Runner : IRunner
{
    private readonly ILogger<Runner> logger;

    public Runner(ILogger<Runner> logger)
    {
        this.logger = logger;
    }

    public IReadOnlyList<int> Run()
    {
        var outputs = new List<int>();

        for (var i = 0; i < 10; i++)
        {
            outputs.Add(i);
            logger.LogInformation("Runner output ---- {Output}", i);
        }

        return outputs;
    }
}
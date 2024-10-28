using System.Linq;
using UniNetty.Examples.DemoSupports;

namespace UniNetty.Examples.Demo.UI;

public class ExamplesViewModel
{
    public readonly UniNettyExample[] Examples;

    public ExamplesViewModel(UniNettyExampleContext context)
    {
        var ip = UniNettyExampleSupports.GetPrivateIp();
        var examples = UniNettyExampleSupports.CreateDefaultExamples(context.Cert, ip);
        Examples = new UniNettyExample[UniNettyExampleType.Values.Count];

        foreach (var t in UniNettyExampleType.Values)
        {
            Examples[t.Index] = examples[t];
        }
    }
}
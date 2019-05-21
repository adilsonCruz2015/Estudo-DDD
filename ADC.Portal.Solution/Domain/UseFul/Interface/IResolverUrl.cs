

namespace ADC.Portal.Solution.Domain.UseFul.Interface
{
    public interface IResolverUrl
    {
        string Code(string url);

        string Decode(string url);
    }
}

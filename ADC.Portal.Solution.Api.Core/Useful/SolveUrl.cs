using ADC.Portal.Solution.Domain.UseFul.Interface;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Extensions;


namespace ADC.Portal.Solution.Api.Core.Useful
{
    public class SolveUrl : IResolverUrl
    {
        public SolveUrl(IHttpContextAccessor httpContextAccessor,
                        IHostingEnvironment hostingEnvironment)
        {
            _httpContextAccessor = httpContextAccessor;
            _hostingEnvironment = hostingEnvironment;
        }

        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IHostingEnvironment _hostingEnvironment;

        public string Code(string url)
        {
            return _httpContextAccessor.HttpContext.Request.GetDisplayUrl();
        }

        public string Decode(string url)
        {
            return _hostingEnvironment.
        }
    }
}

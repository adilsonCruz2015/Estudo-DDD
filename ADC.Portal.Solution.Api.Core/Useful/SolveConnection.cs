
using ADC.Portal.Solution.Domain.Interfaces.Repositories;
using Microsoft.AspNetCore.Http;
using System.Collections.Generic;
using System.Configuration;

namespace ADC.Portal.Solution.Api.Core.Useful
{
    public class SolveConnection : ISolveConnection
    {
        public SolveConnection(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }
        
        private readonly IHttpContextAccessor _httpContextAccessor;
        private static string _reference;
        private static string _connection;

        public string GetConnection()
        {
            if (string.IsNullOrWhiteSpace(_connection))
                _connection = ExtractConnextion();

            return _connection;
        }

        public string GetReference()
        {
            if (string.IsNullOrWhiteSpace(_reference))
                _reference = ExtractReference();

            return _reference;
        }

        private string ExtractReference()
        {
            IDictionary<string, string> references = new Dictionary<string, string>();
            references.Add("local", "ADC.Portal.Solution-Local");
            references.Add("test", "ADC.Portal.Solution-Test");
            references.Add("homologation", "ADC.Portal.Solution-homologation");
            references.Add("production", "ADC.Portal.Solution-production");

            if (DetectarServidor.IsLocal())
                return references["local"];
            else if (DetectarServidor.IsTest())
                return references["teste"];
            else if (DetectarServidor.IsHomologation())
                return references["homologacao"];

            return references["producao"];
        }

        private string ExtractConnextion()
        {
            return ConfigurationManager.ConnectionStrings[this.GetReference()].ToString();
        }
    }
}

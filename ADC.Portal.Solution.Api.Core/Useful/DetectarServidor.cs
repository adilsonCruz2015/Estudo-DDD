

using System;
using System.Collections.Generic;
using System.Configuration;
using System.Text.RegularExpressions;

namespace ADC.Portal.Solution.Api.Core.Useful
{
    public static class DetectarServidor
    {
        /// <summary>
        /// return true if the current server is local
        /// </summary>
        /// <returns></returns>
        public static bool IsLocal()
        {
            return Server == "local";
        }

        /// <summary>
        /// return true if the current server is test
        /// </summary>
        /// <returns></returns>
        public static bool IsTest()
        {
            return Server == "teste";
        }

        /// <summary>
        /// return true if the current server is Homologation
        /// </summary>
        /// <returns></returns>
        public static bool IsHomologation()
        {
            return Server == "homologacao";
        }

        /// <summary>
        /// return true if the current server is Production
        /// </summary>
        /// <returns></returns>
        public static bool EhProducaco()
        {
            return Server == "producaco";
        }

        /// <summary>
        /// Allows the server to be started, depending on whether it has already been defined
        /// </summary>
        public static void Initialize()
        {
            _server = Detect();
        }

        private static string _server;

        private static string Server
        {
            get { return _server ?? (_server = Detect());  }
        }

        private static string Detect()
        {
            IDictionary<string, string> servers = new Dictionary<string, string>();
            servers.Add("local", ConfigurationManager.AppSettings["app:Servidor-Local"].ToLower());
            servers.Add("teste", ConfigurationManager.AppSettings["app:Servidor-Teste"].ToLower());
            servers.Add("homologacao", ConfigurationManager.AppSettings["app:Servidor-Homologacao"].ToLower());

            string host = AppDomain.CurrentDomain.BaseDirectory.ToLower();
            string servidorForcado = ConfigurationManager.AppSettings["app:Forcar-Servidor"].ToLower();
            servidorForcado = !string.IsNullOrWhiteSpace(servidorForcado) ? servidorForcado : null;

            if (Regex.IsMatch(host, servers["local"]))
                return servidorForcado ?? "local";
            else if (Regex.IsMatch(host, servers["teste"]))
                return servidorForcado ?? "teste";
            else if (Regex.IsMatch(host, servers["homologacao"]))
                return servidorForcado ?? "homologacao";

            return "producao";
        }
    }
}

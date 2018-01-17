using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ACL.SimplesNacional.Client.DiferencaAliquota;

namespace ACL.SimplesNacional.Client
{
    public class SimplesNacionalClient : IDisposable
    {
        private readonly HttpClientOAuth httpClient;
        private readonly Uri baseUri;

        public SimplesNacionalClient(
            string clienteId,
            string clienteSenha,
            string urlApi = "https://simplesnacional.aclti.com.br",
            string urlAutenticacao = "https://auth.aclti.com.br"
            )
        {
            if (string.IsNullOrEmpty(clienteId))
                throw new ArgumentNullException(nameof(clienteId));

            if (string.IsNullOrEmpty(clienteSenha))
                throw new ArgumentNullException(nameof(clienteSenha));

            if (string.IsNullOrEmpty(urlApi))
                throw new ArgumentNullException(nameof(urlApi));

            if (string.IsNullOrEmpty(urlAutenticacao))
                throw new ArgumentNullException(nameof(urlAutenticacao));

            httpClient = new HttpClientOAuth(
                clienteId,
                clienteSenha,
                urlAutenticacao);

            baseUri = new Uri(urlApi);
        }

        public void Dispose()
        {
            httpClient.Dispose();
        }

        public Task<IEnumerable<ResultadoAnalise<ValoresDiferencaAliquota>>> ListarDiferencasAliquota(string codigoTOM)
        {
            if (string.IsNullOrWhiteSpace(codigoTOM))
                throw new ArgumentNullException(nameof(codigoTOM));

            return httpClient.GetJson<IEnumerable<ResultadoAnalise<ValoresDiferencaAliquota>>>(UriApi($"api/siga/diferenca-aliquota/{codigoTOM}"));
        }

        private Uri UriApi(string urlRelativa) => new Uri(baseUri, urlRelativa);
    }
}
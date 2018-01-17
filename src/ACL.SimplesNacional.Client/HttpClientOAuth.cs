using System;
using System.Net.Http;
using System.Threading.Tasks;
using IdentityModel.Client;
using Newtonsoft.Json;

namespace ACL.SimplesNacional.Client
{
    internal class HttpClientOAuth : IDisposable
    {
        private readonly string clienteId;
        private readonly string clienteSenha;
        private readonly string urlAutenticacao;

        private HttpClient httpClient;

        public HttpClientOAuth(string clienteId, string clienteSenha, string urlAutenticacao)
        {
            this.clienteId = clienteId;
            this.clienteSenha = clienteSenha;
            this.urlAutenticacao = urlAutenticacao;
        }

        public void Dispose()
        {
            if (httpClient != null)
                httpClient.Dispose();
        }

        public async Task<T> GetJson<T>(Uri uri)
        {
            var client = await AutenticarHttpClient();

            var response = await client.GetAsync(uri);
            response.EnsureSuccessStatusCode();

            var content = await response.Content.ReadAsStringAsync();
            var json = JsonConvert.DeserializeObject<T>(content);

            return json;
        }

        private async Task<HttpClient> AutenticarHttpClient()
        {
            if (httpClient != null)
                return httpClient;
            
            var token = await RequisitarToken();
            httpClient = new HttpClient();
            httpClient.SetBearerToken(token);

            return httpClient;
        }

        private async Task<string> RequisitarToken()
        {
            var discoClient = new DiscoveryClient(urlAutenticacao);
            var disco = await discoClient.GetAsync();

            if (disco.IsError)
                throw disco.Exception;

            var tokenClient = new TokenClient(disco.TokenEndpoint, clienteId, clienteSenha);
            var response = await tokenClient.RequestClientCredentialsAsync("sn");

            return response.AccessToken;
        }
    }
}

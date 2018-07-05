using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading;
using System.Threading.Tasks;
using IdentityModel.Client;

namespace ACL.SimplesNacional.Client
{
    internal class OAuthHttpHandler : DelegatingHandler
    {
        private readonly string _clienteId;
        private readonly string _clienteSenha;
        private readonly string _urlAutenticacao;

        private string _accessToken;

        public OAuthHttpHandler(string clienteId, string clienteSenha, string urlAutenticacao)
        {
            _clienteId = clienteId;
            _clienteSenha = clienteSenha;
            _urlAutenticacao = urlAutenticacao;

            InnerHandler = new HttpClientHandler();
        }

        protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            if (request.Headers.Authorization == null)
            {
                if (_accessToken == null)
                    _accessToken = await RequisitarToken(cancellationToken);

                request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", _accessToken);
            }

            return await base.SendAsync(request, cancellationToken);
        }

        private async Task<string> RequisitarToken(CancellationToken cancellationToken)
        {
            DiscoveryResponse disco;
            using (var discoClient = new DiscoveryClient(_urlAutenticacao))
            {
                disco = await discoClient.GetAsync(cancellationToken);
                if (disco.IsError)
                    throw disco.Exception;
            }

            using (var tokenClient = new TokenClient(disco.TokenEndpoint, _clienteId, _clienteSenha))
            {
                var response = await tokenClient.RequestClientCredentialsAsync(
                    scope: "sn",
                    cancellationToken: cancellationToken
                    );

                return response.AccessToken;
            }
        }
    }
}

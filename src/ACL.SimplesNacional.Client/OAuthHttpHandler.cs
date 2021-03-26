using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading;
using System.Threading.Tasks;
using IdentityModel.Client;

namespace ACL.SimplesNacional.Client
{
    public class OAuthHttpHandler : DelegatingHandler
    {
        private readonly string _clienteId;
        private readonly string _clienteSenha;
        private readonly string _escopo = "sn, dec";
        private readonly string _urlAutenticacao;
        private readonly string _loginUsuario;
        private readonly string _senhaUsuario;
        private readonly IDictionary<string, string> _claims;

        private Token _accessToken;

        public OAuthHttpHandler(
            string urlAutenticacao,
            string clientId,
            string clientSenha)
        {
            _urlAutenticacao = urlAutenticacao;
            _clienteId = clientId;
            _clienteSenha = clientSenha;

            InnerHandler = new HttpClientHandler();
        }

        public OAuthHttpHandler(
            string urlAutenticacao,
            string clientId,
            string clientSenha,
            IDictionary<string, string> claims,
            string usuario = null,
            string senha = "123456") : this(urlAutenticacao, clientId, clientSenha)
        {
            _urlAutenticacao = urlAutenticacao;
            _clienteId = clientId;
            _clienteSenha = clientSenha;
            _loginUsuario = usuario;
            _senhaUsuario = senha;
            _claims = claims;

            InnerHandler = new HttpClientHandler();
        }

        public async Task<Token> ObterAcessTokenAsync()
        {
            if (_accessToken == null)
                _accessToken = await RequisitarToken();

            return _accessToken;
        }

        protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            if (request.Headers.Authorization == null)
            {
                if (_accessToken == null)
                    _accessToken = await RequisitarToken();

                request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", _accessToken.Access);
            }

            return await base.SendAsync(request, cancellationToken);
        }

        private async Task<Token> RequisitarToken()
        {
            using (var client = new HttpClient())
            {
                var disco = await client.GetDiscoveryDocumentAsync(new DiscoveryDocumentRequest
                {
                    Address = _urlAutenticacao,
                    Policy = new DiscoveryPolicy
                    {
                        RequireHttps = _urlAutenticacao.ToLower().StartsWith("https")
                    }
                });

                if (disco.IsError)
                    throw disco.Exception;

                if (!string.IsNullOrEmpty(_loginUsuario) && _claims != null)
                {
                    var responseToken = await client.RequestPasswordTokenAsync(new PasswordTokenRequest
                    {
                        Address = disco.TokenEndpoint,

                        ClientId = _clienteId,
                        ClientSecret = _clienteSenha,
                        Scope = _escopo,

                        UserName = _loginUsuario,
                        Password = _senhaUsuario,
                        Parameters = _claims
                    });

                    if (responseToken.IsError)
                        throw new UnauthorizedAccessException();

                    var handler = new JwtSecurityTokenHandler();
                    var securityToken = handler.ReadToken(responseToken.AccessToken) as JwtSecurityToken;

                    return new Token
                    {
                        Access = responseToken.AccessToken,
                        Claims = securityToken.Payload.SerializeToJson()
                    };
                }

                var response = await client.RequestClientCredentialsTokenAsync(new ClientCredentialsTokenRequest
                {
                    Address = disco.TokenEndpoint,

                    ClientId = _clienteId,
                    ClientSecret = _clienteSenha,
                    Scope = _escopo,
                });

                return new Token
                {
                    Access = response.AccessToken
                };
            }
        }
    }
}

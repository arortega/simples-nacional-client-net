using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace ACL.SimplesNacional.Client
{
    /// <summary>
    /// Client de consulta a dados e análises do Simples Nacional
    /// </summary>
    public sealed class SimplesNacionalClient : IDisposable
    {
        private static readonly string UrlApiFiscalizacao = "https://simplesnacional-treinamento.aclti.com.br/api/fiscalizacao";
        private readonly string urlAutenticacao;
        private readonly string clientId;
        private readonly string clientSenha;

        public SimplesNacionalClient(string urlAutenticacao, string clientId, string clientSenha)
        {
            this.urlAutenticacao = urlAutenticacao;
            this.clientId = clientId;
            this.clientSenha = clientSenha;
        }

        public Task<Token> ObterUserToken(string login, string senha, IDictionary<string, string> claims)
        {
            using (var oauth = new OAuthHttpHandler(urlAutenticacao, clientId, clientSenha, claims, login, senha))
            {
                return oauth.ObterAcessTokenAsync();
            }
        }
    
        public async Task<IEnumerable<SituacaoFical>> ObterSituacoesFiscais(IEnumerable<string> cnpjs)
        {
            var resultado = new List<SituacaoFical>();

            using (var client = new HttpClient(new OAuthHttpHandler(urlAutenticacao, clientId, clientSenha)) { BaseAddress = new Uri($"{UrlApiFiscalizacao}/") })
            {
                foreach (var cnpj in cnpjs)
                {
                    var enquadramentos = await client.GetJsonAsync<IEnumerable<Enquadramento>>($"potenciais/enquadramentos?cnpj={cnpj}&status=1");

                    if (enquadramentos.Any())
                        resultado.Add(new SituacaoFical
                        {
                            Cnpj = cnpj,
                            Total = enquadramentos.Count()
                        });
                }

                return resultado;
            }
        }

        public async Task<IEnumerable<Enquadramento>> ObterEnquadramentos(string cnpj)
        {
            using (var client = new HttpClient(new OAuthHttpHandler(urlAutenticacao, clientId, clientSenha)) { BaseAddress = new Uri($"{UrlApiFiscalizacao}/") })
            {
                var enquadramentos = await client.GetJsonAsync<IEnumerable<Enquadramento>>($"potenciais/enquadramentos?cnpj={cnpj}&tipo=4&status=1&divergente=true");
                return enquadramentos;
            }
        }

        public void Dispose()
        {
        }
    }
}

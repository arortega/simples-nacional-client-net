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
        private readonly string UrlApiFiscalizacao;
        private readonly OAuthHttpHandler oAuthHttpHandler;
        public SimplesNacionalClient(OAuthHttpHandler oAuthHttpHandler, Ambiente ambiente = Ambiente.Producao)
        {
            this.oAuthHttpHandler = oAuthHttpHandler;
            this.UrlApiFiscalizacao = ambiente switch
            {
                Ambiente.Producao => "https://simplesnacional.aclti.com.br/api/fiscalizacao",
                Ambiente.Homologacao => "https://simplesnacional-homologacao.aclti.com.br/api/fiscalizacao",
                _ => "https://simplesnacional-treinamento.aclti.com.br/api/fiscalizacao"
            };
        }

        public async Task<IEnumerable<SituacaoFical>> ObterSituacoesFiscais(IEnumerable<string> cnpjs)
        {
            var resultado = new List<SituacaoFical>();

            using var client = new HttpClient(oAuthHttpHandler) { BaseAddress = new Uri($"{UrlApiFiscalizacao}/") };
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

        public async Task<IEnumerable<Enquadramento>> ObterEnquadramentos(string cnpj)
        {
            using var client = new HttpClient(oAuthHttpHandler) { BaseAddress = new Uri($"{UrlApiFiscalizacao}/") };
            var enquadramentos = await client.GetJsonAsync<IEnumerable<Enquadramento>>($"potenciais/enquadramentos?cnpj={cnpj}&tipo=4&status=1&divergente=true");
            return enquadramentos;
        }

        public void Dispose()
        {
            oAuthHttpHandler.Dispose();
        }
    }
}

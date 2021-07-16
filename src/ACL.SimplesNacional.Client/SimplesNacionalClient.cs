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
        private readonly string UrlApiDEC;
        private readonly OAuthHttpHandler oAuthHttpHandler;
        public SimplesNacionalClient(OAuthHttpHandler oAuthHttpHandler, Ambiente ambiente = Ambiente.Producao)
        {
            this.oAuthHttpHandler = oAuthHttpHandler;
            this.UrlApiFiscalizacao = ambiente switch
            {
                Ambiente.Producao => "https://simplesnacional.aclti.com.br/api/fiscalizacao",
                Ambiente.Homologacao => "https://simplesnacional-homologacao-ssa.aclti.com.br/api/fiscalizacao",
                _ => "https://simplesnacional-treinamento.aclti.com.br/api/fiscalizacao"
            };

            this.UrlApiDEC = ambiente switch
            {
                Ambiente.Producao => "https://decv2.aclti.com.br/api",
                Ambiente.Homologacao => "https://decv2-homologacao.aclti.com.br/api",
                _ => "https://decv2-treinamento.aclti.com.br/api"
            };
        }

        public async Task<IEnumerable<SituacaoFiscal>> ObterSituacoesFiscais(IEnumerable<string> cnpjs)
        {
            var resultado = new List<SituacaoFiscal>();

            using var client = new HttpClient(oAuthHttpHandler, false) { BaseAddress = new Uri($"{UrlApiFiscalizacao}/") };
            foreach (var cnpj in cnpjs)
            {
                var enquadramentos = await client.GetJsonAsync<IEnumerable<Enquadramento>>($"potenciais/enquadramentos?cnpj={cnpj}&status=1");

                if (enquadramentos.Any())
                    resultado.Add(new SituacaoFiscal
                    {
                        Cnpj = cnpj,
                        Total = enquadramentos.Count()
                    });
            }

            return resultado;
        }

        public async Task<IEnumerable<Enquadramento>> ObterEnquadramentos(string cnpj)
        {
            using var client = new HttpClient(oAuthHttpHandler, false) { BaseAddress = new Uri($"{UrlApiFiscalizacao}/") };
            var enquadramentos = await client.GetJsonAsync<IEnumerable<Enquadramento>>($"potenciais/enquadramentos?cnpj={cnpj}&divergente=true");
            return enquadramentos;
        }

        public async Task<IEnumerable<ResumoMensagemIntegracao>> ObterMensagensNaoLidas(string cnpj)
        {
            using var client = new HttpClient(oAuthHttpHandler, false) { BaseAddress = new Uri($"{UrlApiDEC}/") };
            var mensagens = await client.GetJsonAsync<IEnumerable<ResumoMensagemIntegracao>>($"mensagens/ListarMensagensIntegracao?naoLidas=true");
            return mensagens;
        }

        public void Dispose()
        {
            oAuthHttpHandler.Dispose();
        }
    }
}

using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ACL.SimplesNacional.Client.DiferencaAliquota;
using ACL.SimplesNacional.Client.Eventos;
using ACL.SimplesNacional.Client.Sublimites;

namespace ACL.SimplesNacional.Client
{
    /// <summary>
    /// Client de consulta a dados e análises do Simples Nacional
    /// </summary>
    public class SimplesNacionalClient : IDisposable
    {
        private readonly HttpClientOAuth httpClient;
        private readonly Uri baseUri;

        /// <summary>
        /// Inicializa uma instância do client de consulta ao Simples Nacional
        /// </summary>
        /// <param name="clienteId">Id utilizada para autenticação</param>
        /// <param name="clienteSenha">Senha utilizada para autenticação</param>
        /// <param name="urlApi">URL da API do Simplse Nacional</param>
        /// <param name="urlAutenticacao">URL do servidor de autenticação</param>
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

        /// <summary>
        /// Análise de diferenças de alíquotas declaradas em NFSes
        /// </summary>
        /// <param name="codigoTOM">Código TOM do município</param>
        /// <returns>Lista de NFSes declaradas com alíquotas incorretas e potencial de arrecadação</returns>
        public Task<IEnumerable<ResultadoAnalise<ValoresDiferencaAliquota>>> ListarDiferencasAliquota(string codigoTOM)
        {
            if (string.IsNullOrWhiteSpace(codigoTOM))
                throw new ArgumentNullException(nameof(codigoTOM));

            return httpClient.GetJson<IEnumerable<ResultadoAnalise<ValoresDiferencaAliquota>>>(UriApi($"api/analise/enquadramentos/diferencaaliquota/{codigoTOM}"));
        }

        /// <summary>
        /// Listagem de eventos do simples nacional para um CNPJ base
        /// </summary>
        /// <param name="cnpjBase">CNPJ base do contribuinte</param>
        /// <returns>Lista de eventos do Simples Nacional</returns>
        public Task<IEnumerable<Evento>> ListarEventos(string cnpjBase)
        {
            if (string.IsNullOrWhiteSpace(cnpjBase))
                throw new ArgumentNullException(nameof(cnpjBase));

            return httpClient.GetJson<IEnumerable<Evento>>(UriApi($"api/analise/eventos/{cnpjBase}"));
        }

        /// <summary>
        /// Listagem de contribuintes que ultrapassaram o sublimite estadual ou nacional
        /// </summary>
        /// <param name="codigoTOM">Código TOM do município</param>
        /// <param name="ano">Ano analisado</param>
        /// <returns>Lista de contribuintes que devem ser cobrados via DAM no ano requisitado</returns>
        public Task<IEnumerable<AnaliseSublimite>> ListarSublimites(string codigoTOM, int ano)
        {
            if (string.IsNullOrWhiteSpace(codigoTOM))
                throw new ArgumentNullException(nameof(codigoTOM));

            return httpClient.GetJson<IEnumerable<AnaliseSublimite>>(UriApi($"api/analise/sublimites/{codigoTOM}/{ano}"));
        }

        /// <summary>
        /// Análise dos eventos do contribuinte para obter a situação cadastral em determinada data
        /// </summary>
        /// <param name="cnpjBase">CNPJ base do contribuinte</param>
        /// <param name="data">Data de referência para consulta da situação</param>
        /// <returns>Situação cadastral do contribuinte no Simples Nacional e MEI</returns>
        public Task<SituacaoContribuinte> ObterSituacaoContribuinte(string cnpjBase, DateTime? data = null)
        {
            if (string.IsNullOrWhiteSpace(cnpjBase))
                throw new ArgumentNullException(nameof(cnpjBase));

            var urlConsulta = $"api/analise/eventos/{cnpjBase}/situacao";
            if (data.HasValue)
                urlConsulta += $"?data={data.Value:u}";

            return httpClient.GetJson<SituacaoContribuinte>(UriApi(urlConsulta));
        }

        /// <summary>
        /// Cria uma Uri completa a partir de um caminho relativo
        /// </summary>
        /// <param name="urlRelativa">Caminho relativo da URL</param>
        /// <returns>Uri da API</returns>
        private Uri UriApi(string urlRelativa) => new Uri(baseUri, urlRelativa);
    }
}
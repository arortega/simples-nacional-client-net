using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using ACL.SimplesNacional.Client.DiferencaAliquota;
using Newtonsoft.Json;

namespace ACL.SimplesNacional.Client
{
    public class SimplesNacionalClient : IDisposable
    {
        private readonly HttpClient client;

        public SimplesNacionalClient(string url)
        {
            if (string.IsNullOrEmpty(url))
                throw new ArgumentNullException(nameof(url));

            client = new HttpClient
            {
                BaseAddress = new Uri(url)
            };
        }

        public void Dispose()
        {
            client.Dispose();
        }

        public async Task<IEnumerable<ResultadoAnalise<ValoresDiferencaAliquota>>> ListarDiferencasAliquota(string codigoTOM)
        {
            if (string.IsNullOrWhiteSpace(codigoTOM))
                throw new ArgumentNullException(nameof(codigoTOM));

            //TODO: quando Simples Nacional novo estiver publicado, passar código TOM como parâmetro da consulta 
            var response = await client.GetAsync("api/enquadramentos");
            response.EnsureSuccessStatusCode();

            var content = await response.Content.ReadAsStringAsync();
            var lista = JsonConvert.DeserializeObject<IEnumerable<ResultadoAnalise<ValoresDiferencaAliquota>>>(content);

            return lista;
        }
    }
}

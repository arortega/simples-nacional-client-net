using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ACL.SimplesNacional.Client;

namespace ConsoleApp
{
    class Program
    {
        static async Task Main()
        {
            Console.WriteLine();
            Console.WriteLine("Realizando consulta, aguarde...");

            var claims = new Dictionary<string, string>
            {
                { "role" , "sn-contrib" },
                { "name" , "Cecília Silva" },
                { "matricula" , "123456"},
                { "cnpjs", "32577504000165"}
            };

            var handler = new OAuthHttpHandler("demo_client", "demoC@123#!", claims, "32577504000165");


            using var client = new SimplesNacionalClient(handler, Ambiente.Treinamento);
            var enquadramentos = await client.ObterEnquadramentos("32577504000165");

            foreach (var enquadramento in enquadramentos)
            {
                Console.WriteLine($"Ano: {enquadramento.Ano}/Mês: {enquadramento.Mes} - Tipo: {enquadramento.Tipo} - Status: {enquadramento.Status} - Divergente: {enquadramento.Divergente}");
            }
        }
    }
}
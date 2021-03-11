using System;
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

            using var client = new SimplesNacionalClient("https://auth.aclti.com.br", "demo_client", "demoC@123#!");
            var enquadramentos = await client.ObterEnquadramentos("36463545000181");

            foreach (var enquadramento in enquadramentos)
            {
                Console.WriteLine($"Ano: {enquadramento.Ano}/Mês: {enquadramento.Mes} - Tipo: {enquadramento.Tipo} - Status: {enquadramento.Status} - Divergente: {enquadramento.Divergente}");
            }
        }
    }
}
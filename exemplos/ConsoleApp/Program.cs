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
                { "cnpjs", "13300804000158"}
            };

            var handler = new OAuthHttpHandler("demo_client", "demoC@123#!", claims, "13300804000158");

            using var client = new SimplesNacionalClient(handler, Ambiente.Homologacao);

            var mensagens = await client.ObterMensagensNaoLidas("13300804000158");
            var situacoes = await client.ObterSituacoesFiscais(new List<string> { "13300804000158" });
            var enquadramentos = await client.ObterEnquadramentos("13300804000158");

            foreach (var mensagem in mensagens)
            {
                Console.WriteLine($"Assunto: {mensagem.Assunto} - Enviada em: {mensagem.DataEnvio} - Para: {mensagem.Para} - Lida: {(mensagem.Lida ? "Sim" : "Não")} - Leitura em: {mensagem.DataLeitura}");
            }
        }
    }
}
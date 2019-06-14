using System;
using System.Linq;
using System.Threading.Tasks;
using ACL.SimplesNacional.Client;

namespace ConsoleApp
{
    class Program
    {
        static async Task Main()
        {
            Console.Write("ID do cliente: ");
            var id = Console.ReadLine();

            Console.Write("Senha: ");
            var senha = Console.ReadLine();

            Console.WriteLine();
            Console.WriteLine("Realizando consulta, aguarde...");

            using (var client = new SimplesNacionalClient(id, senha))
            {
                var baseCalculoProprio = await client.ListarDivergencias<ValoresDiferencaBaseCalculoProprio>(
                    ano: 2017,
                    mes: 2,
                    dataCriacao: new DateTime(2018, 10, 10, 13, 40, 0, DateTimeKind.Utc)
                    );

                Console.WriteLine($"Api de divergências retornou {baseCalculoProprio.Count()} registros");

                var eventos = await client.ListarEventos("00000015");
                Console.WriteLine($"Api de eventos retornou {eventos.Count()} registros");

                var sublimites = await client.ListarSublimites("8531", 2018);
                Console.WriteLine($"Api de sublimites retornou {sublimites.Count()} registros");

                var situacao = await client.ObterSituacaoContribuinte("01311378");
                Console.WriteLine($"SN: {situacao.SimplesNacional?.Optante} / MEI: {situacao.MEI?.Optante}");
            }

            Console.ReadKey();
        }
    }
}
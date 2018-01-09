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
            Console.WriteLine("Digite a URL da API do Simples Nacional:");
            var url = Console.ReadLine();

            Console.WriteLine("Digite o código TOM do município que deseja consultar:");
            var codigoTOM = Console.ReadLine();

            Console.WriteLine(string.Empty);
            Console.WriteLine("Realizando consulta, aguarde...");

            var client = new SimplesNacionalClient(url);
            var lista = await client.ListarDiferencasAliquota(codigoTOM);

            Console.WriteLine($"Api retornou {lista.Count()} registros");
            Console.ReadKey();
        }
    }
}
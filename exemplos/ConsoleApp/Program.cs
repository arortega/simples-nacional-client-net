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
                var lista = await client.ListarDiferencasAliquota("3105");
                Console.WriteLine($"Api retornou {lista.Count()} registros");
            }

            Console.ReadKey();
        }
    }
}
using System.Collections.Generic;
using System.Threading.Tasks;
using ACL.SimplesNacional.Client;
using Microsoft.AspNetCore.Mvc;

namespace DemoGSN.Web.Controllers
{
    public class SimplesNacionalController : Controller
    {
        public async Task<IActionResult> Index()
        {
            var claims = new Dictionary<string, string>
            {
                { "role" , "sn-contrib" },
                { "name" , "Cecília Silva" },
                { "matricula" , "123456"},
                { "cnpjs", "32577504000165"}
            };

            var token = await new OAuthHttpHandler("demo_client", "demoC@123#!", claims, "32577504000165").ObterAcessTokenAsync();

            ViewData.Add("accessToken", token.Access);
            ViewData.Add("claims", token.Claims);
            ViewData.Add("Versao", System.Reflection.Assembly.GetExecutingAssembly().GetName().Version.ToString());

            ViewData.Add("ApiAnalise", "https://simplesnacional-treinamento.aclti.com.br/api/fiscalizacao");
            ViewData.Add("ApiFiscalizacao", "https://simplesnacional-treinamento.aclti.com.br/api/fiscalizacao");
            ViewData.Add("ApiDTE", "https://simplesnacional-treinamento.aclti.com.br/api/dte");
            ViewData.Add("ApiImportacaoGerencial", "https://simplesnacional-treinamento.aclti.com.br/api/importacaoGerencial");

            return View();
        }
    }
}

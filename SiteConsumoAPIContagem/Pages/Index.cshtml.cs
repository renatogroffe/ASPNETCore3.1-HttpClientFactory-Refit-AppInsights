using System.Text.Json;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using SiteConsumoAPIContagem.Interfaces;

namespace SiteConsumoAPIContagem.Pages
{
    public class IndexModel : PageModel
    {
        public void OnGet(
            [FromServices]IConfiguration configuration,
            [FromServices]ILogger<IndexModel> logger,
            [FromServices]IContagemClient contagemClient)
        {
            var resultado = contagemClient.GetResultado().Result;
            logger.LogInformation($"APIContagem: {resultado}");

            TempData["ValorContador"] = resultado.ValorAtual;
            TempData["ResultadoAPIContagem"] =
                JsonSerializer.Serialize(resultado);
            TempData["Saudacao"] = configuration["Mensagens:Saudacao"];
            TempData["Local"] = configuration["Mensagens:Local"];
        }
    }
}
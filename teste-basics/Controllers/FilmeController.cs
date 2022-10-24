using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Models;

namespace Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class FilmeController : ControllerBase
    {
        private static List<Filme> filmes = new List<Filme>();
        
        
        [HttpPost] // HttpPost indica que é um método Post de acordo com o padrão REST
        public void AdicionarFilme([FromBody] Filme filme) // FromBody indica que o parâmetro será passado no body da requisição
        {
            filmes.Add(filme);
            Console.WriteLine(filme.Titulo);
        }

        /*
        [HttpGet]
        public void VerFilme()
        {
            
            Console.WriteLine("Estou vendo um filme!");
        }
        */

    }
}

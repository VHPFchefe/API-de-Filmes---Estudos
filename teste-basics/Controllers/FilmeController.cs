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
        private static int id= 1;

        [HttpPost] // HttpPost indica que é um método Post de acordo com o padrão REST
        public void AdicionarFilme([FromBody] Filme filme) // FromBody indica que o parâmetro será passado no body da requisição
        {
            filme.Id = id++;
            filmes.Add(filme);
        }

        
        [HttpGet] // HttpGet indica que é um método Get de acordo com o padrão REST
        /*public List<Filme> ListarFilme()*/
        public IEnumerable<Filme> ListarFilme() // Alterado para garantir a integridade do código para qualquer classe que implemente esta interface
        {
            return filmes;
        }
    }
}

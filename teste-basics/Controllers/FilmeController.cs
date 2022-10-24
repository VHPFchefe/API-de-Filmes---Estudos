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

        [HttpPost] // HttpPost indica que é um método Post de acordo com o padrão REST.
        public IActionResult AdicionarFilme([FromBody] Filme filme) // FromBody indica que o parâmetro será passado no body da requisição.
        {
            filme.Id = id++;
            filmes.Add(filme);
            return CreatedAtAction(nameof(ListarFilmePorId), new {ID = filme.Id} ,filme); // gera código 201 Created exibindo no HEADER Location qual rota utilizar para consumir a informação criada.
        }

        
        [HttpGet] // HttpGet indica que é um método Get de acordo com o padrão REST.
        /*public List<Filme> ListarFilme()*/
        public IActionResult ListarFilme() // Alterado para garantir a integridade do código para qualquer classe que implemente esta interface.
        {
            return Ok(filmes);
        }

        [HttpGet("{id}")] // HttpGet com um parâmetro de ID que deve ser passado na URL.
        /*public List<Filme> ListarFilme()*/
        public IActionResult ListarFilmePorId(int id)
        {
            Filme filme = filmes.FirstOrDefault(filme => filme.Id == id); // Retorna o ID procurado ou nulo como retorno padrão.
            if(filme != null) // Trata os retornos nulos.
            {
                return Ok(filme); // retorna o filme e gera status 200 ok.
            }
            return NotFound(); // retorna null e gera status 404 NotFound.
        }
    }
}

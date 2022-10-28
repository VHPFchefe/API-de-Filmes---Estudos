using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Data;
using Data.Dtos;
using Models;
using System.IO;
using AutoMapper;

namespace Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class FilmeController : ControllerBase
    {
        private FilmeContext _context;
        private IMapper _mapper;

        public FilmeController(FilmeContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpPost] // HttpPost indica que é um método Post de acordo com o padrão REST.
        public IActionResult AdicionarFilme([FromBody] CreateFilmeDto filmeDto) // FromBody indica que o parâmetro será passado no body da requisição.
        {
            Filme filme = _mapper.Map<Filme>(filmeDto);
            _context.Filmes.Add(filme);
            _context.SaveChanges(); // Consolida no banco de dados as alterações
            return CreatedAtAction(nameof(ListarFilmePorId), new {ID = filme.Id} ,filme); // gera código 201 Created exibindo no HEADER Location qual rota utilizar para consumir a informação criada.
        }

        
        [HttpGet] // HttpGet indica que é um método Get de acordo com o padrão REST.
        /*public List<Filme> ListarFilme()*/
        public IEnumerable<Filme> ListarFilme() // Alterado para garantir a integridade do código para qualquer classe que implemente esta interface.
        {
            return _context.Filmes;
        }

        [HttpGet("{id}")] // HttpGet com um parâmetro de ID que deve ser passado na URL.
        /*public List<Filme> ListarFilme()*/
        public IActionResult ListarFilmePorId(int id)
        {
            Filme filme = _context.Filmes.FirstOrDefault(filme => filme.Id == id); // Retorna o ID procurado ou nulo como retorno padrão.
            if(filme != null) // Trata os retornos nulos.
            {
                ReadFilmeDto readFilmeDto = _mapper.Map<ReadFilmeDto>(filme);
                return Ok(readFilmeDto); // retorna o filme e gera status 200 ok.
            }
            return NotFound(); // retorna null e gera status 404 NotFound.
        }

        [HttpPut("{id}")]
        public IActionResult AtualizarFilme(int id, [FromBody] UpdateFilmeDto filmeDto)
        {
            Filme filme = _context.Filmes.FirstOrDefault(filme => filme.Id == id);
            if(filme == null)
            {
                return NotFound();
            }
            _mapper.Map(filmeDto, filme);
            _context.SaveChanges(); // Consolida no banco de dados as alterações
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult RemoverFilme(int id)
        {
            Filme filme = _context.Filmes.FirstOrDefault(filme => filme.Id == id);
            if(filme == null)
            {
                return NotFound();
            }
            _context.Remove(filme);
            _context.SaveChanges();
            return NoContent(); // #duvida no caso da api rest usar o delete como padrão, como ficaria a questão do Hard delete e Soft delete ?
        }
    }
}

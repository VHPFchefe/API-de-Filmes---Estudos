using System;
using System.ComponentModel.DataAnnotations;

namespace Data.Dtos
{
    public class ReadFilmeDto
    {
        [Key] // Define como chave para identificação
        [Required]
        // Campo sequência para cada execução da API.

        public int Id { get; set; }
        // Definindo o Título como campo obrigatório no body
        [Required(ErrorMessage = "A requisição deve conter o campo Título!")]
        public string Titulo { get; set; }

        public string Diretor { get; set; }

        [StringLength(30, ErrorMessage = "O Gênero não deve conter mais que 30 caracteres!")]
        [Required(ErrorMessage = "A requisição deve conter o campo Gênero!")]
        public string Genero { get; set; }

        // Definindo a Duração como campo com um range de 1 a 600 inteiros no body
        [Range(1, 600, ErrorMessage = "O campo Duração deve conter de 1 a 600 minutos!")]
        public int Duracao { get; set; }

        public DateTime HoraDaConsulta { get; set; }

    }
}

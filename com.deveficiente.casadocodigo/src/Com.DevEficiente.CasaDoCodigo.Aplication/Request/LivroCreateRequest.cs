using Com.DevEficiente.CasaDoCodigo.Aplication.DataNotations;

namespace Com.DevEficiente.CasaDoCodigo.Aplication.Request
{
    public class LivroCreateRequest
    {
        [Required(ErrorMessage = "Título é obrigatório.")]
        [UniqueTitulo(ErrorMessage = "O título já existe no banco de dados.")]
        public string Titulo { get; set; }

        [Required(ErrorMessage = "Resumo é obrigatória")]
        [StringLength(500, MinimumLength = 1, ErrorMessage = "O Resumo não pode passar de 500 caracteres")]
        public string Resumo { get; set; }

        [Required(ErrorMessage = "Sumário é obrigatório.")]
        public string Sumario { get; set; }

        [Required(ErrorMessage = "Preço é obrigatório.")]
        [Range(20d, (double)decimal.MaxValue, ErrorMessage = "Preço é obrigatório e o mínimo é de 20")]
        public decimal Preco { get; set; }

        [Range(100, (double)decimal.MaxValue, ErrorMessage = "Número de páginas é obrigatória e o mínimo é de 100")]
        public int NumeroPaginas { get; set; }

        [Required(ErrorMessage = "Isbn é obrigatório.")]
        public string Isbn { get; set; }

        [DateTimeFuturo(ErrorMessage = "Data que vai entrar no ar precisa ser no futuro")]
        public DateTime DataPublicacao { get; set; }

        [Required(ErrorMessage = "A categoria não pode ser nula.")]
        public string Categoria { get; set; }

        [Required(ErrorMessage = "O autor não pode ser nulo.")]
        public string Autor { get; set; }
    }
}
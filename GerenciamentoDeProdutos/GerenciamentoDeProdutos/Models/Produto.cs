using System.ComponentModel.DataAnnotations;

namespace GerenciamentoDeProdutos.Models
{
    public class Produto
    {
        public int Id { get; set; }
        [Required(ErrorMessage ="Informe o nome do produto")]
        public string Nome { get; set; }

        public string Descricao { get; set; }

        [Required(ErrorMessage = "Informe o preço do produto")]
        public double Preco {  get; set; }

        [Required(ErrorMessage = "Informe a quantidade em estoque")]
        public int QuantidadeEstoque { get; set; }

    }
}

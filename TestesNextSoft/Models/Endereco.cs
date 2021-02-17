using System.ComponentModel.DataAnnotations;

namespace TestesNextSoft.Models
{
    public class Endereco
    {

        [Key]
        public int Id{ get; set; }

        public int ClienteId{ get; set; }

        [Required(ErrorMessage = "O Campo TIPO é obrigatório")]
        public string Tipo { get; set; }

        [Required(ErrorMessage = "O Campo LOGADOURO é obrigatório")]
        public string Logadouro { get; set; }

        [Required(ErrorMessage = "O Campo NÚMERO é obrigatório")]
        public int Numero { get; set; }

        [Required(ErrorMessage = "O Campo COMPLEMENTO é obrigatório")]
        public string Complemento { get; set; }

        [Required(ErrorMessage = "O Campo BAIRRO é obrigatório")]
        public string Bairro { get; set; }

        [Required(ErrorMessage = "O Campo CIDADE é obrigatório")]
        public string Cidade { get; set; }

        [Required(ErrorMessage = "O Campo ESTADO é obrigatório")]
        public string Estado { get; set; }


    }
}

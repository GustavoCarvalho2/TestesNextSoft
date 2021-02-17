using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Collections.Generic;

namespace TestesNextSoft.Models
{
    public class Clientes
    {
        [Key]
        public int ClienteId{ get; set; }

        [Required(ErrorMessage = "O Campo CPF é obrigatório")]
        public string Cpf { get; set; }

        [Required(ErrorMessage = "O Campo NOME é obrigatório")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "O Campo E-MAIL é obrigatório")]
        public string Email { get; set; }

        [Required(ErrorMessage = "O Campo TELEFONE é obrigatório")]
        public string Telefone { get; set; }

        [Required(ErrorMessage = "O Campo dados endereco é obrigatório")]
        [ForeignKey("ClienteId")]
        public List<Endereco> Endereco { get; set; }


    }
}

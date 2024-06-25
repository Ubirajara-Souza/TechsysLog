using System.ComponentModel.DataAnnotations;

namespace Bira.App.TechsysLog.Domain.DTOs.Request
{
    public class RequestDto
    {
        [Required(ErrorMessage = "O campo Descrição é obrigatório")]
        public int Number { get; set; }

        [Required(ErrorMessage = "O campo numero do pedido é obrigatório")]
        [StringLength(100, ErrorMessage = "O campo Descrição precisa ter entre {2} e {1} caracteres", MinimumLength = 2)]
        public string? Description { get; set; }

        [Required(ErrorMessage = "O campo Valor é obrigatório")]
        public decimal Value { get; set; }
        public AddressDto Address { get; set; }
    }
}
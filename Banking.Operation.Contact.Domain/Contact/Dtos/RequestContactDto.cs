using System.ComponentModel.DataAnnotations;

namespace Banking.Operation.Contact.Domain.Contact.Dtos
{
    public class RequestContactDto
    {
        [Required(ErrorMessage = "Name is mandatory")]
        [MaxLength(150)]
        public string Name { get; set; }
        [Required(ErrorMessage = "Account is mandatory")]
        public int Account { get; set; }
    }
}

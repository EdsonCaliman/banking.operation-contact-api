using System.ComponentModel.DataAnnotations;

namespace Banking.Operation.Contact.Domain.Contact.Dtos
{
    public class RequestUpdateContactDto
    {
        [Required(ErrorMessage = "Name is mandatory")]
        [MaxLength(150)]
        public string Name { get; set; }
    }
}

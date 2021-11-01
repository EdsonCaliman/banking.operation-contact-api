using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace Banking.Operation.Contact.Domain.Contact.Dtos
{
    [ExcludeFromCodeCoverage]
    public class RequestUpdateContactDto
    {
        [Required(ErrorMessage = "Name is mandatory")]
        [MaxLength(150)]
        public string Name { get; set; }
    }
}

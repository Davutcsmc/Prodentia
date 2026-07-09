using System.ComponentModel.DataAnnotations;

namespace Prodentia.API.DTOs.DentalOffices
{
    public class CreateDentalOfficeDTO
    {
        [Required]
        [StringLength(150)]
        public required string Name { get; set; }
    }
}

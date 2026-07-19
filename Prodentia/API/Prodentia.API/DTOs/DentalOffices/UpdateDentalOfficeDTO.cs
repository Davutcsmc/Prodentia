using System.ComponentModel.DataAnnotations;

namespace Prodentia.API.DTOs.DentalOffices
{
    public class UpdateDentalOfficeDTO
    {
        [Required]
        [StringLength(150)]
        public required string Name { get; set; }
    }
}

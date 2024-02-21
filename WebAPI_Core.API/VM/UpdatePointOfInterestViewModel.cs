using System.ComponentModel.DataAnnotations;

namespace WebAPI_Core.API.VM
{
    public class UpdatePointOfInterestViewModel
    {
        [Required]
        [MaxLength(20)]
        public string Name { get; set; } = string.Empty;

        [MaxLength(50)]
        public string? Description { get; set; }
    }
}

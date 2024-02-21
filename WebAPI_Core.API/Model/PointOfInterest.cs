using System.ComponentModel.DataAnnotations.Schema;

namespace WebAPI_Core.API.Model
{
    public class PointOfInterest
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string? Description { get; set; }

    }
}

namespace WebAPI_Core.API.Model
{
    public class City
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string? Description { get; set; }
        public int NumberOfPointInsterest
        {
            get
            {
                return pointOfInterests.Count;
            }
        }
        public List<PointOfInterest> pointOfInterests { get; set; } = new List<PointOfInterest>();
    }
}

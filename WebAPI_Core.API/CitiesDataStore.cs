using WebAPI_Core.API.Model;

namespace WebAPI_Core.API
{
    public class CitiesDataStore
    {
        public CitiesDataStore()
        {
            Cities = new List<City>(){ 
                new City() {Id = 1, Name ="Tehran",Description="Tehran is Paitakht"
                ,pointOfInterests = new List<PointOfInterest>()
                {
                    new PointOfInterest()
                    {
                        Id = 1,
                        Name = "Jomhoori",
                        Description = "Jomhoori is Best"
                    },
                    new PointOfInterest()
                    {
                        Id = 2,
                        Name = "TehranPars",
                        Description = "TehranPars is Best"
                    },
                    new PointOfInterest()
                    {
                        Id = 3,
                        Name = "Vanak",
                        Description = "Vanak is Best"
                    },
                    new PointOfInterest()
                    {
                        Id = 4,
                        Name = "Sohanak",
                        Description = "Vanak is Best"
                    }

                }
                },
                new City() {Id = 2, Name ="Qom",Description="Qom is Nice"
                ,pointOfInterests = new List<PointOfInterest>()
                {
                    new PointOfInterest()
                    {
                        Id = 5,
                        Name = "Ghale",
                        Description = "Ghale is Best"
                    },
                    new PointOfInterest()
                    {
                        Id = 6,
                        Name = "Danesh",
                        Description = "Danesh is Best"
                    }

                }},
                new City() {Id = 3, Name ="Arak",Description="Arak is Nice"
                ,pointOfInterests = new List<PointOfInterest>()
                {
                    new PointOfInterest()
                    {
                        Id = 7,
                        Name = "EmrahimAbad",
                        Description = "EmrahimAbad is Best"
                    },
                    new PointOfInterest()
                    {
                        Id = 8,
                        Name = "Keshvari",
                        Description = "Keshvari is Best"
                    }

                }},
                new City() {Id = 4, Name ="Shiraz",Description="Shiraz is Nice"
                ,pointOfInterests = new List<PointOfInterest>()
                {
                    new PointOfInterest()
                    {
                        Id = 9,
                        Name = "Hafezieh",
                        Description = "Hafezieh is Best"
                    },
                    new PointOfInterest()
                    {
                        Id = 10,
                        Name = "ArgeBam",
                        Description = "ArgeBam is Best"
                    },
                    new PointOfInterest()
                    {
                        Id = 11,
                        Name = "TakhteJamshid",
                        Description = "TakhteJamshid is Best"
                    },

                }},
                new City() {Id = 5, Name ="Zanjan",Description="Zanjan is Nice"
                ,pointOfInterests = new List<PointOfInterest>()
                {
                    new PointOfInterest()
                    {
                        Id = 12,
                        Name = "Asbi",
                        Description = "Asbi is Best"
                    },
                    new PointOfInterest()
                    {
                        Id = 13,
                        Name = "Gorzabad",
                        Description = "Gorzabad is Best"
                    }
                }},
                new City() {Id = 6, Name ="Tabriz",Description="Tabriz is Nice"
                ,pointOfInterests = new List<PointOfInterest>()
                {
                    new PointOfInterest()
                    {
                        Id = 14,
                        Name = "Ghotab",
                        Description = "Ghotab is Best"
                    }
                }},
            };
        }
        public List<City> Cities { get; set; }
        //public static CitiesDataStore current { get; } = new CitiesDataStore();
    }
}

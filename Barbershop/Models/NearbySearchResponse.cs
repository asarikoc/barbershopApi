using System.Collections.Generic;

namespace barbershopApi.Models
{
    public class NearbySearchResponse
    {
        public IEnumerable<NearbySearchResult> results { get; set; }
    }

    public class NearbySearchResult
    {
        public string name { get; set; }
        public string place_id { get; set; }
        public Geometry geometry { get; set; }
        public List<PhotoReference> photos { get; set; }
    }

    public class Geometry
    {
        public Location location { get; set; }
    }

    public class Location
    {
        public double lat { get; set; }
        public double lng { get; set; }
    }

    public class PhotoReference
    {
        public string photo_reference { get; set; }
    }
}

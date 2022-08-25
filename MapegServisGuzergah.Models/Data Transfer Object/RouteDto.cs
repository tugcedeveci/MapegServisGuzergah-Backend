using NetTopologySuite.Geometries;

namespace MapegServisGuzergah.Models.Data_Transfer_Object
{
    public class RouteDto
    {
        public int RouteId { get; set; }

        public string RouteName { get; set; }

        public Geometry? Geometry { get; set; }
    }
}

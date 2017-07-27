using System.ComponentModel.DataAnnotations;

namespace GoogleMapy {
    //entity class
    public class TravelPoint {
        [Key]
        public int PointId { get; set; }

        public double Latitude { get; set; }
        public double Longitude { get; set; }

        public int TrackId { get; set; }

    }
}

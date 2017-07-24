using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;


namespace GoogleMapy {
    public class FindTrack {
        [Key]
        public int TrackId { get; set; }

        public virtual List<TravelPoint> TravelPoints { get; set; }

        public int UserId { get; set; }
    }
}

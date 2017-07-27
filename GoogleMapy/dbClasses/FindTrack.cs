using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;


namespace GoogleMapy {
    //entity class
    public class FindTrack {
        [Key]
        public int TrackId { get; set; }
        //list of travel steps
        public virtual List<TravelPoint> TravelPoints { get; set; }

        public int UserId { get; set; }
    }
}

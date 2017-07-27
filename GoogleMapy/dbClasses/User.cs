using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace GoogleMapy {
    //entity class
    public class User {
        [Key]
        public int UserId { get; set; }

        public string Login { get; set; }
        public string PasswordHash { get; set; }
        //list of saved tracks
        public virtual List<FindTrack> FindTracks { get; set; }
    }
    
}

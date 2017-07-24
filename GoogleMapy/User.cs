using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace GoogleMapy {
    public class User {
        [Key]
        public int UserId { get; set; }

        public string Login { get; set; }
        public string PasswordHash { get; set; }

        public virtual List<FindTrack> FindTracks { get; set; }
    }
    
}

using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Security.Permissions;
using System.Web.Script.Serialization;

namespace GoogleMapy {
    //connection JS -> c#

    [PermissionSet(SecurityAction.Demand, Name = "FullTrust")]
    [ComVisible(true)]

    public class HTMLConnection {
        //variable to connect with DB
        public ApplicationDbContext db;
        //currently logged user
        public User User { get; set; }
        public HTMLConnection(ApplicationDbContext contex) {
            User = null;
            db = contex;
        }

        //conversion JS array of photosUrl to C# array, display gallery window with photos
        public void ShowGallery(int length, string JStab) {
            string[] URLphotos = JStab.Split(',');
            if (length > 0) {
                GalleryWindow dialog = new GalleryWindow(URLphotos);
                dialog.Show();
            }
        }

        //parse JSON array with lat%lng data to C# array 
        public void WriteTrack(int latlength, dynamic latArray) {
            var serializer = new JavaScriptSerializer();
            CoordData[] data = serializer.Deserialize<CoordData[]>(latArray);
            // save data to db when user is logged
            if (User != null) {
                var track = new FindTrack();
                track.UserId = User.UserId;
                track.TravelPoints = new List<TravelPoint>();

                for (int i = 0; i < data.Length; i++) {
                    var point = new TravelPoint();
                    point.Latitude = data[i].lat;
                    point.Longitude = data[i].lng;
                    point.TrackId = track.TrackId;
                    track.TravelPoints.Add(point);
                }
                if(User.FindTracks == null)
                    User.FindTracks = new List<FindTrack>();
                User.FindTracks.Add(track);
                db.SaveChanges();
            }
        }
        //class for JSON parsing
        private class CoordData {
            public double lng;
            public double lat;
        }
    }
  

}

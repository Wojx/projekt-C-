using System.Runtime.InteropServices;
using System.Security.Permissions;


namespace GoogleMapy {
    //connection JS -> c#

    [PermissionSet(SecurityAction.Demand, Name = "FullTrust")]
    [ComVisible(true)]
    public class HTMLConnection {
        //conversion JS array of photosUrl to C# array
        public void ShowGallery(int length, string JStab) {
            string[] URLphotos = JStab.Split(',');
            if (length > 0) {
                GalleryWindow dialog = new GalleryWindow(URLphotos);
                dialog.Show();
            }
        }
    }
}

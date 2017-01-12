using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace PlanArt.QueryEntities
{
    public class Picture
    {
        public static string ToBase64(string virtualPath, string name)
        {
            //virtualPath1 = "~/Content/profilePictures/"
            //virtualPath2 = "~/Content/postedPictures/"
            byte[] imageByteData;
            if (name == null)
            {
                imageByteData = System.IO.File.ReadAllBytes(HttpContext.Current.Server.MapPath(virtualPath) + "unknown-person.jpg");
            }
            else
            {
                imageByteData = System.IO.File.ReadAllBytes(HttpContext.Current.Server.MapPath(virtualPath) + name);
            }
            string imageBase64Data = Convert.ToBase64String(imageByteData);
            string imageDataURL = string.Format("data:image/jpg;base64,{0}", imageBase64Data);

            return imageDataURL;
        }
    }
}

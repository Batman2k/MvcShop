using System.Drawing;
using System.Drawing.Imaging;
using System.IO;

namespace RapidMountain.Core.Extensions
{
    public static class ImageExtensions
    {
        public static byte[] ToByteArray(this Image image)
        {
            var ms = new MemoryStream();
            image.Save(ms, ImageFormat.Jpeg);
            return ms.ToArray();
        }

        //public Image ByteArrayToImage(byte[] byteArray)
        //{
        //    var ms = new MemoryStream(byteArray);
        //    var returnImage = Image.FromStream(ms);

        //    return returnImage;
        //}
    }

    //public static class ImageExtensions
    //{
    //    public static Image ToImage(this byte[] byteArray)

    //    {
    //        var ms = new MemoryStream(byteArray);
    //        var returnImage = Image.FromStream(ms);

    //        return returnImage;
    //    }
    //}
}
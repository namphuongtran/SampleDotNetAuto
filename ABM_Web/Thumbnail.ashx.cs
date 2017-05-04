using System;
using System.Configuration;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.IO;
using System.Web;
using ABM.Common;

namespace ABM_Web
{
    /// <summary>
    /// Summary description for Thumbnail
    /// </summary>
    public class Thumbnail : IHttpHandler
    {
        private int _thumbnailSize = 140;

        public void ProcessRequest(HttpContext context)
        {
            context.Response.Cache.SetCacheability(HttpCacheability.Public);
            context.Response.Cache.SetExpires(DateTime.Now.AddDays(7));

            var imagePath = string.Empty;
            
            var url  = context.Request.QueryString["Url"];
            _thumbnailSize = Convert.ToInt32(context.Request.QueryString["Size"]);

            imagePath = !string.IsNullOrEmpty(url)
                            ? context.Server.MapPath(url)
                            : context.Server.MapPath("Data/no-image.jpg");

            Bitmap photo;
            try
            {
                photo = new Bitmap(imagePath);
            }
            catch (ArgumentException)
            {
                throw new HttpException(404, "Photo not found.");
            }

            int width, height;
            if (photo.Width > photo.Height)
            {
                width = _thumbnailSize;
                height = photo.Height * _thumbnailSize / photo.Width;
            }
            else
            {
                width = photo.Width * _thumbnailSize / photo.Height;
                height = _thumbnailSize;
            }

            context.Response.Clear();
            var fileName = string.Format("inline; filename={0}", url);
            context.Response.AddHeader("Content-disposition", fileName);
            context.Response.ContentType = "image/jpeg";

            var target = new Bitmap(width, height);

            using (var graphics = Graphics.FromImage(target))
            {
                graphics.InterpolationMode = InterpolationMode.HighQualityBicubic;
                graphics.SmoothingMode = SmoothingMode.HighQuality;
                graphics.PixelOffsetMode = PixelOffsetMode.HighQuality;
                graphics.CompositingQuality = CompositingQuality.HighQuality;

                graphics.DrawImage(photo, 0, 0, width, height);

                using (var memoryStream = new MemoryStream())
                {
                    var Info = ImageCodecInfo.GetImageEncoders();
                    var Params = new EncoderParameters(1);
                    Params.Param[0] = new EncoderParameter(Encoder.Quality, 100L);
                    context.Response.ContentType = Info[1].MimeType;

                    target.Save(context.Response.OutputStream, Info[1], Params);
                }
            }
        }

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}
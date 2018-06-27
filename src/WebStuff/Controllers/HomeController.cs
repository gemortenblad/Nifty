using System;
using System.Web.Mvc;

namespace WebStuff.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        
        
        public ActionResult GetVideo() 
        { 
            var file = System.IO.File.OpenRead(@"C:\code\mycode\git\Nifty\src\WebStuff\Data\plastpasar.mp4");

            string contentType = "mp4"; 
            Byte[] video = ReadToEnd(file); 
            string mimeType; 
            switch (contentType.ToUpper()) 
            { 
                case "MOV": 
                    mimeType = "video/quicktime"; 
                    break; 
                case "MP4": 
                    mimeType = "video/mp4"; 
                    break; 
                case "FLV": 
                    mimeType = "video/x-flv"; 
                    break; 
                case "AVI": 
                    mimeType = "video/x-msvideo"; 
                    break; 
                case "WMV": 
                    mimeType = "video/x-ms-wmv"; 
                    break; 
                case "MJPG": 
                    mimeType = "video/x-motion-jpeg"; 
                    break; 
                case "TS": 
                    mimeType = "video/MP2T"; 
                    break; 
                default: 
                    mimeType = "video/mp4";    
                    break; 
            } 
            return File(video, mimeType);  
        }

        private static byte[] ReadToEnd(System.IO.Stream stream)
        {
            long originalPosition = 0;

            if(stream.CanSeek)
            {
                originalPosition = stream.Position;
                stream.Position = 0;
            }

            try
            {
                byte[] readBuffer = new byte[4096];

                int totalBytesRead = 0;
                int bytesRead;

                while ((bytesRead = stream.Read(readBuffer, totalBytesRead, readBuffer.Length - totalBytesRead)) > 0)
                {
                    totalBytesRead += bytesRead;

                    if (totalBytesRead == readBuffer.Length)
                    {
                        int nextByte = stream.ReadByte();
                        if (nextByte != -1)
                        {
                            byte[] temp = new byte[readBuffer.Length * 2];
                            Buffer.BlockCopy(readBuffer, 0, temp, 0, readBuffer.Length);
                            Buffer.SetByte(temp, totalBytesRead, (byte)nextByte);
                            readBuffer = temp;
                            totalBytesRead++;
                        }
                    }
                }

                byte[] buffer = readBuffer;
                if (readBuffer.Length != totalBytesRead)
                {
                    buffer = new byte[totalBytesRead];
                    Buffer.BlockCopy(readBuffer, 0, buffer, 0, totalBytesRead);
                }
                return buffer;
            }
            finally
            {
                if(stream.CanSeek)
                {
                    stream.Position = originalPosition; 
                }
            }
        }
        
    }
}
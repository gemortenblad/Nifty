using System;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web.Http;
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

            Byte[] video = AppCode.ReadToEnd(file); 
            string mimeType = "video/mp4";

            return File(video, mimeType);  
        }

        
        
    }
}
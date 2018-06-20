using System;
using System.Diagnostics;
using System.IO;
using System.Threading;

namespace CMDStuff
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            
            var uts = new UseTheStopwatch();
            Console.WriteLine("Running stopwatch");
            var timespan = uts.RunStopwatch();
            
            var fw = new FileWriter();
            fw.WriteToFile("c:\\temp\\myfile.txt", timespan.ToString());
            

        }
    }

    internal class UseTheStopwatch
    {
        public TimeSpan RunStopwatch()
        {
            var stopwatch = new Stopwatch();
            stopwatch.Start();
            
            Console.WriteLine("Sleep for 0.3 seconds");
            Thread.Sleep(300);
            Console.WriteLine("Done sleeping");
            stopwatch.Stop();

            return stopwatch.Elapsed;
        }
    }

    internal class FileWriter
    {
        public void WriteToFile(string filenameandpath, string textToWrite)
        {
            Console.WriteLine("Write " + textToWrite + " to file: "+ filenameandpath);
            File.WriteAllText(filenameandpath, textToWrite);
            Console.WriteLine("Done writing!");
        }
    }
}
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

//            // This does not work - netcore vs netframework??
//            var logger = new Logger.Logger(true);
//            logger.Log("This is logged!");
            
            var uts = new UseTheStopwatch();
            Console.WriteLine("Running stopwatch");
            var timespan = uts.RunStopwatch();
            
            var fw = new FileWriter();
            fw.WriteToFile("c:\\temp\\myfile.txt", timespan.ToString());
            
            
//#if DEBUG
//
//            var stopwatch = new Stopwatch();
//            stopwatch.Start();
//#endif  
//            
//            //DOWORK();
//            
//#if DEBUG
//
//            stopwatch.Stop();
//            WriteResultToFile(stopwatch.Elapsed);
//            
//#endif
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
        
        private void WriteResultToFile(TimeSpan stopwatchElapsed)
        {
            string path = @"c:\temp\getvideostats.txt";


            // This text is added only once to the file.
            if (!File.Exists(path)) 
            {
                // Create a file to write to.
                using (StreamWriter sw = File.CreateText(path)) 
                {
                    sw.WriteLine("Milliseconds to load video stream");
                }	
            }

            // This text is always added, making the file longer over time
            // if it is not deleted.
            using (StreamWriter sw = File.AppendText(path)) 
            {
                sw.WriteLine(stopwatchElapsed.TotalMilliseconds.ToString());
            }	

        }
        
    }
}
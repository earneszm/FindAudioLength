using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FindAudioLength
{
    class Program
    {

        /// <summary>
        /// Prints the total mp3 duration of all mp3 contained within a directory, traversing recursively.
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {

            var helper = new DirectoryHelper();

            helper.DirSearch(@"E:\Recording");

            double totalDuration = 0;

            foreach (var item in helper.lstFilesFound)
            {
                TagLib.File f = TagLib.File.Create(item, TagLib.ReadStyle.Average);
                totalDuration += (int)f.Properties.Duration.TotalSeconds;
            }

            Console.WriteLine(string.Format("Total duration in seconds: {0}", totalDuration));
            Console.WriteLine(string.Format("Total duration in minutes: {0}", totalDuration / 60));
            Console.WriteLine(string.Format("Total duration in hours: {0}", totalDuration / 60 / 60));

            Console.ReadKey();


        }        
    }
}

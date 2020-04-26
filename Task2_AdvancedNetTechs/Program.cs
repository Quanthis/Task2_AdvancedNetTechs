using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;
using System.IO;

namespace Task2_AdvancedNetTechs
{
    class Program
    {
        static async Task Main(string[] args)
        {
            WriteLine("Enter path for file: ");
            //string path = ReadLine();
            string path = @"C:\tmp\Sample.txt";

            WriteLine("Enter path where to save: ");
            //string savePath = ReadLine();
            string savePath = @"C:\tmp\Sample8.txt";

            var fs = new FileStream(path, FileMode.Open);
            var read = new ReadInputFile(fs);

            var modify = new ConvertSCahrs(read);
            
            var save = new CreateHTML(modify, new FileStream(savePath, FileMode.Create));
            save.SaveFile();





            WriteLine("Press any key to exit...");
            ReadKey();
        }
    }
}

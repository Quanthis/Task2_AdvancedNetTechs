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
            WriteLine("Enter full path for input file: ");
            string path = ReadLine();

            WriteLine("Enter path where to save: (without file extension)");
            string savePath = ReadLine();
            savePath = savePath + ".html";

            try
            {
                if(savePath.Contains(".txt"))
                {
                    throw new InvalidOperationException();
                }

                var fs = new FileStream(path, FileMode.Open);
                var read = new ReadInputFile(fs);

                var modify = new ConvertSCahrs(read);

                try
                {
                    var save = new CreateHTML(modify, new FileStream(savePath, FileMode.Create));
                    await save.SaveFile();

                    System.Diagnostics.Process.Start(savePath);
                }
                catch
                {
                    WriteLine("Error! You do not have permission to write in this location.");
                }
            }
            catch(FileNotFoundException)
            {
                WriteLine("Error! File was not found.");
            }
            catch(InvalidOperationException)
            {
                WriteLine("Incorrect file name. Please try without giving extension.");
            }
                                 

            WriteLine("Press any key to exit...");
            ReadKey();
        }
    }
}

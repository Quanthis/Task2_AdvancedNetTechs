using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Task2_AdvancedNetTechs
{
    public class ReadInputFile
    {
        private FileStream readFile;
        private StreamReader reader;
        private StringBuilder readText = new StringBuilder("");

        public ReadInputFile(FileStream fileToReadFrom)
        {
            if (fileToReadFrom.CanRead)
            {
                readFile = fileToReadFrom;
                reader = new StreamReader(readFile, Encoding.UTF8);
            }
            else
            {
                Console.WriteLine("Error: file mode does not support reading.");
            }
        }


        public async Task<StringBuilder> ReadText()
        {
            return await Task.Run(() =>
            {
                return readText.Append(reader.ReadToEnd());
            });
        }
    }
}

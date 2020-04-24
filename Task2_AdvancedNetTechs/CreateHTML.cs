using System;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task2_AdvancedNetTechs
{
    public class CreateHTML
    {
        private StringBuilder wroteText = new StringBuilder("");
        private FileStream whereToSave;
        private StreamWriter writer;

        public CreateHTML(FileStream fileToSave)
        {
            if(fileToSave.CanWrite)
            {
                whereToSave = fileToSave;
                writer = new StreamWriter(whereToSave, Encoding.UTF8);
            }
        }
    }
}

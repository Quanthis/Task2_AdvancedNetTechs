using System;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task2_AdvancedNetTechs
{
    public class CreateHTML
    {
        private StringBuilder wroteText;
        private ConvertSCahrs newFile;
        private StreamWriter writer;
        private FileStream savedFileLoc;

        public CreateHTML(ConvertSCahrs modifiedFile, FileStream whereToSave)
        {
            newFile = modifiedFile;
            savedFileLoc = whereToSave;
            writer = new StreamWriter(savedFileLoc, Encoding.UTF8);
        }

        public async Task SaveFile()
        {
            await Task.Run(() =>
            {
                wroteText = newFile.ModifyText().Result;

                lock(savedFileLoc)
                {
                    lock (writer)
                    {
                        writer.AutoFlush = true;
                        writer.WriteLine(wroteText);
                    }
                }
            });
        }
    }
}

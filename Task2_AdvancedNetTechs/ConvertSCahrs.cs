using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task2_AdvancedNetTechs
{
    public class ConvertSCahrs
    {
        private StringBuilder textToModify;
        private StringBuilder modifiedText = new StringBuilder("");
        private ReadInputFile file;

        public ConvertSCahrs(ReadInputFile inputFile)
        {
            file = inputFile;
        }

        private async Task<StringBuilder> AssignText()
        {
            return await Task.Run(() =>
            {
                lock (file)
                {
                    textToModify = file.ReadText().Result;
                    return textToModify;

                    Console.WriteLine(textToModify);
                }
            });
        }

        public async Task<StringBuilder> ModifyText()
        {
            return await Task.Run(() =>
            {
                modifiedText = AssignText().Result;

                modifiedText.Append("\nNew text is here!");

                //Console.WriteLine(modifiedText);

                return modifiedText;
            });
        }
    }
}

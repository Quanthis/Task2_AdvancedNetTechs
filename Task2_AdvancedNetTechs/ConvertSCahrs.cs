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

        private async void AssignText()
        {
            textToModify = await file.ReadText();
        }
    }
}

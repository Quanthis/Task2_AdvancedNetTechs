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
                }
            });
        }

        public async Task<StringBuilder> ModifyText()
        {
            return await Task.Run(() =>
            {
                modifiedText = AssignText().Result;
                modifiedText = HelperMethods.Adres_Replace(modifiedText).Result;
                modifiedText = HelperMethods.QReplace(modifiedText).Result;
                modifiedText = HelperMethods.StrongReplace(modifiedText).Result;
                modifiedText = HelperMethods.EMReplace(modifiedText).Result;
                modifiedText = HelperMethods.Replace_(modifiedText).Result;
                modifiedText = HelperMethods._Replace(modifiedText).Result;

                //modifiedText = HelperMethods.Replace3(modifiedText).Result;

                return modifiedText;
            });
        }
    }
}

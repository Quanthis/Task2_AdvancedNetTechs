using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task2_AdvancedNetTechs
{
    public class ConvertSCahrs
    {
        private StringBuilder textToModify = new StringBuilder("");
        private StringBuilder modifiedText = new StringBuilder("");
        private ReadInputFile file;

        public ConvertSCahrs(ReadInputFile inputFile)
        {
            file = inputFile;
        }

        public ConvertSCahrs(StringBuilder textToModify)
        {
            this.textToModify = textToModify;
            textToModify.Append(" ");
        }

        public ConvertSCahrs(string textToModify)
        {
            this.textToModify = new StringBuilder(textToModify);
            this.textToModify.Append(" ");
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

                if(modifiedText.Length == 0)
                {
                    Console.WriteLine("File was empty!");
                    return new StringBuilder("Error! File was empty.");
                }

                modifiedText = HelperMethods.ParagraphReplace(modifiedText).Result;
                modifiedText = HelperMethods.Adres_Replace(modifiedText).Result;
                modifiedText = HelperMethods.QReplace(modifiedText).Result;
                modifiedText = HelperMethods.StrongReplace(modifiedText).Result;
                modifiedText = HelperMethods.EMReplace(modifiedText).Result;
                modifiedText = HelperMethods.Replace_(modifiedText).Result;
                modifiedText = HelperMethods._Replace(modifiedText).Result;
                modifiedText = HelperMethods.Replace3(modifiedText).Result;
                modifiedText = HelperMethods.LineReplace(modifiedText).Result;
                modifiedText = AddHTMLElemets().Result;


                return modifiedText;
            });
        }

        public async Task<string> ModifyText(bool withHTMLBase, bool AsString)
        {
            return await Task.Run(() =>
            {
                modifiedText = textToModify;

                if(modifiedText.Length == 0)
                {
                    return "Error";
                }

                modifiedText = HelperMethods.ParagraphReplace(modifiedText).Result;
                modifiedText = HelperMethods.Adres_Replace(modifiedText).Result;
                modifiedText = HelperMethods.QReplace(modifiedText).Result;
                modifiedText = HelperMethods.StrongReplace(modifiedText).Result;
                modifiedText = HelperMethods.EMReplace(modifiedText).Result;
                modifiedText = HelperMethods.Replace_(modifiedText).Result;
                modifiedText = HelperMethods._Replace(modifiedText).Result;
                modifiedText = HelperMethods.Replace3(modifiedText).Result;
                modifiedText = HelperMethods.LineReplace(modifiedText).Result;

                return modifiedText.ToString();
            });
        }

        private async Task<StringBuilder> AddHTMLElemets()
        {
            return await Task.Run(() =>
            {
                string toInsert = "<!DOCTYPE html>" + "\n<html>\n<head>\n<meta charset=utf-8/>" + "<title>Converted HTML document</title>" +
                    "\n</head>\n<body>\n";
                modifiedText.Insert(0, toInsert);

                string toInsertAtEnd = "\n</body>\n</html>";
                modifiedText.Insert(modifiedText.Length, toInsertAtEnd);

                return modifiedText;
            });
        }
    }
}

using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task2_AdvancedNetTechs
{
    public class ForASPOnly
    {
        private StringBuilder textToModify;
        private StringBuilder modifiedText = new StringBuilder("");


        public ForASPOnly(StringBuilder textToModify)
        {
            this.textToModify = textToModify;
            textToModify.Append(" ");
        }

        public ForASPOnly(string textToModify)
        {
            this.textToModify = new StringBuilder(textToModify);
            this.textToModify.Append(" ");
        }

        public async Task<string> ModifyText()
        {
            return await Task.Run(() =>
            {
                modifiedText = textToModify;
                modifiedText.Append(" ");

                System.Diagnostics.Debug.WriteLine("modified text: " + modifiedText + "type" + modifiedText.GetType());

                if (modifiedText.Length == 0)
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
    }
}

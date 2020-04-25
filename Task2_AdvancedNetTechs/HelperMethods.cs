using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace Task2_AdvancedNetTechs
{
    public static class HelperMethods
    {
        public async static Task<StringBuilder> QReplace(StringBuilder textToModify)
        {
            return await Task.Run(() =>
            {
                string q1 = ">>";
                string q12 = "<<";
                string qReplace1 = "<q>";
                string qReplace2 = "</q>";

                string toCheck = textToModify.ToString();

                if(toCheck.Contains(q1) && toCheck.Contains(q12))
                {
                    textToModify.Replace(q1, qReplace1);
                    textToModify.Replace(q12, qReplace2);
                }
                else if(toCheck.Contains(q1) || toCheck.Contains(q12))
                {
                    Console.WriteLine("There was an error during converting '>>' or '<<'.  " +
                        "Please correct misstypes first.\nApplication shutdown in 10 seconds...");
                    Thread.Sleep(10000);
                    Environment.Exit(0);
                }


                return textToModify;
            });
        }

        public async static Task<StringBuilder> EMReplace(StringBuilder textToModify)
        {
            return await Task.Run(() =>
            {
                ushort flag = 0;
                string q1 = "*";
                string q12 = "*";
                string qReplace1 = "<em>";
                string qReplace2 = "</em>";

                string toCheck = textToModify.ToString();

                if (toCheck.Contains(q1))
                {
                    int indexOfFirstOccurency = toCheck.IndexOf(q1 + 1);
                    string restToCheck = toCheck.Substring(indexOfFirstOccurency);
                    Console.WriteLine(restToCheck);
                }
                else if (toCheck.Contains(q1) || toCheck.Contains(q12))
                {
                    Console.WriteLine("There was an error during converting '*'.  " +
                        "Please correct misstypes first.\nApplication shutdown in 10 seconds...");
                    Thread.Sleep(10000);
                    Environment.Exit(0);
                }


                return textToModify;
            });
        }
    }
}

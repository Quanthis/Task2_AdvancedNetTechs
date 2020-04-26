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
        
        public static async Task<StringBuilder> QReplace(StringBuilder textToModify)
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

        private static StringBuilder EMReplaceResult;
        public static async Task<StringBuilder> EMReplace(StringBuilder textToModify)
        {
            return await Task.Run(() =>
            {
                string toModify = textToModify.ToString();

                for (int i = 0; i < toModify.Length; ++i)
                {
                    if (toModify[i] == '*' && toModify[i + 1] != '*') 
                    {
                        for(int j = i + 2; j < toModify.Length; ++j)
                        {
                            if(toModify[j] == '*')
                            {
                                string toReplace = toModify.Substring(i, (j - i) + 2);
                                StringBuilder subString = new StringBuilder(toModify.Substring(i, (j - i) + 1));
                                subString.Remove(0, 1);
                                subString.Insert(0, "<em>");

                                subString.Remove(subString.Length - 1, 1);
                                subString.Insert(subString.Length, "</em>");
                                string replacing = subString.ToString();

                                EMReplaceResult = textToModify.Replace(toReplace, replacing);
                                break;
                            }
                        }
                    }
                }

                return EMReplaceResult;
            });
        }

        public static async Task<StringBuilder> Replace_(StringBuilder textToModify)
        {
            return await Task.Run(() =>
            {
                string q1 = "_!";
                string q12 = "!_";
                string qReplace1 = "<ins>";
                string qReplace2 = "</ins>";

                string toCheck = textToModify.ToString();

                if (toCheck.Contains(q1) && toCheck.Contains(q12))
                {
                    textToModify.Replace(q1, qReplace1);
                    textToModify.Replace(q12, qReplace2);
                }
                else if (toCheck.Contains(q1) || toCheck.Contains(q12))
                {
                    Console.WriteLine("There was an error during converting '_!' or '!_'.  " +
                        "Please correct misstypes first.\nApplication shutdown in 10 seconds...");
                    Thread.Sleep(10000);
                    Environment.Exit(0);
                }


                return textToModify;
            });
        }

        public static async Task<StringBuilder> _Replace(StringBuilder textToModify)
        {
            return await Task.Run(() =>
            {
                string q1 = "-!";
                string q2 = "!-";
                string qReplace1 = "<del>";
                string qReplace2 = "</del>";

                string toCheck = textToModify.ToString();

                if (toCheck.Contains(q1) && toCheck.Contains(q2))
                {
                    textToModify.Replace(q1, qReplace1);
                    textToModify.Replace(q2, qReplace2);
                }
                else if (toCheck.Contains(q1) || toCheck.Contains(q2))
                {
                    Console.WriteLine("There was an error during converting '_!' or '!_'.  " +
                        "Please correct misstypes first.\nApplication shutdown in 10 seconds...");
                    Thread.Sleep(10000);
                    Environment.Exit(0);
                }


                return textToModify;
            });
        }

        public static async Task<StringBuilder> Adres_Replace(StringBuilder textToModify)
        {
            return await Task.Run(() =>
            {
                string q1 = "[";
                string q2 = "]";
                string q3 = "|";

                string toCheck = textToModify.ToString();

                int startIndex = toCheck.IndexOf(q1);
                int endIndex = toCheck.IndexOf(q3);
                int textEndIndex = toCheck.IndexOf(q2);

                string adres = toCheck.Substring(startIndex + 1, (endIndex - startIndex) - 1);
                string text = toCheck.Substring(endIndex + 1, ((textEndIndex - 1) - endIndex));

                string qReplace1 = "<a href =\""+ adres + "\">\n";
                string qReplace2 = text + "</a>";

                if (toCheck.Contains(q1) && toCheck.Contains(q2))
                {
                    textToModify.Replace(q1, qReplace1);
                    textToModify.Replace(q2, qReplace2);
                }
                else if (toCheck.Contains(q1) || toCheck.Contains(q2))
                {
                    Console.WriteLine("There was an error during converting 'adres' or 'text'.  " +
                        "Please correct misstypes first.\nApplication shutdown in 10 seconds...");
                    Thread.Sleep(10000);
                    Environment.Exit(0);
                }


                return textToModify;
            });
        }

        private static StringBuilder result;
        public static async Task<StringBuilder> Replace3(StringBuilder textToModify)
        {
            return await Task.Run(() =>
            {                
                string toCheck = textToModify.ToString();
                string subString;

                int outerIndex = 1;

                bool isOK = true;

                for(int i = 0; i < toCheck.Length; ++i)
                {
                    if (toCheck[i] == '#')
                    {
                        int index = i;
                        for(int j = index; j < toCheck.Length; ++j)
                        {
                            if (toCheck[j] == '\n')
                            {                                
                                int innerIndex = j;
                                subString = toCheck.Substring(index, (innerIndex - index) + 1);
                                string stringToReplace = subString;
                                
                                string partResult1 = subString.Replace("#", "\n<h1 id=\"" + outerIndex + ">");
                                string partResult2 = partResult1.Replace("\n", "</h1>");
                                
                                textToModify.Replace(stringToReplace, partResult2);

                                result = textToModify;

                                ++outerIndex;                               

                                isOK = true;

                                break;
                                
                            }
                            else
                            {
                                isOK = false;
                            }                            
                        }
                        if (!isOK)
                        {
                            Console.WriteLine("There was an error during converting '#' or 'text'.  " +
                                    "Please correct misstypes first.\nApplication shutdown in 10 seconds...");
                            Thread.Sleep(10000);
                            Environment.Exit(0);
                        }

                    }
                }
                return result;
            });
        }
    }
}

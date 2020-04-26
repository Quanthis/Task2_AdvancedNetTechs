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
        #region CheckStars
        private static bool AreStarsOK(string toCheck)
        {
            int count = toCheck.Count(f => f == '*');
            if(count % 2 == 0)
            {
                return true;
            }
            else
            {
                Console.WriteLine("There was an error during converting '*' or '**'. " +
                                "Please correct misstypes first.\nApplication shutdown in 10 seconds...");
                Thread.Sleep(10000);
                Environment.Exit(0);
                return false;
            }
        }

        private static bool AreStarsOK(StringBuilder toCheck)
        {
            int count = toCheck.ToString().Count(f => f == '*');
            if (count % 2 == 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        #endregion

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
                        for (int j = i + 2; j < toModify.Length; ++j)
                        {
                            if (toModify[j] == '*')
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
                        AreStarsOK(toModify);
                    }
                }
                return EMReplaceResult;
            });                                             
        }

        private static StringBuilder StrongResult;
        public static async Task<StringBuilder> StrongReplace(StringBuilder textToModify)
        {
            return await Task.Run(() =>
            {
                string toModify = textToModify.ToString();

                for (int i = 0; i < toModify.Length; ++i)
                {
                    if (toModify[i] == '*' && toModify[i + 1] == '*')
                    {
                        for (int j = i + 2; j < toModify.Length; ++j)
                        {
                            if (toModify[j] == '*' && toModify[j+1] == '*')
                            {
                                string toReplace = toModify.Substring(i, (j - i) + 2);
                                StringBuilder subString = new StringBuilder(toModify.Substring(i, (j - i) + 2));
                                subString.Remove(0, 2);
                                subString.Insert(0, "<strong>");

                                subString.Remove(subString.Length - 2, 2);
                                subString.Insert(subString.Length, "</strong>");
                                string replacing = subString.ToString();

                                StrongResult = textToModify.Replace(toReplace, replacing);

                                break;
                            }
                        }
                        AreStarsOK(toModify);
                    }
                }
                return StrongResult;
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

        private static StringBuilder Adres_ReplaceResult = new StringBuilder("");
        public static async Task<StringBuilder> Adres_Replace(StringBuilder textToModify)
        {
            return await Task.Run(() =>
            {
                string toModify = textToModify.ToString();

                Adres_ReplaceResult = textToModify;

                for(int i = 0; i < textToModify.Length; ++i)
                {
                    if(textToModify[i] == '[')
                    {
                        for (int j = i + 1; j < textToModify.Length; ++j)
                        {
                            if(textToModify[j] == '|')
                            {
                                for(int k = j + 1; k < textToModify.Length; ++k)
                                {
                                    if(textToModify[k] == ']')
                                    {
                                        StringBuilder replacer1 = new StringBuilder(toModify.Substring(i, j - i));
                                        string toReplacev1 = replacer1.ToString();
                                        StringBuilder replacer1_helper = new StringBuilder(replacer1.ToString().Substring(1, j - (i + 1)));
                                        StringBuilder replacer2 = new StringBuilder(toModify.Substring(j, (k - j) + 1));
                                        Console.WriteLine("i: " + i + " j: " + j + " k: " + k + " length: " + (k - (j + 1)));
                                        string toReplacev2 = replacer2.ToString();

                                        Console.WriteLine("Replacer1: " + replacer1);
                                        Console.WriteLine("Replacer2 : " + replacer2);
                                        Console.WriteLine("Replacer1 helper: " + replacer1_helper);

                                        replacer1.Replace("[", "<a href=\"" + replacer1_helper + "\">");
                                        int index = replacer1.ToString().IndexOf('>');
                                        replacer1.Remove(index + 1, replacer1.Length - (index + 1));                                        
                                        Console.WriteLine(replacer1);

                                        index = replacer2.ToString().IndexOf("|");
                                        if(index == -1)
                                        {
                                            Console.WriteLine("During conversion of '[adres|tekst]' form, '|' was not found. " +
                                                "Application shutdown in 10 seconds.");
                                            Thread.Sleep(10000);
                                            Environment.Exit(0);
                                        }

                                        replacer2.Remove(index, 1);
                                        replacer2.Replace("]", "</a>");
                                        Console.WriteLine(replacer2);

                                        Adres_ReplaceResult.Replace(toReplacev1, replacer1.ToString());
                                        Adres_ReplaceResult.Replace(toReplacev2, replacer2.ToString());
                                    }
                                }
                            }
                        }
                    }
                }

                return Adres_ReplaceResult;
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

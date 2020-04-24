using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.IO;
using System.Text;

namespace Tests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void CompareLength()
        {
            int result;
            string s;

            using (FileStream fs = new FileStream(@"C:\tmp\Sample.txt", FileMode.Open))
            {
                using (StreamReader sr = new StreamReader(fs, Encoding.UTF8))
                {
                    s = sr.ReadToEnd();
                    result = s.Length;
                }
            }

            Assert.AreEqual(result, NewFileLength());
        }

        private int NewFileLength()
        {
            int result;
            string s;

            using (FileStream fs = new FileStream(@"C:\tmp\Sample2.txt", FileMode.Open))
            {
                using (StreamReader sr = new StreamReader(fs, Encoding.UTF8))
                {
                    s = sr.ReadToEnd();
                    result = s.Length;
                }
            }

            return result;
        }
    }
}

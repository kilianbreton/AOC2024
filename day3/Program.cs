using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Diagnostics;

namespace day3
{
    internal class Program
    {

        static bool mulEnabled = true;
        /// <summary>
        /// Retourne le contenu entre les séparateurs sep1 et sep2 de la chaine text
        /// </summary>
        /// <param name="text"></param>
        /// <param name="sep1"></param>
        /// <param name="sep2"></param>
        /// <returns></returns>
        public static String subsep(String text, String sep1, String sep2)
        {
            int startCut = text.IndexOf(sep1) + sep1.Length;
            int lengthCut = text.IndexOf(sep2) - startCut;
            return text.Substring(startCut, lengthCut);
        }


        static string foundMul(string input, out int result, bool part2)
        {
            result = -1;
            int indexStart = input.IndexOf("mul(");
            int doIndex = input.IndexOf("do()");
            int dontIndex = input.IndexOf("don't()");

            string tmp = "";
            if (indexStart == -1)
            {
                return null;    //fin 
            }

            if (doIndex != -1 && doIndex < indexStart)
            {
                mulEnabled = true;

                if (dontIndex != -1 && dontIndex < doIndex)
                    mulEnabled = false;
            }
            else if (dontIndex != -1 && dontIndex < indexStart)
            {
                mulEnabled = false;
            }

            input = input.Substring(indexStart);
       
          

            tmp = subsep(input, "mul(", ")");
            if(tmp.Length > 7 || tmp.IndexOf(",") == -1)
                return input.Substring(3);
            

            string[] parts = tmp.Split(',');
            if(parts.Length != 2)
                return input.Substring(3);
            

            if (!(int.TryParse(parts[0], out int n1)))
                return input.Substring(3);
            
            if (!(int.TryParse(parts[1], out int n2)))
                return input.Substring(3);
            

            if(mulEnabled)
                result = n1 * n2;


            return input.Substring(3 + tmp.Length + 1);
        }



        static void Main(string[] args)
        {
            Stopwatch sw = new Stopwatch();
            sw.Start();
            string stext = File.ReadAllText(@"C:\test\AOC2024\AOC3.txt");
            string text = stext;
            int val = 0;
            int result = 0;
            
            while (text != null)
            {
                text = foundMul(text, out val, false);
                if(val != -1)
                    result += val;
            }
            
            Console.WriteLine($"Result 1 : {result}");
            text = stext;
            while (text != null)
            {
                text = foundMul(text, out val, true);
                if(val != -1)
                    result += val;
            }

            Console.WriteLine($"Result 2 : {result}");
            sw.Stop();
            Console.WriteLine($"Time     : {sw.Elapsed:g}");
            Console.ReadLine();


        }
    }
}

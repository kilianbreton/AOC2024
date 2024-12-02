using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace day2_cs
{
    internal class Program
    {
    
        static bool isValid(int[] nums)
        {
            bool res = false;
            List<int> tnums = new List<int>(nums);
            bool asc = false;
            int removeIndex = 0;

            while(!(res))
            {
                res = true;
                for(int i = 1; i < tnums.Count; ++i)
                {
                    int tmp = Math.Abs(tnums[i] - tnums[i - 1]);
                    if(tmp == 0 || tmp > 3)
                    {
                        res = false;
                    }
                    if(i == 1)
                    {
                        if (tnums[i] - tnums[i-1] > 0)
                            asc = true;
                        else
                            asc = false;
                    }
                    else
                    {
                        if (tnums[i] - tnums[i - 1] > 0 && asc == false)
                            res = false;

                        if (tnums[i] - tnums[i - 1] < 0 && asc == true)
                            res = false;
                    }

                }
                if(!(res))
                {
                    tnums = new List<int>(nums);
                    if(removeIndex < nums.Length)
                        tnums.RemoveAt(removeIndex);

                    if (removeIndex++ == nums.Length + 1)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        return false;
                    }
                }
            }

            return true;
        }



        static void Main(string[] args)
        {
            string[] lines = File.ReadAllLines(@"C:\test\AOC2024\AOC2.txt");
            int nb = 0;
          


      
            foreach (string line in lines)
            {
                string[] snum = line.Split(' ');
                int[] num = Array.ConvertAll(snum, s => int.Parse(s));
                if (isValid(num))
                    ++nb;
                
            }


            Console.WriteLine(nb);
            Console.ReadLine();


        }
    }
}

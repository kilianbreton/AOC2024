﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Diagnostics;

namespace day2_cs
{
    internal class Program
    {
    
        static bool isValid(int[] nums, out bool nb)
        {
            bool res = false;
            List<int> tnums = new List<int>(nums);
            bool asc = false;
            int removeIndex = -1;
            nb = false;
            bool firstTime = true;

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
                    firstTime = false;
                    tnums = new List<int>(nums);
                    ++removeIndex;
                    if (removeIndex < nums.Length)
                        tnums.RemoveAt(removeIndex);
                    else
                        return false;
                }
            }
            if (firstTime)
                nb = true;

            return true;
        }



        static void Main(string[] args)
        {
            string[] lines = File.ReadAllLines(@"C:\test\AOC2024\AOC2.txt");
            int nb2 = 0;
            int nb1 = 0;
            bool isNb1 = false;
          

            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
      
            foreach (string line in lines)
            {
                string[] snum = line.Split(' ');
                int[] num = Array.ConvertAll(snum, s => int.Parse(s));
                if (isValid(num, out isNb1))
                {
                    ++nb2;
                    if (isNb1)
                    {
                        ++nb1;
                    }
                }
                
            }
            stopwatch.Stop();

            Console.WriteLine("Result 1 : " + nb1);
            Console.WriteLine("Result 2 : " + nb2);
            Console.WriteLine($"Time     : {stopwatch.Elapsed:g}");
            Console.ReadLine();


        }
    }
}

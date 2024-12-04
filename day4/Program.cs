using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Diagnostics;

namespace day4
{
    internal class Program
    {
        static int[] directionX = { 0, 0, 1, -1, 1, -1, 1, -1 };
        static int[] directionY = { 1, -1, 0, 0, 1, 1, -1, -1 };

        static bool searchWord(char[,] chars, string word, int startX, int startY, int dirX, int dirY)
        {
            int rows = chars.GetLength(0);
            int cols = chars.GetLength(1);

            for (int i = 0; i < word.Length; i++)
            {
                int x = startX + i * dirX;
                int y = startY + i * dirY;

                if (x < 0 || x >= rows || y < 0 || y >= cols || chars[x, y] != word[i])
                    return false;
                
            }

            return true;
        }

        static int findWord(char[,] chars, string word)
        {
            int rows = chars.GetLength(0);
            int cols = chars.GetLength(1);
            int dirs = directionX.Length;
            int cpt = 0;
          
            for (int x = 0; x < rows; x++)
                for (int y = 0; y < cols; y++)
                    for (int dir = 0; dir < dirs; dir++)
                        if (searchWord(chars, word, x, y, directionX[dir], directionY[dir]))
                            cpt += 1;
                       
           
            return cpt;
        }

   
        static int findXmas(char[,] chars)
        {
            int rows = chars.GetLength(0);
            int cols = chars.GetLength(1);
            int res = 0;

            for (int x = 1; x < rows; x++)
            {
                for (int y = 1; y < cols; y++)
                {
                    if(chars[x, y] == 'A')
                    {
                        int nbM = 0;
                        int nbS = 0;
                        bool diag1M = false;
                        bool diag2M = false;

                        if (chars[x - 1,y - 1] == 'M')
                        {
                            diag1M = true;
                            ++nbM;
                        }
                        if (chars[x - 1,y - 1] == 'S')
                            ++nbS;

                        if (y < cols - 1 && x < rows - 1 && chars[x + 1, y + 1] == 'S' && diag1M)
                            ++nbS;

                        if (y < cols - 1 && x < rows - 1 && chars[x + 1, y + 1] == 'M' && !diag1M)
                            ++nbM;

                        if (x < rows-1 && chars[x + 1, y - 1] == 'M')
                        {
                            diag2M = true;
                            ++nbM;
                        }
                        if (x < rows-1 && chars[x + 1, y - 1] == 'S')
                            ++nbS;

                        if (y < cols-1 && chars[x - 1, y + 1] == 'S' && diag2M)
                            ++nbS;
                        if (y < cols-1 && chars[x - 1, y + 1] == 'M' && !diag2M)
                            ++nbM;



                        if (nbM > 0 && nbS > 0 && nbM + nbS == 4)
                            ++res;
                        

                    }
                }
            }


            return res;
        }



        static void Main(string[] args)
        {
            Console.ReadLine();
            
            char[,] chars = new char[140, 140];

            string[] lines = File.ReadAllLines(@"C:\test\AOC2024\AOC4.txt");
            for (int i = 0; i < lines.Length; i++)
            {
                for(int j = 0; j < lines[i].Length; j++)
                {
                    chars[i,j] = lines[i][j];
                }
            }

            Stopwatch sw = new Stopwatch();
            sw.Start();

            int r = findWord(chars, "XMAS");
            Console.WriteLine($"Result 1 : {r}");
            r = findXmas(chars);
            Console.WriteLine($"Result 2 : {r}");
            sw.Stop();
            Console.WriteLine($"Time : {sw.Elapsed:g}");
            Console.ReadLine();


        }
    }
}

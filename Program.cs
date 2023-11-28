using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO; // File.*
using System.Threading;
using System.Web;

namespace TextBasedRPG
{
    internal class Program
    {

        static char avatar = '@';
        static bool gameOver = false;
        static int x = 30;
        static int y = 10;
        static char[,] map;
        
        static void Main(string[] args)
        {
            Console.CursorVisible = false;
            Console.WriteLine("Text Based RPG");
            Console.WriteLine();
            LoadMap();

            //if (map[newX,newY] == '#')
            
            while (gameOver != true)
            {
                CharacterController();
            }
            

            Console.WriteLine();
            Console.WriteLine("Press any key to exit...");
            Console.ReadKey();
        }

        static void CharacterController()
        {        
               ConsoleKeyInfo input;
               input = Console.ReadKey(true);
                    if (input.Key == ConsoleKey.W)
                    {
                        if (map[x, y] != '#')
                        {
                            LoadMap();
                            y = y - 1;
                            if (y <= 2) y = 3;
                        }
                        else
                        {
                            y = y + 1;
                        }
                    }
                    if (input.Key == ConsoleKey.S)
                    {
                        LoadMap();
                        y = y + 1;
                        if (y > 19) y = 19;
                    }
                    if (input.Key == ConsoleKey.D)
                    {
                        LoadMap();
                        x = x + 1;
                        if (x > 60) x = 60;
                    }
                    if (input.Key == ConsoleKey.A)
                    {
                        LoadMap();
                        x = x - 1;
                        if (x < 1) x = 1;
                    }
              Console.SetCursorPosition(x, y);
              Console.WriteLine(avatar);
        }
        static void LoadMap()
        {
            Console.SetCursorPosition(0, 2);
            string path = @"map.txt";
            string[] MapRows;
            MapRows = File.ReadAllLines(path);
            int width = MapRows[0].Length;
            int height = MapRows.Length;
            map = new char[width, height];
            for (int y = 0; y < height; y++)
            {
                for (int x = 0; x < width; x++)
                {
                    Console.Write("");
                    map[x,y] = MapRows[y][x];
                    Console.Write(map[x,y]); // debug (display the info)
                }
                Console.WriteLine();
            }
        }
    }
}

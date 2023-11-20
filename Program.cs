using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace TextBasedRPG
{
    internal class Program
    {
            static char wall = '#';
            static char avatar = '@';
            static bool gameOver = false;
            static int x = 30; 
            static int y = 10;

            static string path = @"map.txt";
            static string[] MapRows;
        static void Main(string[] args)
        {
            MapRows = File.ReadAllLines(path);
            Console.WriteLine("Text Based RPG");
            Console.WriteLine();

            while (gameOver != true)
            {
                ConsoleKeyInfo input;
                input = Console.ReadKey(true);
                if (input.Key == ConsoleKey.W)
                {
                    PrintMap();
                    if (y == 8) y = 8;
                    else y = y - 1;                   
                    if (y < 2) y = 2;
                }
                if (input.Key == ConsoleKey.S)
                {
                    PrintMap();
                    if (y == 11) y = 11;
                    else y = y + 1;
                    if (y > 20) y = 20;
                }
                if (input.Key == ConsoleKey.D)
                {
                    PrintMap();
                    if (x == 36) x = 36;
                    else x = x + 1;
                    if (x > 60) x = 60;
                }
                if (input.Key == ConsoleKey.A)
                {
                    PrintMap();
                    if (x == 22) x = 22;
                    else x = x - 1;
                    if (x < 0) x = 0;
                }
                Console.SetCursorPosition(x, y);
                Console.WriteLine(avatar);
            }

            Console.WriteLine();
            Console.WriteLine("Press any key to exit...");
            Console.ReadKey(true);
        }

        static void PrintMap()
        {
            Console.SetCursorPosition(0, 2);
            string path = @"map.txt";
            string[] MapRows;
            MapRows = File.ReadAllLines(path);
            for (int i = 0; i < MapRows.Length; i++)
            {
                string MapRow = MapRows[i];
                for (int j = 0; j < MapRow.Length; j++)
                {
                    Console.Write("");
                    char tile = MapRow[j];
                    Console.Write(tile);
                }
                Console.WriteLine();
            }
        }
    }
}

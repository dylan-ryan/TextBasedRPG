using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Threading;
using System.Web;

namespace TextBasedRPG
{
    internal class Program
    {

        static char avatar = '@';
        static bool gameOver = false;

        static string path = @"map.txt";
        static void Main(string[] args)
        {
            int x = 30;
            int y = 10;
            Console.CursorVisible = false;
            Console.WriteLine("Text Based RPG");
            Console.WriteLine();
            LoadMap();
            Console.ReadKey();
            while (gameOver != true)
            {
                ConsoleKeyInfo input;
                input = Console.ReadKey(true);
                if (input.Key == ConsoleKey.W)
                {

                    LoadMap();
                    if ()

                    y = y - 1;
                    if (y <= 2) y = 3;
                }
                if (input.Key == ConsoleKey.S)
                {
                    LoadMap();
                    y = y + 1;
                    if (y > 21) y = 21;
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
                    if (x < 0) x = 0;
                }
                Console.SetCursorPosition(x, y);
                Console.WriteLine(avatar);
            }

            Console.WriteLine();
            Console.WriteLine("Press any key to exit...");
            Console.ReadKey();
        }

        static void LoadMap()
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

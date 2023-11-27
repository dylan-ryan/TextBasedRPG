using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Threading;

namespace TextBasedRPG
{
    internal class Program
    {
        static string store;
        static int countx = 0;
        static int county = 0;
        static char wall = '#';
        static char avatar = '@';
        static bool gameOver = false;
        static char[,] map;

        static string path = @"map.txt";
        static void Main(string[] args)
        {
            //int countx = 0;
            //int county = 0;
            //string saveData = File.ReadAllText(path);
            int x = 30;
            int y = 10;
            Console.CursorVisible = false;
            Console.WriteLine("Text Based RPG");
            Console.WriteLine();
            LoadMap();
            Console.ReadKey();
            //foreach (string rows in saveData.Split('\n'))
            //{
            //    Console.Write("\n");
            //    county = county + 1;
            //    foreach(string col in rows.Split('.'))
            //    {
            //        countx = countx + 1;
            //        Console.Write(col);
            //    }
            //}
            //Console.WriteLine("x" + (countx/county));
            //Console.WriteLine("y" + county);
            //Console.ReadKey();
            while (gameOver != true)
            {
                ConsoleKeyInfo input;
                input = Console.ReadKey(true);
                if (input.Key == ConsoleKey.W)
                {

                    PrintMap();
                    //if (MapRows[x+1,y] == "#")
                    //{

                    //}
                    //else
                    //{
                    y = y - 1;
                    //}
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

        }
        
        static void MapRef(string value)
        {
            char tempvalue = '?';
            for (int y = 0; y < county; y++)
            {
                for (int x = 0; x < (countx/county); x++)
                {
                    map[x, y] = tempvalue;
                }
            }
            if (store.Length == countx)
            {

            }
            store = store + value;
            
        }

        static void LoadMap()
        {
            Console.SetCursorPosition(0, 2);
            string saveData = File.ReadAllText(path);
            countx = 1;
            county = 1;
            foreach (string rows in saveData.Split('\n'))
            {
                Console.Write("\n");
                county = county + 1;
                foreach (string col in rows.Split('.'))
                {
                    
                    countx = countx + 1;
                    Console.Write(col);
                    store = store + "!" + col;
                }

            }
            int lineLength = countx / county;
            //countx = 1;
            //county = 1;
            //foreach (string rows in saveData.Split('\n'))
            //{
            //    foreach (string col in rows.Split('.'))
            //    {

            //        MapRef(col, (countx/ county), (county - 1));
            //        countx = countx + 1;

            //    }
            //    county = county + 1;
            //}
            //Console.WriteLine("x" + (countx / county));
            //Console.WriteLine("y" + county);
            //Console.ReadKey();
            //string path = @"map.txt";
            //string[] MapRows;
            //MapRows = File.ReadAllLines(path);
            //for (int i = 0; i < MapRows.Length; i++)
            //{
            //    string MapRow = MapRows[i];
            //    for (int j = 0; j < MapRow.Length; j++)
            //    {
            //        Console.Write("");
            //        char tile = MapRow[j];
            //        Console.Write(tile);
            //    }
            //    Console.WriteLine();
            //}
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO; // File.*
using System.Threading;
using System.Web;
using System.Xml;

namespace TextBasedRPG
{
    internal class Program
    {
        static int enHealth = 2;
        static int health = 3;
        static char avatar = '@';
        static bool gameOver = false;
        static int x = 28;
        static int y = 8;

        static char enemy = '&';
        static int enX = 10;
        static int enY = 4;
        
        static Random r = new Random();

        static char[,] map;
        static void Main(string[] args)
        {

            Console.CursorVisible = false;
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
            Console.SetCursorPosition(x, y);
            Console.WriteLine(avatar);
            Console.SetCursorPosition(enX, enY);
            Console.WriteLine(enemy);
            input = Console.ReadKey(true);
            if (input.Key == ConsoleKey.W)
            {
                y = y - 1;
                if (map[x, y] == ' ')
                {
                    LoadMap();
                    Console.SetCursorPosition(x, y);
                    Console.WriteLine(avatar);
                }
                else if (map[x, y] == '#')
                {
                    LoadMap();
                    y = y + 1;
                    Console.SetCursorPosition(x, y);
                    Console.WriteLine(avatar);
                }

                //enmy
                enY = enY + 1;
                if (map[enX, enY] == ' ')
                {
                    Console.SetCursorPosition(enX, enY);
                    Console.WriteLine(enemy);
                }
                else if (map[enX, enY] == '#')
                {
                    enY = enY - 1;
                    Console.SetCursorPosition(enX, enY);
                    Console.WriteLine(enemy);
                }
            }
            if (input.Key == ConsoleKey.S)
            {
                y = y + 1;
                if (map[x, y] == ' ')
                {
                     LoadMap();
                     Console.SetCursorPosition(x, y);
                     Console.WriteLine(avatar);
                }
                else if (map[x, y] == '#')
                {
                    LoadMap();
                    y = y - 1;
                }
                //enmy
                enY = enY - 1;
                if (map[enX, enY] == ' ')
                {
                    Console.SetCursorPosition(enX, enY);
                    Console.WriteLine(enemy);
                }
                else if (map[enX, enY] == '#')
                {
                    enY = enY + 1;
                }
            }
            if (input.Key == ConsoleKey.D)
            {
                x = x + 1;
                if (map[x, y] == ' ')
                {
                      LoadMap();
                      Console.SetCursorPosition(x, y);
                      Console.WriteLine(avatar);

                }
                else if (map[x, y] == '#')
                {
                    LoadMap();
                    x = x - 1;
                }
                //enmy
                enX = enX - 1;
                if (map[enX, enY] == ' ')
                {
                    Console.SetCursorPosition(enX, enY);
                    Console.WriteLine(enemy);

                }
                else if (map[enX, enY] == '#')
                {
                    enX = enX + 1;
                }
            }
            if (input.Key == ConsoleKey.A)
            {
                x = x - 1;
                if (map[x, y] == ' ')
                {
                     LoadMap();
                     Console.SetCursorPosition(x, y);
                     Console.WriteLine(avatar);
                }
                else if (map[x, y] == '#')
                {
                    LoadMap();
                    x = x + 1;
                }
                //enmy
                enX = enX + 1;
                if (map[enX, enY] == ' ')
                {
                    Console.SetCursorPosition(enX, enY);
                    Console.WriteLine(enemy);
                }
                else if (map[enX, enY] == '#')
                {
                    enX = enX - 1;
                }
                 TakeDamage();
            }
            Console.SetCursorPosition(0, 20);
            Console.WriteLine("Your Health: " + health + "|" + "EnemyHealth: " + enHealth);

            //Console.SetCursorPosition(x, y);
            //Console.WriteLine(avatar);

           /* Console.SetCursorPosition(enX, enY);
            Console.WriteLine(enemy);
            if (input.Key == ConsoleKey.W)
            {
                enY = enY - 1;
                if (map[enX, enY] == ' ')
                {
                    Console.SetCursorPosition(enX, enY);
                    Console.WriteLine(enemy);
                }
                else if (map[enX, enY] == '#')
                {
                    enY = enY + 1;
                    Console.SetCursorPosition(enX, enY);
                    Console.WriteLine(enemy);
                }
            }
            if (input.Key == ConsoleKey.S)
            {
                enY = enY + 1;
                if (map[enX, enY] == ' ')
                {
                    Console.SetCursorPosition(enX, enY);
                    Console.WriteLine(enemy);
                }
                else if (map[enX, enY] == '#')
                {
                    enY = enY - 1;
                }
            }
            if (input.Key == ConsoleKey.D)
            {
                enX = enX + 1;
                if (map[enX, enY] == ' ')
                {
                    Console.SetCursorPosition(enX, enY);
                    Console.WriteLine(enemy);

                }
                else if (map[enX, enY] == '#')
                {
                    enX = enX - 1;
                }
            }
            if (input.Key == ConsoleKey.A)
            {
                enX = enX - 1;
                if (map[enX, enY] == ' ')
                {
                    Console.SetCursorPosition(enX, enY);
                    Console.WriteLine(enemy);
                }
                else if (map[enX, enY] == '#')
                {
                    enX = enX + 1;
                }
            }*/
        }
        static void TakeDamage()
        {
            if (map[enX, enY] == map[x, y])
            {
                health = health - 1;
                enHealth = enHealth - 1;
            }
            else
            {
             
            }
        }
        static void LoadMap()
        {
            Console.SetCursorPosition (0, 0);
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

      /* static void EnemyController()
        {
            ConsoleKeyInfo input;
            Console.SetCursorPosition(enX, enY);
            Console.WriteLine(enemy);
            input = Console.ReadKey(true);
            if (input.Key == ConsoleKey.W)
            {
                enY = enY - 1;
                if (map[enX, enY] == ' ')
                {
                    LoadMap();
                    Console.SetCursorPosition(enX, enY);
                    Console.WriteLine(enemy);
                }
                else if (map[enX, enY] == '#')
                {
                    enY = enY + 1;
                    Console.SetCursorPosition(enX, enY);
                    Console.WriteLine(enemy);
                }
            }
            if (input.Key == ConsoleKey.S)
            {
                enY = enY + 1;
                if (map[enX, enY] == ' ')
                {
                    LoadMap();
                    Console.SetCursorPosition(enX, enY);
                    Console.WriteLine(enemy);
                }
                else if (map[enX, enY] == '#')
                {
                    enY = enY - 1;
                }
            }
            if (input.Key == ConsoleKey.D)
            {
                enX = enX + 1;
                if (map[enX, enY] == ' ')
                {
                    LoadMap();
                    Console.SetCursorPosition(enX, enY);
                    Console.WriteLine(enemy);

                }
                else if (map[enX, enY] == '#')
                {
                    enX = enX - 1;
                }
            }
            if (input.Key == ConsoleKey.A)
            {
                enX = enX - 1;
                if (map[enX, enY] == ' ')
                {
                    LoadMap();
                    Console.SetCursorPosition(enX, enY);
                    Console.WriteLine(enemy);
                }
                else if (map[enX, enY] == '#')
                {
                    enX = enX + 1;
                }
            }
            //Console.SetCursorPosition(x, y);
            //Console.WriteLine(avatar);


        }*/
    }
}

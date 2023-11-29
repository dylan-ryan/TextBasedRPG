﻿using System;
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
        static bool enemyDeath = false;
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

            while (gameOver == true)
            {
                Console.Clear();
                Console.WriteLine("Game Over");
                Console.ReadKey(true);
                break;
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
            if (input.Key == ConsoleKey.W || input.Key == ConsoleKey.UpArrow)
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
                Lava();
                //enmy
                if (enHealth > 0)
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
                        Console.SetCursorPosition(enX, enY);
                        Console.WriteLine(enemy);
                    }
                    if (enX == x && enY == y)
                    {
                        TakeDamage();
                        LoadMap();
                        y = y + 1;
                        enY = enY - 1;
                    }
                }
            }
            if (input.Key == ConsoleKey.S || input.Key == ConsoleKey.DownArrow)
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
                Lava();
                //enmy
                if (enHealth > 0)
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
                    }
                    if (enX == x && enY == y)
                    {
                        TakeDamage();
                        LoadMap();
                        y = y - 1;
                        enY = enY + 1;
                    }
                }
                TakeDamage();
            }
            if (input.Key == ConsoleKey.D || input.Key == ConsoleKey.RightArrow)
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
                Lava();
                //enmy
                if (enHealth > 0)
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
                    if (enX == x && enY == y)
                    {
                        TakeDamage();
                        LoadMap();
                        x = x - 1;
                        enX = enX + 1;
                    }
                }
                TakeDamage();
            }
            if (input.Key == ConsoleKey.A || input.Key == ConsoleKey.LeftArrow)
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
                Lava();
                //enmy
                if (enHealth > 0)
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
                    if (enX == x && enY == y)
                    {
                        TakeDamage();
                        LoadMap();
                        x = x + 1;
                        enX = enX - 1;
                    }
                }
                TakeDamage();
            }
            Console.SetCursorPosition(0, 19);
            Console.WriteLine("Your Health: " + health + "|" + "EnemyHealth: " + enHealth);
        }
 

        static void Lava()
        {
            if (map[x, y] == 'L' || map[x, y] == 'A' || map[x, y] == 'V')
            {
                LoadMap();
                health = health - 1;
            }
            if(map[enX, enY] == 'L' || map[enX, enY] == 'A' || map[enX, enY] == 'V')
            {
                if(enHealth > 0)
                {
                LoadMap();
                enHealth = enHealth - 1;

                }
            }
        }
        static void TakeDamage()
        {
                if (enX == x && enY == y)
                {
                    if(enHealth > 0)
                    {
                     health = health - 1;
                     enHealth = enHealth - 1;
                    }
                }
                if (health <= 0)
                {
                gameOver = true;
                }
                if(enHealth <= 0)
                {
                    enHealth = 0;
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


    }
}

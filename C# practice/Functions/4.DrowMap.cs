using System;
using System.Collections.Generic;

namespace iJunior
{
    class MainClass
    {
        /*Сделать игровую карту с помощью двумерного массива. 
         * Сделать функцию рисования карты. 
         * Помимо этого, дать пользователю возможность перемещаться по карте 
         * и взаимодействовать с элементами (например пользователь не может пройти сквозь стену)
         * Все элементы являются обычными символами
         */
        static void Main(string[] args)
        {
            int playerCoordinateX;
            int playerCoordinateY;
            int movementDirectionX = 0;
            int movementDirectionY = 0;
            bool isPlaying = true;
            string[,] map =
            {
              {"#","#","#","#","#","#","#","#","#","#","#","#","#","#","#","#","#","#","#","#"},
              {"#","@","#"," "," "," "," "," "," "," "," "," ","#"," "," "," "," "," "," ","#"},
              {"#"," ","#"," "," "," "," "," "," "," "," "," ","#"," "," "," "," "," "," ","#"},
              {"#"," ","#"," ","#","#"," "," "," "," "," "," ","#"," "," "," "," "," "," ","#"},
              {"#"," ","#"," ","#","#"," "," "," "," "," "," ","#"," "," "," "," "," "," ","#"},
              {"#"," ","#","#","#","#"," "," "," "," "," "," ","#"," "," "," "," "," "," ","#"},
              {"#"," ","#"," "," "," "," "," "," "," "," "," ","#"," "," "," "," "," "," ","#"},
              {"#"," ","#"," "," "," "," "," "," "," "," "," ","#"," "," "," "," "," "," ","#"},
              {"#"," ","#","#","#","#"," ","#","#","#","#"," ","#"," "," "," "," "," "," ","#"},
              {"#"," ","#"," "," "," "," ","#"," "," "," "," ","#"," "," "," "," "," "," ","#"},
              {"#"," ","#"," "," "," "," ","#"," "," "," "," ","#"," "," "," "," "," "," ","#"},
              {"#"," "," "," "," "," "," ","#"," "," "," "," ","#"," "," "," "," "," "," ","#"},
              {"#"," "," "," "," "," "," ","#"," "," "," "," ","#"," "," "," "," "," "," ","#"},
              {"#"," "," ","#","#","#","#","#"," "," "," "," ","#"," ","#","#","#","#","#","#"},
              {"#"," "," ","#"," "," "," "," "," "," "," "," ","#"," "," "," "," "," "," ","#"},
              {"#"," "," ","#"," "," "," "," "," "," "," "," ","#","#","#","#","#","#"," ","#"},
              {"#"," "," ","#"," "," "," "," "," "," "," "," "," "," "," "," "," "," "," ","#"},
              {"#"," "," ","#"," "," "," "," "," "," "," "," "," "," "," "," "," "," "," ","#"},
              {"#"," "," ","#"," "," "," "," "," "," "," "," "," "," "," "," "," "," "," ","#"},
              {"#","#","#","#","#","#","#","#","#","#","#","#","#","#","#","#","#","#","#","#"}
            };

            DrowMap(map);

            FindPlayer(map, out playerCoordinateY, out playerCoordinateX);

            while (isPlaying)
            {
                if (Console.KeyAvailable)
                {
                    Console.CursorVisible = false;

                    TakeDirectionPlayerMove(ref movementDirectionX, ref movementDirectionY);

                    MovePlayer(map, ref playerCoordinateX, ref playerCoordinateY, ref movementDirectionX, ref movementDirectionY);
                }
            }

            static void DrowMap(string[,] arrayMap)
            {
                for (int i = 0; i < arrayMap.GetLength(0); i++)
                {
                    for (int j = 0; j < arrayMap.GetLength(1); j++)
                    {
                        Console.Write(arrayMap[i, j]);
                    }

                    Console.WriteLine();
                }
            }
        }
        static void FindPlayer(string[,] arrayMap, out int coordinateX, out int coordinateY)
        {
            coordinateX = 0;
            coordinateY = 0;
            for (int i = 0; i < arrayMap.GetLength(0); i++)
            {
                for (int j = 0; j < arrayMap.GetLength(1); j++)
                {
                    if (arrayMap[i, j] == "@")
                    {
                        coordinateX = j;
                        coordinateY = i;
                    }
                }
            }

            Console.SetCursorPosition(coordinateX, coordinateY);
        }

        static void TakeDirectionPlayerMove(ref int coordinateDirectionX, ref int coordinateDirectionY)
        {
            coordinateDirectionX = 0;
            coordinateDirectionY = 0;

            ConsoleKeyInfo key = Console.ReadKey(true);

            switch (key.Key)
            {
                case ConsoleKey.UpArrow:
                    coordinateDirectionX = -1;
                    break;
                case ConsoleKey.DownArrow:
                    coordinateDirectionX = 1;
                    break;
                case ConsoleKey.LeftArrow:
                    coordinateDirectionY = -1;
                    break;
                case ConsoleKey.RightArrow:
                    coordinateDirectionY = 1;
                    break;
            }
        }

        static void MovePlayer(string[,] map, ref int coordinateY, ref int coordinateX, ref int coordinateDirectionX, ref int coordinateDirectionY)
        {
            if (map[coordinateX + coordinateDirectionX, coordinateY + coordinateDirectionY] != "#")
            {
                Console.SetCursorPosition(coordinateY, coordinateX);
                Console.Write(" ");
                coordinateX += coordinateDirectionX;
                coordinateY += coordinateDirectionY;
                Console.SetCursorPosition(coordinateY, coordinateX);
                Console.Write("@");
            }
        }
    }
}
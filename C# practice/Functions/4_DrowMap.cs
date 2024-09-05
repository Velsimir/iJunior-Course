using System;

namespace iJunior
{
    class MainClass
    {
        static void Main(string[] args)
        {
                        int pacmanPositionX;
            int pacmanPositionY;
            char player = '@';
            bool isPlaying = true;
            ConsoleKeyInfo pressedKey = new ConsoleKeyInfo('w', ConsoleKey.W, false, false, false);
            
            char[,] map =
            {
                {'#','#','#','#','#','#','#','#','#','#','#','#','#','#','#','#','#','#','#','#'},
                {'#','@','#',' ',' ',' ',' ',' ',' ',' ',' ',' ','#',' ',' ',' ',' ',' ',' ','#'},
                {'#',' ','#',' ',' ',' ',' ',' ',' ',' ',' ',' ','#',' ',' ',' ',' ',' ',' ','#'},
                {'#',' ','#',' ','#','#',' ',' ',' ',' ',' ',' ','#',' ',' ',' ',' ',' ',' ','#'},
                {'#',' ','#',' ','#','#',' ',' ',' ',' ',' ',' ','#',' ',' ',' ',' ',' ',' ','#'},
                {'#',' ','#','#','#','#',' ',' ',' ',' ',' ',' ','#',' ',' ',' ',' ',' ',' ','#'},
                {'#',' ','#',' ',' ',' ',' ',' ',' ',' ',' ',' ','#',' ',' ',' ',' ',' ',' ','#'},
                {'#',' ','#',' ',' ',' ',' ',' ',' ',' ',' ',' ','#',' ',' ',' ',' ',' ',' ','#'},
                {'#',' ','#','#','#','#',' ','#','#','#','#',' ','#',' ',' ',' ',' ',' ',' ','#'},
                {'#',' ','#',' ',' ',' ',' ','#',' ',' ',' ',' ','#',' ',' ',' ',' ',' ',' ','#'},
                {'#',' ','#',' ',' ',' ',' ','#',' ',' ',' ',' ','#',' ',' ',' ',' ',' ',' ','#'},
                {'#',' ',' ',' ',' ',' ',' ','#',' ',' ',' ',' ','#',' ',' ',' ',' ',' ',' ','#'},
                {'#',' ',' ',' ',' ',' ',' ','#',' ',' ',' ',' ','#',' ',' ',' ',' ',' ',' ','#'},
                {'#',' ',' ','#','#','#','#','#',' ',' ',' ',' ','#',' ','#','#','#','#','#','#'},
                {'#',' ',' ','#',' ',' ',' ',' ',' ',' ',' ',' ','#',' ',' ',' ',' ',' ',' ','#'},
                {'#',' ',' ','#',' ',' ',' ',' ',' ',' ',' ',' ','#','#','#','#','#','#',' ','#'},
                {'#',' ',' ','#',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ','#'},
                {'#',' ',' ','#',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ','#'},
                {'#',' ',' ','#',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ','#'},
                {'#','#','#','#','#','#','#','#','#','#','#','#','#','#','#','#','#','#','#','#'}
            };

            DrowMap(map);

            FindPlayer(map, out pacmanPositionX, out pacmanPositionY);
            
            while (isPlaying)
            {
                if (Console.KeyAvailable)
                {
                    DrowMap(map);
                    
                    Console.CursorVisible = false;

                    pressedKey = Console.ReadKey();
                    
                    HandleInput(map, pressedKey, ref pacmanPositionX, ref pacmanPositionY);

                    MovePlayer(pacmanPositionX, pacmanPositionY, player);
                }
            }
        }
        
        static void DrowMap(char[,] map)
        {
            for (int i = 0; i < map.GetLength(0); i++)
            {
                for (int j = 0; j < map.GetLength(1); j++)
                {
                    Console.Write(map[i, j]);
                }

                Console.WriteLine();
            }
        }

        static void HandleInput(char[,] map, ConsoleKeyInfo pressedKey, ref int pacManCoodinationX, ref int pacManCoodinationY)
        {
            int[] direction = GetDirection(pressedKey);
            int nextPacManPositionX = pacManCoodinationX + direction[0];
            int nextPacManPositionY = pacManCoodinationY + direction[1];
            
            if (map[nextPacManPositionX, nextPacManPositionY] == ' ')
            {
                pacManCoodinationX = nextPacManPositionX;
                pacManCoodinationY = nextPacManPositionY;
            }
        }

        static int[] GetDirection(ConsoleKeyInfo pressedKey)
        {
            int[] direction = {0, 0};
            
            switch (pressedKey.Key)
            {
                case ConsoleKey.UpArrow:
                    direction[0] = -1;
                    break;
                case ConsoleKey.DownArrow:
                    direction[0] = 1;
                    break;
                case ConsoleKey.LeftArrow:
                    direction[1] = -1;
                    break;
                case ConsoleKey.RightArrow:
                    direction[1] = 1;
                    break;
            }

            return direction;
        }
        
        static void MovePlayer(int pacManCoodinationX, int pacManCoodinationY, char player)
        {
            Console.SetCursorPosition(pacManCoodinationY, pacManCoodinationX);
            Console.Write(player);
        }
        
        static void FindPlayer(char[,] map, out int pacmanPositionX, out int pacmanPositionY)
        {
            pacmanPositionX = 0;
            pacmanPositionY = 0;
            
            for (int i = 0; i < map.GetLength(0); i++)
            {
                for (int j = 0; j < map.GetLength(1); j++)
                {
                    if (map[i, j] == '@')
                    {
                        pacmanPositionX = j;
                        pacmanPositionY = i;
                    }
                }
            }
            
            Console.SetCursorPosition(pacmanPositionX, pacmanPositionY);
        }
    }
}

using System;

namespace iJunior
{
    class MainClass
    {
        static void Main(string[] args)
        {
            int pacmanPositionX = 1;
            int pacmanPositionY = 1;
            int coins = 0;
            char player = '@';
            char coin = '.';
            bool isPlaying = true;
            ConsoleKeyInfo pressedKey = new ConsoleKeyInfo('w', ConsoleKey.W, false, false, false);
            Console.CursorVisible = false;
            
            char[,] map =
            {
                {'#','#','#','#','#','#','#','#','#','#','#','#','#','#','#','#','#','#','#','#'},
                {'#',' ','#',' ',' ',' ',' ',' ',' ',' ',' ',' ','#','.','.','.','.','.','.','#'},
                {'#',' ','#',' ',' ',' ',' ',' ',' ',' ',' ',' ','#','.','.','.','.','.','.','#'},
                {'#','.','#',' ','#','#',' ',' ',' ',' ',' ',' ','#','.','.','.','.','.','.','#'},
                {'#','.','#',' ','#','#',' ',' ',' ',' ',' ',' ','#','.','.','.','.','.','.','#'},
                {'#','.','#','#','#','#',' ',' ',' ',' ',' ',' ','#','.','.','.','.','.','.','#'},
                {'#','.','#',' ',' ',' ',' ',' ',' ',' ',' ',' ','#','.','.','.','.','.','.','#'},
                {'#','.','#',' ',' ',' ',' ',' ',' ',' ',' ',' ','#','.','.','.','.','.','.','#'},
                {'#','.','#','#','#','#',' ','#','#','#','#',' ','#','.','.','.','.','.','.','#'},
                {'#','.','#',' ',' ',' ',' ','#','.',' ',' ',' ','#','.','.','.','.','.','.','#'},
                {'#','.','#',' ',' ',' ',' ','#','.',' ',' ',' ','#','.','.','.','.','.','.','#'},
                {'#',' ',' ',' ',' ',' ',' ','#','.',' ',' ',' ','#','.','.','.','.','.','.','#'},
                {'#',' ',' ',' ',' ',' ',' ','#','.',' ',' ',' ','#','.','.','.','.','.','.','#'},
                {'#',' ',' ','#','#','#','#','#','.',' ',' ',' ','#',' ','#','#','#','#','#','#'},
                {'#',' ',' ','#','.','.','.','.','.',' ',' ',' ','#',' ',' ',' ',' ',' ',' ','#'},
                {'#',' ',' ','#','.','.','.','.','.',' ',' ',' ','#','#','#','#','#','#',' ','#'},
                {'#',' ',' ','#','.','.','.','.','.',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ','#'},
                {'#',' ',' ','#',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ','#'},
                {'#',' ',' ','#',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ','#'},
                {'#','#','#','#','#','#','#','#','#','#','#','#','#','#','#','#','#','#','#','#'}
            };
            
            while (isPlaying)
            {
                Console.Clear();
                    
                DrowMap(map);

                ShowCoins(coins);
                
                ShowPlayer(pacmanPositionX, pacmanPositionY, player);
                
                pressedKey = Console.ReadKey();
                    
                HandleInput(map, pressedKey, coin, ref pacmanPositionX, ref pacmanPositionY);
                
                coins += CollectCoin(map, coin, ref pacmanPositionX, ref pacmanPositionY);
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

        static void HandleInput(char[,] map, ConsoleKeyInfo pressedKey, char coin, ref int pacManCoodinationX, ref int pacManCoodinationY)
        {
            int[] direction = GetDirection(pressedKey);
            int nextPacManPositionX = pacManCoodinationX + direction[0];
            int nextPacManPositionY = pacManCoodinationY + direction[1];
            
            if (map[nextPacManPositionX, nextPacManPositionY] == ' ' || map[nextPacManPositionX, nextPacManPositionY] == coin)
            {
                pacManCoodinationX = nextPacManPositionX;
                pacManCoodinationY = nextPacManPositionY;
            }
        }

        static int CollectCoin(char[,] map, char coin, ref int pacManCoodinationX, ref int pacManCoodinationY)
        {
            int count = 0;
            
            if (map[pacManCoodinationX, pacManCoodinationY] == coin)
            {
                map[pacManCoodinationX, pacManCoodinationY] = ' ';
                count++;
            }

            return count;
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
        
        static void ShowPlayer(int pacManCoordinationX, int pacManCoordinationY, char player)
        {
            Console.SetCursorPosition(pacManCoordinationY, pacManCoordinationX);
            Console.Write(player);

            Console.SetCursorPosition(0,0);
        }

        static void ShowCoins(int coins)
        {
            Console.SetCursorPosition(22, 0);
            Console.Write($"Монеток собрано - {coins}");
            
            Console.SetCursorPosition(0,0);
        }
    }
}

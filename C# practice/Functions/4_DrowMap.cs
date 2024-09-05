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
                
                MovePlayer(pacmanPositionX, pacmanPositionY, player);
                
                pressedKey = Console.ReadKey();
                    
                HandleInput(map, pressedKey, ref pacmanPositionX, ref pacmanPositionY);
                
                coins += CollectCoin(map, pressedKey, ref pacmanPositionX, ref pacmanPositionY);
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
            
            if (map[nextPacManPositionX, nextPacManPositionY] == ' ' || map[nextPacManPositionX, nextPacManPositionY] == '.')
            {
                pacManCoodinationX = nextPacManPositionX;
                pacManCoodinationY = nextPacManPositionY;
            }
        }

        static int CollectCoin(char[,] map, ConsoleKeyInfo pressedKey, ref int pacManCoodinationX, ref int pacManCoodinationY)
        {
            if (map[pacManCoodinationX, pacManCoodinationY] == '.')
            {
                map[pacManCoodinationX, pacManCoodinationY] = ' ';
                return 1;
            }
            else
            {
                return 0;
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
        
        static void MovePlayer(int pacManCoordinationX, int pacManCoordinationY, char player)
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

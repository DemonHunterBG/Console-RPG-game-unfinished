using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RPG_Game_2
{
    class MapGenerator
    {
        private static char[] characters = { '-', '-', '-', '-', 'M', 'E', 'E', 'S' };
        private static char[] charactersnoShop = { '-', '-', '-', '-', '-', 'M', 'E', 'E' };

        public static void MapGenController()
        {
            MapGen();
        }
        private static void MapGen()
        {
            Random random = new Random(Guid.NewGuid().GetHashCode());

            int ROWS = random.Next(5, 8);
            int COLS = random.Next(5, 8);

            char[,] map = new char[ROWS, COLS];
            int numberofcharacters = 0;
            int halfarray = (map.GetLength(0) * map.GetLength(1)) / 2;

            int maxnumberofshops = 1;

            for (int row = 0; row < ROWS; row++)
            {
                for (int col = 0; col < COLS; col++)
                {
                    numberofcharacters++;
                    if (row == 0 && col == 0)
                        map[row, col] = 'X';
                    else if (row == map.GetLength(0) - 1 && col == map.GetLength(1) - 1)
                        map[row, col] = '!';
                    else if (numberofcharacters <= halfarray)
                        map[row, col] = charactersnoShop[random.Next(0, charactersnoShop.Count())];
                    else if (maxnumberofshops > 0)
                    {
                        map[row, col] = characters[random.Next(0, characters.Count())];
                        if (map[row, col] == 'S')
                            maxnumberofshops--;
                    }
                    else
                        map[row, col] = charactersnoShop[random.Next(0, charactersnoShop.Count())];
                }
            }
            Map.map = map;
            MapVisibilityGen(ROWS, COLS);

        }
        private static void MapVisibilityGen(int ROWS, int COLS)
        {
            int[,] map = new int[ROWS, COLS];
            for (int row = 0; row < ROWS; row++)
            {
                for (int col = 0; col < COLS; col++)
                {
                    map[row, col] = 0;
                }
            }
            Map.mapVisibility = map;
        }
    }
}

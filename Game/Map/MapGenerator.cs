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
        private static char[] charactersnoShopAndMountains = { '-', '-', '-', '-', '-', '-', 'E', 'E' };

        public static void MapGenController()
        {
            MapGen();
        }
        private static void MapGen()
        {
            Random random = new Random(Guid.NewGuid().GetHashCode());

            int mapnumber = random.Next(1, 3);
            switch (mapnumber)
            {
                case 1:
                    Map.mapname = "Slime Plains";
                    break;
                case 2:
                    Map.mapname = "Undead Lands";
                    break;
            }

            int ROWS = random.Next(6, 9);
            int COLS = random.Next(6, 9);

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
            MapStartAndEndAntiBlock(random, map);

            Map.map = map;
            MapVisibilityGen(ROWS, COLS);

        }

        private static void MapStartAndEndAntiBlock(Random random, char[,] map)
        {
            int spawnAntiBlock = random.Next(1, 3);
            int endAntiBlock = random.Next(1, 3);
            switch (spawnAntiBlock)
            {
                case 1:
                    if (map[1, 0] == 'M')
                    {
                        map[1, 0] = charactersnoShopAndMountains[random.Next(0, charactersnoShop.Count())];
                    }
                    break;
                case 2:
                    if (map[0, 1] == 'M')
                    {
                        map[0, 1] = charactersnoShopAndMountains[random.Next(0, charactersnoShop.Count())];
                    }
                    break;
            }
            map[1, 1] = charactersnoShopAndMountains[random.Next(0, charactersnoShop.Count())];

            switch (endAntiBlock)
            {
                case 1:
                    if (map[map.GetLength(0) - 2, map.GetLength(1) - 1] == 'M')
                    {
                        map[map.GetLength(0) - 2, map.GetLength(1) - 1] = charactersnoShopAndMountains[random.Next(0, charactersnoShop.Count())];
                    }
                    break;
                case 2:
                    if (map[map.GetLength(0) - 1, map.GetLength(1) - 2] == 'M')
                    {
                        map[map.GetLength(0) - 1, map.GetLength(1) - 2] = charactersnoShopAndMountains[random.Next(0, charactersnoShop.Count())];
                    }
                    break;
            }
            map[map.GetLength(0) - 2, map.GetLength(1) - 2] = charactersnoShopAndMountains[random.Next(0, charactersnoShop.Count())];
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
            map[ROWS - 1, COLS - 1] = 1;
            Map.mapVisibility = map;
        }
    }
}

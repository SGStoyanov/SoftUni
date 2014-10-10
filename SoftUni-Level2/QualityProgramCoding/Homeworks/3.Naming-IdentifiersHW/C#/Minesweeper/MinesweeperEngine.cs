namespace Minesweeper
{
    using System;
    using System.Collections.Generic;

    public class MinesweeperEngine
    {
        public class PlayersResults
        {
            private string name;

            private int points;

            public string Name
            {
                get
                {
                    return name;
                }

                set
                {
                    name = value;
                }
            }

            public int Points
            {
                get
                {
                    return points;
                }

                set
                {
                    points = value;
                }
            }

            public PlayersResults()
            {
            }

            public PlayersResults(string name, int points)
            {
                this.Name = name;
                this.Points = points;
            }
        }

        private static void Main()
        {
            string playerMove = string.Empty;
            char[,] playground = CreatePlayField();
            char[,] fieldBombs = PutBombs();
            int pointsCounter = 0;
            bool mineDetonation = false;
            List<PlayersResults> champions = new List<PlayersResults>(6);
            int row = 0;
            int column = 0;
            bool isGameOn = true;
            const int maxTarget = 35;
            bool isMaxTargetCompleted = false;

            do
            {
                if (isGameOn)
                {
                    Console.WriteLine(
                        "Hajde da igraem na “Mini4KI”. Probvaj si kasmeta da otkriesh poleteta bez mini4ki."
                        + " Komanda 'top' pokazva klasiraneto, 'restart' po4va nova igra, 'exit' izliza i hajde 4ao!");
                    CreateGame(playground);
                    isGameOn = false;
                }

                Console.Write("Daj red i kolona : ");
                playerMove = Console.ReadLine().Trim();
                if (playerMove.Length >= 3)
                {
                    if (int.TryParse(playerMove[0].ToString(), out row) && int.TryParse(playerMove[2].ToString(), out column)
                        && row <= playground.GetLength(0) && column <= playground.GetLength(1))
                    {
                        playerMove = "turn";
                    }
                }

                switch (playerMove)
                {
                    case "top":
                        PlayersRanking(champions);
                        break;
                    case "restart":
                        playground = CreatePlayField();
                        fieldBombs = PutBombs();
                        CreateGame(playground);
                        mineDetonation = false;
                        isGameOn = false;
                        break;
                    case "exit":
                        Console.WriteLine("4a0, 4a0, 4a0!");
                        break;
                    case "turn":
                        if (fieldBombs[row, column] != '*')
                        {
                            if (fieldBombs[row, column] == '-')
                            {
                                MovePlayer(playground, fieldBombs, row, column);
                                pointsCounter++;
                            }

                            if (maxTarget == pointsCounter)
                            {
                                isMaxTargetCompleted = true;
                            }
                            else
                            {
                                CreateGame(playground);
                            }
                        }
                        else
                        {
                            mineDetonation = true;
                        }

                        break;
                    default:
                        Console.WriteLine("\nGreshka! nevalidna Komanda\n");
                        break;
                }

                if (mineDetonation)
                {
                    CreateGame(fieldBombs);
                    Console.Write("\nHrrrrrr! Umria gerojski s {0} to4ki. " + "Daj si niknejm: ", pointsCounter);
                    string nickname = Console.ReadLine();
                    PlayersResults t = new PlayersResults(nickname, pointsCounter);
                    if (champions.Count < 5)
                    {
                        champions.Add(t);
                    }
                    else
                    {
                        for (int i = 0; i < champions.Count; i++)
                        {
                            if (champions[i].Points < t.Points)
                            {
                                champions.Insert(i, t);
                                champions.RemoveAt(champions.Count - 1);
                                break;
                            }
                        }
                    }

                    champions.Sort((PlayersResults r1, PlayersResults r2) => r2.Name.CompareTo(r1.Name));
                    champions.Sort((PlayersResults r1, PlayersResults r2) => r2.Points.CompareTo(r1.Points));
                    PlayersRanking(champions);

                    playground = CreatePlayField();
                    fieldBombs = PutBombs();
                    pointsCounter = 0;
                    mineDetonation = false;
                    isGameOn = true;
                }

                if (isMaxTargetCompleted)
                {
                    Console.WriteLine("\nBRAVOOOS! Otvri 35 kletki bez kapka kryv.");
                    CreateGame(fieldBombs);
                    Console.WriteLine("Daj si imeto, batka: ");
                    string playerName = Console.ReadLine();
                    PlayersResults pointsResult = new PlayersResults(playerName, pointsCounter);
                    champions.Add(pointsResult);
                    PlayersRanking(champions);
                    playground = CreatePlayField();
                    fieldBombs = PutBombs();
                    pointsCounter = 0;
                    isMaxTargetCompleted = false;
                    isGameOn = true;
                }
            }
            while (playerMove != "exit");
            Console.WriteLine("Made in Bulgaria - Uauahahahahaha!");
            Console.WriteLine("AREEEEEEeeeeeee.");
            Console.Read();
        }

        private static void PlayersRanking(List<PlayersResults> pointsResult)
        {
            Console.WriteLine("\nTo4KI:");
            if (pointsResult.Count > 0)
            {
                for (int i = 0; i < pointsResult.Count; i++)
                {
                    Console.WriteLine("{0}. {1} --> {2} kutii", i + 1, pointsResult[i].Name, pointsResult[i].Points);
                }

                Console.WriteLine();
            }
            else
            {
                Console.WriteLine("prazna klasaciq!\n");
            }
        }

        private static void MovePlayer(char[,] POLE, char[,] BOMBI, int RED, int KOLONA)
        {
            char bombsCount = GetMinesCount(BOMBI, RED, KOLONA);
            BOMBI[RED, KOLONA] = bombsCount;
            POLE[RED, KOLONA] = bombsCount;
        }

        private static void CreateGame(char[,] board)
        {
            int boardWidth = board.GetLength(0);
            int boardHeight = board.GetLength(1);
            Console.WriteLine("\n    0 1 2 3 4 5 6 7 8 9");
            Console.WriteLine("   ---------------------");
            for (int i = 0; i < boardWidth; i++)
            {
                Console.Write("{0} | ", i);
                for (int j = 0; j < boardHeight; j++)
                {
                    Console.Write(string.Format("{0} ", board[i, j]));
                }

                Console.Write("|");
                Console.WriteLine();
            }

            Console.WriteLine("   ---------------------\n");
        }

        private static char[,] CreatePlayField()
        {
            int boardRows = 5;
            int boardColumns = 10;
            char[,] board = new char[boardRows, boardColumns];
            for (int i = 0; i < boardRows; i++)
            {
                for (int j = 0; j < boardColumns; j++)
                {
                    board[i, j] = '?';
                }
            }

            return board;
        }

        private static char[,] PutBombs()
        {
            int fieldRows = 5;
            int fieldColumns = 10;
            char[,] playground = new char[fieldRows, fieldColumns];

            for (int row = 0; row < fieldRows; row++)
            {
                for (int column = 0; column < fieldColumns; column++)
                {
                    playground[row, column] = '-';
                }
            }

            List<int> bombsList = new List<int>();
            while (bombsList.Count < 15)
            {
                Random random = new Random();
                int randomBombId = random.Next(50);
                if (!bombsList.Contains(randomBombId))
                {
                    bombsList.Add(randomBombId);
                }
            }

            foreach (int bomb in bombsList)
            {
                int column = bomb / fieldColumns;
                int row = bomb % fieldColumns;
                if (row == 0 && bomb != 0)
                {
                    column--;
                    row = fieldColumns;
                }
                else
                {
                    row++;
                }

                playground[column, row - 1] = '*';
            }

            return playground;
        }

        private static void GetLocationsMinesCount(char[,] playground)
        {
            int maxColumns = playground.GetLength(0);
            int maxRows = playground.GetLength(1);

            for (int column = 0; column < maxColumns; column++)
            {
                for (int row = 0; row < maxRows; row++)
                {
                    if (playground[column, row] != '*')
                    {
                        char minesCount = GetMinesCount(playground, column, row);
                        playground[column, row] = minesCount;
                    }
                }
            }
        }

        private static char GetMinesCount(char[,] minesArray, int minesArrayRows, int minesArrayColumns)
        {
            int minesCounter = 0;
            int maxRows = minesArray.GetLength(0);
            int maxColumns = minesArray.GetLength(1);

            if (minesArrayRows - 1 >= 0)
            {
                if (minesArray[minesArrayRows - 1, minesArrayColumns] == '*')
                {
                    minesCounter++;
                }
            }

            if (minesArrayRows + 1 < maxRows)
            {
                if (minesArray[minesArrayRows + 1, minesArrayColumns] == '*')
                {
                    minesCounter++;
                }
            }

            if (minesArrayColumns - 1 >= 0)
            {
                if (minesArray[minesArrayRows, minesArrayColumns - 1] == '*')
                {
                    minesCounter++;
                }
            }

            if (minesArrayColumns + 1 < maxColumns)
            {
                if (minesArray[minesArrayRows, minesArrayColumns + 1] == '*')
                {
                    minesCounter++;
                }
            }

            if ((minesArrayRows - 1 >= 0) && (minesArrayColumns - 1 >= 0))
            {
                if (minesArray[minesArrayRows - 1, minesArrayColumns - 1] == '*')
                {
                    minesCounter++;
                }
            }

            if ((minesArrayRows - 1 >= 0) && (minesArrayColumns + 1 < maxColumns))
            {
                if (minesArray[minesArrayRows - 1, minesArrayColumns + 1] == '*')
                {
                    minesCounter++;
                }
            }

            if ((minesArrayRows + 1 < maxRows) && (minesArrayColumns - 1 >= 0))
            {
                if (minesArray[minesArrayRows + 1, minesArrayColumns - 1] == '*')
                {
                    minesCounter++;
                }
            }

            if ((minesArrayRows + 1 < maxRows) && (minesArrayColumns + 1 < maxColumns))
            {
                if (minesArray[minesArrayRows + 1, minesArrayColumns + 1] == '*')
                {
                    minesCounter++;
                }
            }

            return char.Parse(minesCounter.ToString());
        }
    }
}
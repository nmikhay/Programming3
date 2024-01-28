using System;

class GameBoard
{
    private bool[,] board;
    private int size;
    private Random random;

    public GameBoard(int size)
    {
        this.size = size;
        board = new bool[size, size];
        random = new Random();

        int shipRow = random.Next(size);
        int shipCol = random.Next(size);
        board[shipRow, shipCol] = true;
    }

    public bool IsShipAt(int row, int col)
    {
        return board[row, col];
    }
}

class BattleshipGame
{
    static void Main()
    {
        int boardSize = 5;

        GameBoard gameBoard = new GameBoard(boardSize);

        for (int row = 0; row < boardSize; row++)
        {
            for (int col = 0; col < boardSize; col++)
            {
                Console.WriteLine($"Guessing cell [{row}, {col}]...");
                bool hit = gameBoard.IsShipAt(row, col);

                if (hit)
                {
                    Console.WriteLine("Hit!");
                }
                else
                {
                    Console.WriteLine("Miss!");
                }
            }
        }

        Console.WriteLine("Press any key to exit.");
        Console.ReadKey();
    }
}


using System;

namespace TicTacToeChecker
{
    /*
        If we were to set up a Tic-Tac-Toe game, we would want to know whether the board's current state is solved, wouldn't we? Our goal is to create a function that will check that for us!

        Assume that the board comes in the form of a 3x3 array, where the value is 0 if a spot is empty, 1 if it is an "X", or 2 if it is an "O", like so:

        [[0, 0, 1],
         [0, 1, 2],
         [2, 1, 0]]

        We want our function to return:

        -1 if the board is not yet finished AND no one has won yet (there are empty spots),
        1 if "X" won,
        2 if "O" won,
        0 if it's a cat's game (i.e. a draw).

        You may assume that the board passed in is valid in the context of a game of Tic-Tac-Toe.
    */

    internal class Program
    {
        static void Main(string[] args)
        {
            int[,] board = { { 2, 1, 1 }, { 0, 1, 1 }, { 2, 2, 2 } };

            Console.WriteLine("| {0} {1} {2} |", board[0,0], board[0,1], board[0,2]);
            Console.WriteLine("| {0} {1} {2} |", board[1, 0], board[1, 1], board[1, 2]);
            Console.WriteLine("| {0} {1} {2} |", board[2, 0], board[2, 1], board[2, 2]);

            Console.WriteLine("\nOutput: " + IsSolved(board));

            Console.Read();
        }

        public static int IsSolved(int[,] board)
        {
            int result = 0;
            bool boardFull = true;

            for (int col = 0; col < board.GetLength(0); col++)
            {
                for (int row = 0; row < board.GetLength(1); row++)
                {
                    // If in the final column, check back across the row
                    if (col == 2)
                    {
                        if (board[col, row] == board[col - 1, row] && board[col, row] == board[col - 2, row])
                        {
                            switch (board[col, row])
                            {
                                case 0:
                                    boardFull = false;
                                    break;
                                case 1:
                                    result = 1;
                                    break;
                                case 2:
                                    result = 2;
                                    break;
                                default:
                                    break;
                            }
                        }
                    }
                    // If in the final row, check back across the column
                    if (row == 2)
                    {
                        if (board[col, row] == board[col, row - 1] && board[col, row] == board[col, row - 2])
                        {
                            switch (board[col, row])
                            {
                                case 0:
                                    boardFull = false;
                                    break;
                                case 1:
                                    result = 1;
                                    break;
                                case 2:
                                    result = 2;
                                    break;
                                default:
                                    break;
                            }
                        }
                    }
                    // If at the end, check the diagonals
                    if(col == 2 && row == 2)
                    {
                        if(board[col,row] == board[col-1,row-1] && board[col,row] == board[col - 2, row - 2])
                        {
                            switch (board[col, row])
                            {
                                case 0:
                                    boardFull = false;
                                    break;
                                case 1:
                                    result = 1;
                                    break;
                                case 2:
                                    result = 2;
                                    break;
                                default:
                                    break;
                            }
                        }
                        if (board[col, 0] == board[col - 1, 1] && board[col, 0] == board[col - 2, 2])
                        {
                            switch (board[col, row])
                            {
                                case 0:
                                    boardFull = false;
                                    break;
                                case 1:
                                    result = 1;
                                    break;
                                case 2:
                                    result = 2;
                                    break;
                                default:
                                    break;
                            }
                        }
                    }
                }
            }
            
            // If the game hasn't been won, check for empty spaces to determine whether game is a draw or ongoing
            if(result < 1)
            {
                foreach (var item in board)
                {
                    if (item == 0)
                        boardFull = false;
                }

                if (!boardFull)
                    result = -1;
                else
                    result = 0;
            }

            return result;
        }
    }
}

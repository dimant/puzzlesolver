class Solution
{
    private Stack<(PuzzlePiece, (int, int))> stack = new Stack<(PuzzlePiece, (int, int))>();

    private char[][] board = new char[8][];

    private readonly (int, int)[] directions = [(0, 1), (1, 0), (0, -1), (-1, 0)];

    public Solution()
    {
        for (int row = 0; row < 8; row++)
        {
            for (int col = 0; col < 8; col++)
            {
                board[row][col] = '.';
            }
        }
    }

    public void PrintSolution()
    {
        foreach (var item in stack)
        {
            (PuzzlePiece piece, (int row, int col)) = item;
            Console.WriteLine($"Row: {row}");
            Console.WriteLine($"Col: {col}");
            Console.WriteLine(piece);
        }
    }

    public void PrintBoard()
    {
        for (int row = 0; row < 8; row++)
        {
            for (int col = 0; col < 8; col++)
            {
                Console.Write(board[row][col]);
            }
            Console.WriteLine();
        }
    }

    public bool TryAddPiece(PuzzlePiece piece, int row, int col)
    {
        if (row < 0 || row >= 8 || col < 0 || col >= 8)
        {
            return false;
        }

 
        for (int i = 0; i < piece.GetRotation().Length; i++)
        {
            (int offsetrow, int offsetcol) = piece.GetRotation()[i];

            // check board edges
            if (row + offsetrow < 0 || row + offsetrow >= 8 || col + offsetcol < 0 || col + offsetcol >= 8)
            {
                return false;
            }

            // check if the cell is already occupied
            if (board[row + offsetrow][col + offsetcol] != '.')
            {
                return false;
            }

            // check if the cell is not adjacent to a cell with the same color
            if (row + offsetrow - 1 >= 0 && 
                board[row + offsetrow - 1][col + offsetcol] == piece.GetColors()[i])
            {
                return false;
            }

            // check if the cell is not adjacent to a cell with the same color
            foreach (var direction in directions)
            {
                (int checkrow, int checkcol) = direction;

                if (row + offsetrow + checkrow >= 0 && row + offsetrow + checkrow < 8 &&
                    col + offsetcol + checkcol >= 0 && col + offsetcol + checkcol < 8 &&
                    board[row + offsetrow + checkrow][col + offsetcol + checkcol] == piece.GetColors()[i])
                {
                    return false;
                }
            }
        }

        // add the piece to the board
        stack.Push((piece, (row, col)));

        for (int i = 0; i < piece.GetRotation().Length; i++)
        {
            (int offsetrow, int offsetcol) = piece.GetRotation()[i];
            board[row + offsetrow][col + offsetcol] = piece.GetColors()[i];
        }

        return true;
    }

    public PuzzlePiece RemoveLast()
    {
        if (stack.Count == 0)
        {
            throw new InvalidOperationException($"Tried to remove a piece from an empty board");
        }

        (PuzzlePiece piece, (int row, int col)) = stack.Pop();

        for (int i = 0; i < piece.GetRotation().Length; i++)
        {
            (int offsetrow, int offsetcol) = piece.GetRotation()[i];
            board[row + offsetrow][col + offsetcol] = '.';
        }

        return piece;
    }
}
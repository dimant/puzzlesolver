class Solver
{
    public Solution? Solve(PuzzlePiece[] pieces)
    {
        var solution = new Solution();

        if (Solve(solution, pieces, 0))
        {
            return solution;
        }

        return null;
    }

    private bool Solve(Solution solution, PuzzlePiece[] pieces, int index)
    {
        if (index == pieces.Length)
        {
            return true;
        }

        for (int row = 0; row < 8; row++)
        {
            for (int col = 0; col < 8; col++)
            {
                var piece = pieces[index];

                for (int rotation = 0; rotation < piece.RotationsCount; rotation++)
                {
                    piece.Rotation = rotation;

                    if (solution.TryAddPiece(piece, row, col))
                    {
                        if (Solve(solution, pieces, index + 1))
                        {
                            return true;
                        }

                        solution.RemoveLast();
                    }
                }
            }
        }

        return false;
    }
}
class Data
{
    public List<PuzzlePiece> PuzzlePieces { get; } = new List<PuzzlePiece>();

    public Data()
    {
        PuzzlePieces.Add(new PuzzlePiece(new List<(int, int)[]>
        {
            //    0 1
            //  0 W
            //  1 B W
            //  2   B
            //  3   W
            new (int, int)[] { (0, 0), (1, 0), (1, 1), (2, 1), (3, 1) },

            //    0 1 2 3
            // -1     B W
            //  0 W B W
            new (int, int)[] { (0, 0), (0, 1), (0, 2), (-1, 2), (-1, 3) },

            //    0 1
            //  0 W
            //  1 B
            //  2 W B
            //  3   W
            new (int, int)[] { (0, 0), (1, 0), (2, 0), (2, 1), (3, 1) },

            //  v 0 1 2 3
            // -1   W B W
            //  0 W B
            new (int, int)[] { (0, 0), (0, 1), (-1, 1), (-1, 2), (-1, 3) },
        }, new List<char[]>
        {
            new char[] { 'W', 'B', 'W', 'B', 'W' },
            new char[] { 'B', 'w', 'W', 'B', 'W' },
            new char[] { 'W', 'B', 'W', 'B', 'W' },
            new char[] { 'W', 'B', 'W', 'B', 'W' },
        }));

        PuzzlePieces.Add(new PuzzlePiece(new List<(int, int)[]>() {

            //    0 1 2
            // -1   W B
            //  0 W B
            //  1 B
            new (int, int)[] { (0, 0), (0, 1), (-1, 1), (-1, 2), (1, 0) },

            //   0 1 2
            // 0 B W
            // 1   B W
            // 2     B
            new (int, int)[] { (0, 0), (0, 1), (1, 1), (1, 2), (2, 2) },

            //    0 1 2
            // -2     B
            // -1   B W
            //  0 B W
            new (int, int)[] { (0, 0), (0, 1), (-1, 1), (-1, 2), (-2, 2) },

            //   0 1 2
            // 0 B
            // 1 W B
            // 2   W B
            new (int, int)[] { (0, 0), (1, 0), (1, 1), (2, 1), (2, 2) },

        }, new List<char[]>() {
            new char[] { 'W', 'B', 'W', 'B', 'B' },
            new char[] { 'B', 'W', 'B', 'W', 'B' },
            new char[] { 'B', 'W', 'B', 'W', 'B' },
            new char[] { 'B', 'W', 'B', 'W', 'B' },
        }));
    }
}
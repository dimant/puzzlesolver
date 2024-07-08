using System.Text;
using Microsoft.VisualBasic;

class PuzzlePiece
{
    private List<(int, int)[]> rotations;

    private List<char[]> colors;

    public int RotationCount => rotations.Count;

    private int rotation = 0;

    public int Rotation {
        get => rotation;
        set 
        {
            if (value < 0 || value >= rotations.Count)
            {
                throw new ArgumentOutOfRangeException();
            }

            rotation = value;
        }
    }

    public override string ToString()
    {
        var offsets = rotations[rotation].ToList();

        var minRow = offsets.Min(x => x.Item1);
        var minCol = offsets.Min(x => x.Item2);

        var maxRow = offsets.Max(x => x.Item1);
        var maxCol = offsets.Max(x => x.Item2);

        var rows = maxRow - minRow + 1;
        var cols = maxCol - minCol + 1;

        var sb = new StringBuilder();

        char[][] canvas = new char[rows][];

        for (int i = 0; i < rows; i++)
        {
            canvas[i] = new char[cols];
            for (int j = 0; j < cols; j++)
            {
                canvas[i][j] = ' ';
            }
        }

        for (int i = 0; i < offsets.Count; i++)
        {
            (int row, int col) = offsets[i];

            canvas[row - minRow][col - minCol] = colors[rotation][i];
        }

        foreach (var canvasRow in canvas)
        {
            sb.AppendLine(string.Join(" ", canvasRow));
        }

        return sb.ToString();
    }

    public PuzzlePiece(List<(int, int)[]> rotations, List<char[]> colors)
    {
        this.rotations = rotations;
        this.colors = colors;
    }

    public (int, int)[] GetRotation()
    {
        return rotations[rotation];
    }

    public char[] GetColors()
    {
        return colors[rotation];
    }
}
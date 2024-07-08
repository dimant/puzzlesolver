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

        var maxRow = offsets.Max(x => x.Item1);
        var maxCol = offsets.Max(x => x.Item2);

        char[][] canvas = new char[maxRow + 1][];

        for (int i = 0; i < maxRow + 1; i++)
        {
            canvas[i] = new char[maxCol + 1];
            for (int j = 0; j < maxCol + 1; j++)
            {
                canvas[i][j] = ' ';
            }
        }

        for (int i = 0; i < offsets.Count; i++)
        {
            (int row, int col) = offsets[i];
            canvas[row][col] = colors[rotation][i];
        }

        var builder = new StringBuilder();

        foreach (var row in canvas)
        {
            builder.AppendLine(new string(row));
        }

        return builder.ToString();
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
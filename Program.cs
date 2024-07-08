namespace puzzlesolver;

class Program
{
    static void Main(string[] args)
    {
        var data = new Data();
        var piece = data.PuzzlePieces[1];

        for (int rotation = 0; rotation < piece.RotationCount; rotation++)
        {
            piece.Rotation = rotation;
            Console.WriteLine(piece);
        }
    }
}

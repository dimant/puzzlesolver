namespace puzzlesolver;

class Program
{
    static void Main(string[] args)
    {
        var data = new Data();
        var piece = data.PuzzlePieces[4];

        for (int rotation = 0; rotation < piece.RotationsCount; rotation++)
        {
            piece.Rotation = rotation;
            Console.WriteLine(piece);
        }
    }
}

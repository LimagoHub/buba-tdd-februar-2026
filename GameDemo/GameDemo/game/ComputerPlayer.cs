using GameDemo.io;

namespace GameDemo.game;

public class ComputerPlayer(IWriter writer)
{
    private static readonly int[] Moves = [3, 1, 1, 2];

    public int DoTurn(int stones)
    {
        var move = Moves[stones % 4];
        writer.Write($"Computer nimmt {move} Steine");
        return move;
    }
}
using System;
using Avalonia.Input;
using Digger.Architecture;

namespace Digger;

public class Player : ICreature
{
    private int dX;
    private int dY;

    public string GetImageFileName()
    {
        return "Digger.png";
    }

    public int GetDrawingPriority()
    {
        return 0;
    }

    public CreatureCommand Act(int x, int y)
    {
        dX = 0;
        dY = 0;
        switch (Game.KeyPressed)
        {
            case Key.Up:
                dY = -1;
                break;
            case Key.Down:
                dY = 1;
                break;
            case Key.Right:
                dX = 1;
                break;
            case Key.Left:
                dX = -1;
                break;
            default:
                return new CreatureCommand() { DeltaX = 0, DeltaY = 0, TransformTo = null };
        }

        if (!(x + dX >= 0 && x + dX < Game.MapWidth && y + dY >= 0 && y + dY < Game.MapHeight))
        {
            return new CreatureCommand() { DeltaX = 0, DeltaY = 0, TransformTo = null };
        }

        if (Game.Map[x + dX, y + dY] != null)
        {
            if (Game.Map[x + dX, y + dY].ToString() == "Digger.Sack")
            {
                dX = 0;
                dY = 0;
            }
            else if (Game.Map[x + dX, y + dY].ToString() == "Digger.Gold")
                Game.Scores += 10;
        }

        return new CreatureCommand() { DeltaX = dX, DeltaY = dY, TransformTo = null };
    }

    public bool DeadInConflict(ICreature conflictedObject)
    {
        return (conflictedObject.ToString() == "Digger.Sack" || conflictedObject.ToString() == "Digger.Monster");
    }
}
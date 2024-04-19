using System;
using Avalonia.Input;
using Digger.Architecture;

namespace Digger;

public class Sack : ICreature
{
    private int counter;

    public string GetImageFileName()
    {
        return "Sack.png";
    }

    public int GetDrawingPriority()
    {
        return 5;
    }

    public CreatureCommand Act(int x, int y)
    {
        if (y + 1 < Game.MapHeight)
            if (Game.Map[x, y + 1] == null || (counter > 0 && (Game.Map[x, y + 1].ToString() == "Digger.Player" ||
                                                               Game.Map[x, y + 1].ToString() == "Digger.Monster")))
            {
                counter++;
                return new CreatureCommand() { DeltaX = 0, DeltaY = 1, TransformTo = null };
            }

        if (counter > 1)
        {
            counter = 0;
            return new CreatureCommand() { DeltaX = 0, DeltaY = 0, TransformTo = new Gold() };
        }

        counter = 0;
        return new CreatureCommand() { DeltaX = 0, DeltaY = 0, TransformTo = null };
    }

    public bool DeadInConflict(ICreature conflictedObject)
    {
        return false;
    }
}
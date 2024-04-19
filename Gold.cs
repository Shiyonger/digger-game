using System;
using Avalonia.Input;
using Digger.Architecture;

namespace Digger;

public class Gold : ICreature
{
    public string GetImageFileName()
    {
        return "Gold.png";
    }

    public int GetDrawingPriority()
    {
        return 4;
    }

    public CreatureCommand Act(int x, int y)
    {
        return new CreatureCommand() { DeltaX = 0, DeltaY = 0, TransformTo = null };
    }

    public bool DeadInConflict(ICreature conflictedObject)
    {
        return (conflictedObject.ToString() == "Digger.Player" || conflictedObject.ToString() == "Digger.Monster");
    }
}
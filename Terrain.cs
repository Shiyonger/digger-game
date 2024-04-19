using System;
using Avalonia.Input;
using Digger.Architecture;

namespace Digger;

public class Terrain : ICreature
{
    public string GetImageFileName()
    {
        return "Terrain.png";
    }

    public int GetDrawingPriority()
    {
        return 1;
    }

    public CreatureCommand Act(int x, int y)
    {
        return new CreatureCommand() { DeltaX = 0, DeltaY = 0, TransformTo = null };
    }

    public bool DeadInConflict(ICreature conflictedObject)
    {
        return true;
    }
}
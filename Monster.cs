using System;
using Avalonia.Input;
using Digger.Architecture;

namespace Digger;

public class Monster : ICreature
{
    public string GetImageFileName()
    {
        return "Monster.png";
    }

    public int GetDrawingPriority()
    {
        return 2;
    }

    public CreatureCommand Act(int x, int y)
    {
        bool diggerAlive = FindDigger(out int diggerX, out int diggerY);
        int dX = 0;
        int dY = 0;

        if (diggerAlive)
        {
            if (diggerX - x > 0) dX = 1;
            else if (diggerX - x < 0) dX = -1;
            else if (diggerX == x)
            {
                if (diggerY - y > 0) dY = 1;
                else if (diggerY - y < 0) dY = -1;
            }

            if (!(x + dX >= 0 && x + dX < Game.MapWidth && y + dY >= 0 && y + dY < Game.MapHeight))
            {
                return new CreatureCommand() { DeltaX = 0, DeltaY = 0, TransformTo = null };
            }

            if (Game.Map[x + dX, y + dY] != null)
            {
                if (Game.Map[x + dX, y + dY].ToString() == "Digger.Sack"
                    || Game.Map[x + dX, y + dY].ToString() == "Digger.Terrain"
                    || Game.Map[x + dX, y + dY].ToString() == "Digger.Monster")
                {
                    dX = 0;
                    dY = 0;
                }
            }
        }

        return new CreatureCommand() { DeltaX = dX, DeltaY = dY, TransformTo = null };
    }

    public bool DeadInConflict(ICreature conflictedObject)
    {
        return (conflictedObject.ToString() == "Digger.Monster" || conflictedObject.ToString() == "Digger.Sack");
    }

    private bool FindDigger(out int x, out int y)
    {
        for (int i = 0; i < Game.MapWidth; i++)
        {
            for (int j = 0; j < Game.MapHeight; j++)
            {
                if (Game.Map[i, j] != null && Game.Map[i, j].ToString() == "Digger.Player")
                {
                    x = i;
                    y = j;
                    return true;
                }
            }
        }

        x = -1;
        y = -1;
        return false;
    }
}
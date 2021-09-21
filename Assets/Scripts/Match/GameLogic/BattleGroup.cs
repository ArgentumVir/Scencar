using System.Collections.Generic;

public class BattleGroup
{

    public List<Unit> Units { get; private set; }

    public BattleGroup()
    {
        Units = new List<Unit>();
    }

    public void Add(Unit unit)
    {
        Units.Add(unit);
    }

    public void Remove(Unit unit)
    {
        Units.Remove(unit);
    }

    enum Type
    {
        Unknown = 0,
        Ground = 1,
        Naval = 2,
        Aerial = 3
    }
}
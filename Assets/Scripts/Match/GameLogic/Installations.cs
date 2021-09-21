using System.Collections.Generic;

public class Installations
{
    public List<Unit> Units { get; private set; }

    public Installations()
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
}
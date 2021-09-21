using System;

public class Unit
{
    public string Name { get; private set; }
    public int Offense { get; private set; }
    public int Defense { get; private set; }
    public Unit(string name, int offense, int defense)
    {
        Name = name;
        Offense = offense;
        Defense = defense;
    }

    public static Unit RandomUnit(int maxOffense = 10, int maxDefense = 10)
    {
        Random random = new Random();
        return new Unit(
            Guid.NewGuid().ToString(),
            random.Next(maxOffense),
            random.Next(maxDefense)
        );
    }
}
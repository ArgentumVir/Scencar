using System;

public class Card
{
    public string Name { get; private set; }
    public SuperType CardSuperType { get; private set; }
    public Card()
    {
        // Randomness as place holder for different cards
        Random random = new Random();
        var types = Enum.GetValues(typeof(SuperType));

        CardSuperType = (SuperType)types.GetValue(random.Next(types.Length));
        Name = Guid.NewGuid().ToString();
    }

    public enum SuperType
    {
        Unknown = 0,
        Multiple = 1,  // For future special cards
        Dynamic = 2, // For future special cards
        Deployment = 3,
        Construction = 4,
        Doctrine = 5,
        Scenario = 6,
        Logistics = 7,
        Operation = 8,
        SpecialOperation = 9
    }
}
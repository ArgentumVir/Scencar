using System.Collections.Generic;

public class PlayerState
{
    public Deck Deck { get; private set; }
    public int Health { get; private set; }

    public List<Card> Library { get; private set; }
    public List<Card> Hand { get; private set; }
    public List<Card> Scrapyard { get; private set; }
    public List<Card> FieldHospital { get; private set; }
    public List<Card> Oblivion { get; private set; }

    public BattleGroup NavalBattleGroup { get; private set; }
    public BattleGroup GroundBattleGroup { get; private set; }
    public BattleGroup AerialBattleGroup { get; private set; }

    public Installations NavalInstallations { get; private set; }
    public Installations GroundInstallations { get; private set; }
    public Installations AerialInstallations { get; private set; }

    public PlayerState(int startingHealth, Deck deck)
    {
        Health = startingHealth;
        Deck = deck;

        Library = new List<Card>();
        Hand = new List<Card>();
        Scrapyard = new List<Card>();
        FieldHospital = new List<Card>();
        Oblivion = new List<Card>();

        NavalBattleGroup = new BattleGroup();
        GroundBattleGroup = new BattleGroup();
        AerialBattleGroup = new BattleGroup();

        NavalInstallations = new Installations();
        GroundInstallations = new Installations();
        AerialInstallations = new Installations();
    }
}
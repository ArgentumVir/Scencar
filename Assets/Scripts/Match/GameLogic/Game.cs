using System.Collections.Generic;

public class Game
{
    private GameState currentGameState;
    private Format format;
    public delegate (List<Card>, List<Card>) MulliganHandler(List<Card> hand, List<Card> deck);

    // Player One is the starting player
    public Game(
        Format format,
        Deck playerOneDeck,
        Deck playerTwoDeck
        
    )
    {
        this.format = format;


    }

    public enum Format
    {
        Unknown = 0,
        Normal = 1
    }
}
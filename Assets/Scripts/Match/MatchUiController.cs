using System.Collections;
using System.Collections.Generic;
using MLAPI;
using TMPro;
using UnityEngine;

public class MatchUiController : ExtendedMonoBehaviour
{
    const string PLAYER_NAME_GAME_OBJECT = "PlayerName";
    private TextMeshProUGUI playerNameText;
    const string OPPONENT_NAME_GAME_OBJECT = "OpponentName";
    private TextMeshProUGUI opponentNameText;

    void Awake()
    {
        playerNameText = FetchChildComponent<TextMeshProUGUI>(PLAYER_NAME_GAME_OBJECT);
        opponentNameText = FetchChildComponent<TextMeshProUGUI>(OPPONENT_NAME_GAME_OBJECT);
    }

    // Update is called once per frame
    void Update()
    {
        MatchExecutor.PlayerType localClientId = MatchExecutor.Singleton.GetPlayerType(NetworkManager.Singleton.LocalClientId);
        switch (localClientId)
        {
            case MatchExecutor.PlayerType.PlayerOne:
                playerNameText.text = MatchExecutor.Singleton.PlayerOneName.Value;
                opponentNameText.text = MatchExecutor.Singleton.PlayerTwoName.Value;
                break;
            case MatchExecutor.PlayerType.PlayerTwo:
                playerNameText.text = MatchExecutor.Singleton.PlayerTwoName.Value;
                opponentNameText.text = MatchExecutor.Singleton.PlayerOneName.Value;
                break;
            default:
                break;
        }
    }
}

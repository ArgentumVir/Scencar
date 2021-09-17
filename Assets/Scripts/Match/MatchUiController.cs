using System.Collections;
using System.Collections.Generic;
using MLAPI;
using TMPro;
using UnityEngine;
using PlayerDesignation = MatchExecutor.PlayerDesignation;

public class MatchUiController : ExtendedMonoBehaviour
{
    const string PLAYER_NAME_GAME_OBJECT = "PlayerName";
    TextMeshProUGUI playerNameText;
    const string OPPONENT_NAME_GAME_OBJECT = "OpponentName";
    private TextMeshProUGUI opponentNameText;
    void Awake()
    {
        playerNameText = FetchChildComponent<TextMeshProUGUI>(PLAYER_NAME_GAME_OBJECT);
        opponentNameText = FetchChildComponent<TextMeshProUGUI>(OPPONENT_NAME_GAME_OBJECT);
    }

    void OnEnable()
    {
        MatchExecutor.Singleton.PlayerOneName.OnValueChanged += HandlePlayerNameChange;
        MatchExecutor.Singleton.PlayerTwoName.OnValueChanged += HandlePlayerNameChange;
    }

    void OnDisable()
    {
        MatchExecutor.Singleton.PlayerOneName.OnValueChanged -= HandlePlayerNameChange;
        MatchExecutor.Singleton.PlayerTwoName.OnValueChanged -= HandlePlayerNameChange;
    }

    void HandlePlayerNameChange(string _oldValue, string _newValue)
    {
        switch (GetClientPlayerDesignation())
        {
            case PlayerDesignation.PlayerOne:
                playerNameText.text = MatchExecutor.Singleton.PlayerOneName.Value;
                opponentNameText.text = MatchExecutor.Singleton.PlayerTwoName.Value;
                break;
            case PlayerDesignation.PlayerTwo:
                playerNameText.text = MatchExecutor.Singleton.PlayerTwoName.Value;
                opponentNameText.text = MatchExecutor.Singleton.PlayerOneName.Value;
                break;
            case PlayerDesignation.Spectator:
                playerNameText.text = MatchExecutor.Singleton.PlayerOneName.Value;
                opponentNameText.text = MatchExecutor.Singleton.PlayerTwoName.Value;
                break;
            default:
                break;
        }
    }

    PlayerDesignation GetClientPlayerDesignation()
    {
        return MatchExecutor.Singleton.GetPlayerDesignation(NetworkManager.Singleton.LocalClientId);
    }
}

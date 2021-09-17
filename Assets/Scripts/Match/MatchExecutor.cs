using System.Collections;
using System.Collections.Generic;
using MLAPI;
using MLAPI.Messaging;
using MLAPI.NetworkVariable;
using MLAPI.NetworkVariable.Collections;
using UnityEngine;

public class MatchExecutor : ExtendedNetworkBehaviour
{
    const ulong NO_PLAYER_ASSIGNED = ulong.MaxValue;
    public NetworkVariableString PlayerOneName = new NetworkVariableString();
    public NetworkVariableString PlayerTwoName = new NetworkVariableString();
    public NetworkVariableULong PlayerOneClientId = new NetworkVariableULong();
    public NetworkVariableULong PlayerTwoClientId = new NetworkVariableULong();
    private Dictionary<ulong, ClientData> spectators = new Dictionary<ulong, ClientData>();
    private NetworkObject networkObject;
    public static MatchExecutor Singleton;
    
    void Awake()
    {
        Singleton = this;
        networkObject = FetchComponent<NetworkObject>();

        if (!IsServer) { return; }
        PlayerOneClientId.Value = NO_PLAYER_ASSIGNED;
        PlayerTwoClientId.Value = NO_PLAYER_ASSIGNED;
    }

    void Start()
    {
        if (IsHost)
        {
           HandlePlayerConnect(NetworkManager.Singleton.LocalClientId);
        }
    }

    public void HandlePlayerConnect(ulong clientId)
    {
        if (!IsServer) { return; }
        AddClientToMatch(clientId);
    }

    # region AddPlayerImpl

    private void AddClientToMatch(ulong clientId)
    {
        if (PlayerOneClientId.Value == NO_PLAYER_ASSIGNED)
        {
            SetClientAsPlayer(1, clientId);
            return;
        }

        if (PlayerTwoClientId.Value == NO_PLAYER_ASSIGNED)
        {
            SetClientAsPlayer(2, clientId);
            return;
        }

        if (PlayerOneClientId.Value != NO_PLAYER_ASSIGNED && PlayerTwoClientId.Value != NO_PLAYER_ASSIGNED)
        {
            SetPlayerAsSpectator(clientId);
        }
    }

    private void SetPlayerAsSpectator(ulong clientId)
    {
        spectators.Add(clientId, ClientDataManager.Get(clientId));
    }

    private void SetClientAsPlayer(int player, ulong clientId)
    {
        switch (player)
        {
            case 1:
                PlayerOneClientId.Value = clientId;

                PlayerOneName.Value = ClientDataManager.Get(clientId).PlayerName;
                break;
            case 2:
                PlayerTwoClientId.Value = clientId;

                PlayerTwoName.Value = ClientDataManager.Get(clientId).PlayerName;
                break;
            default:
                break;
        }
    }

    # endregion

    public void HandlePlayerDisconnect(ulong clientId)
    {
        if (!IsServer) { return; }
        RemoveClientFromMatch(clientId);
    }

    # region RemovePlayerImpl

    private void RemoveClientFromMatch(ulong clientId)
    {
        if (PlayerOneClientId.Value != NO_PLAYER_ASSIGNED && PlayerOneClientId.Value == clientId)
        {
            RemovePlayerFromMatch(1, clientId);
        }

        if (PlayerTwoClientId.Value != NO_PLAYER_ASSIGNED && PlayerTwoClientId.Value == clientId)
        {
            RemovePlayerFromMatch(2, clientId);
        }

        if (spectators.TryGetValue(clientId, out _))
        {
            spectators.Remove(clientId);
        }
    }

    private void RemovePlayerFromMatch(int player, ulong clientId)
    {
        switch (player)
        {
            case 1:
                PlayerOneClientId.Value = NO_PLAYER_ASSIGNED;
                PlayerOneName.Value = "";
                break;
            case 2:
                PlayerTwoClientId.Value = NO_PLAYER_ASSIGNED;
                PlayerTwoName.Value = "";
                break;
            default:
                break;
        }
    }

    # endregion

    public void LogUsers()
    {
        Debug.Log($"Player One Name:");
        Debug.Log($"Player One Id:");
        Debug.Log("---------------");
        Debug.Log($"Player Two Name:");
        Debug.Log($"Player Two Id:");
        Debug.Log("---------------");

        foreach(ClientData spectator in spectators.Values)
        {
            Debug.Log($"Spectator Id: {spectator.ClientId}");
            Debug.Log($"Spectator Name: {spectator.PlayerName}");
            Debug.Log("---------------");
        }
    }

    public enum PlayerDesignation
    {
        PlayerOne = 1,
        PlayerTwo = 2,
        Spectator = 3
    }

    public PlayerDesignation GetPlayerDesignation(ulong clientId)
    {
        if (PlayerOneClientId.Value == clientId)
        {
            return PlayerDesignation.PlayerOne;
        }

        if (PlayerTwoClientId.Value == clientId)
        {
            return PlayerDesignation.PlayerTwo;
        }

        return PlayerDesignation.Spectator;
    }
}

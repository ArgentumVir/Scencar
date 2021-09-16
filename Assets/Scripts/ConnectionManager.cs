using System.Text;
using MLAPI;
using MLAPI.Logging;
using MLAPI.SceneManagement;
using MLAPI.Transports.UNET;
using UnityEngine;

public static class ConnectionManager
{
    public static void Host(string ipAddress, string port, string playerName)
    {
        SetNetworkManagerIpAddressAndPort(ipAddress, port);

        ClientDataManager.Reset();
        ClientDataManager.Add(NetworkManager.Singleton.LocalClientId, playerName);

        NetworkManager.Singleton.ConnectionApprovalCallback += ApprovalCheck;
        NetworkManager.Singleton.OnClientDisconnectCallback += HandleClientDisconnect;

        Vector3 spawnPosition = Vector3.zero;
        Quaternion spawnRotation = Quaternion.identity;

        NetworkManager.Singleton.StartHost(spawnPosition, spawnRotation, true, null);

        NetworkSceneManager.SwitchScene("MatchScene");
    }
    public static void Join(string ipAddress, string port, string playerName)
    {
        SetNetworkManagerIpAddressAndPort(ipAddress, port);

        var connectionPayload = JsonUtility.ToJson(
            new ConnectionData()
            {
                playerName = playerName
            }
        );

        NetworkManager.Singleton.NetworkConfig.ConnectionData = Encoding
            .ASCII
            .GetBytes(connectionPayload);

        NetworkManager.Singleton.StartClient();
    }


    private static void ApprovalCheck(
        byte[] connectionData,
        ulong clientId,
        MLAPI.NetworkManager.ConnectionApprovedDelegate callback
    )
    {
        Debug.Log($"Client #{clientId.ToString()} is attempting to connect.");

        ConnectionData data = JsonUtility.FromJson<ConnectionData>(
            Encoding.ASCII.GetString(connectionData)
        );

        // TODO: Add lobby password
        bool isApproved = true;

        Vector3 spawnPosition = Vector3.zero;
        Quaternion spawnRotation = Quaternion.identity;

        // TODO: Change spawns based on player type?
        if (isApproved)
        {
            switch (NetworkManager.Singleton.ConnectedClients.Count)
            {
                case 1:
                    spawnPosition = Vector3.zero;
                    spawnRotation = Quaternion.identity;
                    break;
                default:
                    Debug.Log($"More than two players not currently not supported at this time.");
                    break;
            }

            ClientDataManager.Add(clientId, data.playerName);
        }

        callback(true, null, isApproved, spawnPosition, spawnRotation);
    }

    private static void HandleClientDisconnect(ulong clientId)
    {
        Debug.Log($"Client #{clientId.ToString()} has disconnected.");
        if (NetworkManager.Singleton.IsServer)
        {
            ClientDataManager.Remove(clientId);
        }
    }

    private static void SetNetworkManagerIpAddressAndPort(string ipAddress, string port)
    {
        NetworkManager.Singleton.GetComponent<UNetTransport>().ConnectAddress = ipAddress;
        NetworkManager.Singleton.GetComponent<UNetTransport>().ConnectPort = int.Parse(port);
        NetworkManager.Singleton.GetComponent<UNetTransport>().ServerListenPort = int.Parse(port);
    }
}
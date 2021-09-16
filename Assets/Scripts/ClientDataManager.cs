using System;
using System.Collections.Generic;

public static class ClientDataManager
{
    public static Dictionary<ulong, ClientData> clientData;

    public static void Reset()
    {
        clientData = new Dictionary<ulong, ClientData>();
    }

    public static void Add(ulong clientId, string name)
    {
        clientData.Add(
            clientId,
            new ClientData
            {
                PlayerName = name,
                ClientId = clientId
            }
        );
    }

    public static void Remove(ulong clientId)
    {
        clientData.Remove(clientId);
    }

    public static ClientData Get(ulong clientId)
    {
        return clientData[clientId];
    }
}
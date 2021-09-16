using System;
using System.Collections;
using System.Collections.Generic;
using MLAPI;
using MLAPI.NetworkVariable;
using UnityEngine;

public class ConnectedPlayerController : MonoBehaviour
{
    //private NetworkVariableString playerName = new NetworkVariableString();
    //private NetworkObject networkObject;

    void Awake()
    {
        DontDestroyOnLoad(this);
    }

    //     // networkObject = GetComponent<NetworkObject>();

    //     // if (networkObject == null)
    //     // {
    //     //     throw new NullReferenceException("Did not find component of type 'NetworkObject'.");
    //     // }
    // }

    // void Start()
    // {
    //     if (IsServer)
    //     {
    //         playerName.Value = GetOwnClientData().PlayerName;
    //     }
    // }

    // private ClientData GetOwnClientData()
    // {
    //     return ClientDataManager.Get(
    //         networkObject.OwnerClientId
    //     );
    // }

}

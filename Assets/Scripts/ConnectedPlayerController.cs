using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConnectedPlayerController : MonoBehaviour
{
    void Awake()
    {
        DontDestroyOnLoad(this);
    }
}

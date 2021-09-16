using UnityEngine;
using ExtensionMethods;
using MLAPI;

public class ExtendedNetworkBehaviour : NetworkBehaviour
{
    protected GameObject Fetch(string name)
    {
        return ExtendedBehaviourImpl.Fetch(name, transform);
    }

    protected T FetchComponent<T>()
    {
        return ExtendedBehaviourImpl.FetchComponent<T>(transform);
    }

    protected T FetchChildComponent<T>(string name)
    {
        return ExtendedBehaviourImpl.FetchChildComponent<T>(name, transform);
    }
}
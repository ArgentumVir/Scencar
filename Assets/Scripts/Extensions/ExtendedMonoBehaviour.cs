using UnityEngine;

public class ExtendedMonoBehaviour : MonoBehaviour
{
    protected GameObject Fetch(string name)
    {
        Transform child = transform.Find(name);

        if (child == null)
        {
            throw new ChildNotFoundException($"Child named '${name}' not found in children.");
        }

        return child.gameObject;
    }

    protected T FetchComponent<T>()
    {
        T component = transform.GetComponent<T>();

        if (component == null)
        {
            throw new ComponentNotFoundException($"Component of type '${typeof(T)}' not found.");
        }

        return component;
    }
}
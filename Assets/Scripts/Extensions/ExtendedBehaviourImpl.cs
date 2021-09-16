using ExtensionMethods;
using UnityEngine;

public static class ExtendedBehaviourImpl
{
    public static GameObject Fetch(string name, Transform transform)
    {
        Transform child = transform.Find(name);

        if (child == null)
        {
            throw new ChildNotFoundException($"Child named '${name}' not found in children.");
        }

        return child.gameObject;
    }

    public static T FetchChildComponent<T>(string name, Transform transform)
    {
        return Fetch(name, transform).FetchComponent<T>();
    }

    public static T FetchComponent<T>(Transform Transform)
    {
        T component = Transform.GetComponent<T>();

        if (component == null)
        {
            throw new ComponentNotFoundException($"Component of type '${typeof(T)}' not found.");
        }

        return component;
    }
}
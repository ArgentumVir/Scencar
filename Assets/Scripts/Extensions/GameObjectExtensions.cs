using UnityEngine;
namespace ExtensionMethods
{
    public static class GameObjectExtensions
    {
        public static T FetchComponentInChildren<T>(this GameObject gameObject)
        {
            T component = gameObject.GetComponentInChildren<T>();

            if (component == null)
            {
                throw new ComponentNotFoundException($"Component of type '${typeof(T)}' not found in children.");
            }

            return component;
        }

        public static T FetchComponent<T>(this GameObject gameObject)
        {
            T component = gameObject.GetComponent<T>();

            if (component == null)
            {
                throw new ComponentNotFoundException($"Component of type '${typeof(T)}' not found in children.");
            }

            return component;
        }
    }
}
using UnityEngine;
namespace ExtensionMethods
{
    public static class Extensions
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
    }
}
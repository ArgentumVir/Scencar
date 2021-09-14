using System;

[Serializable]
public class ComponentNotFoundException : Exception
{
    public ComponentNotFoundException() : base() { }
    public ComponentNotFoundException(string message) : base(message) { }
    public ComponentNotFoundException(string message, Exception inner) : base(message, inner) { }
    protected ComponentNotFoundException(System.Runtime.Serialization.SerializationInfo info,
        System.Runtime.Serialization.StreamingContext context) : base(info, context) { }
}
using System;

[Serializable]
public class ChildNotFoundException : Exception
{
    public ChildNotFoundException() : base() { }
    public ChildNotFoundException(string message) : base(message) { }
    public ChildNotFoundException(string message, Exception inner) : base(message, inner) { }
    protected ChildNotFoundException(System.Runtime.Serialization.SerializationInfo info,
        System.Runtime.Serialization.StreamingContext context) : base(info, context) { }
}
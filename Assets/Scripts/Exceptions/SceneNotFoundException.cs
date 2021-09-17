using System;

[Serializable]
public class SceneNotFoundException : Exception
{
    public SceneNotFoundException() : base() { }
    public SceneNotFoundException(string message) : base(message) { }
    public SceneNotFoundException(string message, Exception inner) : base(message, inner) { }
    protected SceneNotFoundException(System.Runtime.Serialization.SerializationInfo info,
        System.Runtime.Serialization.StreamingContext context) : base(info, context) { }
}
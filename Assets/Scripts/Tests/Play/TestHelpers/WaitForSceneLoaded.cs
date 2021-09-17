using NUnit.Framework;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WaitForSceneLoaded : CustomYieldInstruction
{
    string sceneName;
    float timeout;
    float startTime;
    bool timedOut;

    public bool TimedOut => timedOut;

    public override bool keepWaiting {
        get {
            Scene scene = SceneManager.GetSceneByName(sceneName);
            bool sceneLoaded = scene.IsValid() && scene.isLoaded;

            if (Time.realtimeSinceStartup - startTime >= timeout) {
                timedOut = true;
            }

            Assert.IsFalse(timedOut, $"Scene '{sceneName}' timed out (#{timeout} seconds)");

            return !sceneLoaded && !timedOut;
        }
    }

    public WaitForSceneLoaded(string newSceneName, float newTimeout = 10)
    {
        sceneName = newSceneName;
        timeout = newTimeout;
        startTime = Time.realtimeSinceStartup;
    }
}
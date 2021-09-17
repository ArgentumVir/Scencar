using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuController : MonoBehaviour
{
    public void HandlePlayClick()
    {
        Utilities.Scene.SafeLoad("PregameScene");
    }

    public void HandleSettingsClick()
    {
        Utilities.Scene.SafeLoad("SettingsScene");
    }

    public void HandleDevClick()
    {
    }

    public void HandleQuitClick()
    {
        Application.Quit();
    }
}

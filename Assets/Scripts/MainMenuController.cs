using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuController : MonoBehaviour
{
    public void HandlePlayClick()
    {
        SceneManager.LoadScene("PregameScene");
    }

    public void HandleSettingsClick()
    {
        SceneManager.LoadScene("SettingsScene");
    }

    public void HandleDevClick()
    {
    }

    public void HandleQuitClick()
    {
        Application.Quit();
    }
}

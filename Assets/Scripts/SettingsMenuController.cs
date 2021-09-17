using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SettingsMenuController : MonoBehaviour
{
    public void HandleBackClick()
    {
        Utilities.Scene.SafeLoad("MainMenuScene");
    }
}

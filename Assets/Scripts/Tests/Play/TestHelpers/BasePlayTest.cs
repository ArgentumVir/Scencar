using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.TestTools;
using NUnit.Framework;
using UnityEngine.EventSystems;
 using UnityEngine.UI;
public class BasePlayTest
{
    private bool hasSceneLoaded = false;
    protected IEnumerator StartAtMainMenu()
    {
        SceneManager.LoadScene("MainMenuScene");
        yield return new WaitForSceneLoaded("MainMenuScene", .5f);
    }

    protected static void ClickButton(string buttonName)
    {
        GameObject button = GameObject.Find(buttonName);

        if (button == null)
        {
            throw new ComponentNotFoundException();
        }

        EventSystem.current.SetSelectedGameObject(button);

        button.GetComponent<Button>().onClick.Invoke();
    }
}
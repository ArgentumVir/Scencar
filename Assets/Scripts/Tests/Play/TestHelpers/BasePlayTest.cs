using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.TestTools;
using NUnit.Framework;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using TMPro;
using MLAPI;

public class BasePlayTest
{
    protected IEnumerator StartAtMainMenu()
    {
        SceneManager.LoadScene("MainMenuScene");
        yield return new WaitForSceneLoaded("MainMenuScene", .5f);
    }

    protected static void SetTextInput(string inputName, string text, bool verify = true)
    {
        GetGameObjectComponent<TMP_InputField>(inputName).text = text;
    }


    protected static GameObject GetGameObject(string name)
    {
        GameObject obj = GameObject.Find(name);

        if (obj == null)
        {
            throw new ComponentNotFoundException($"GameObject with name '{name}' not found.");
        }

        return obj;
    }

    
    protected static T GetGameObjectComponent<T>(string name)
    {
        GameObject obj = GetGameObject(name);

        T objComponent = obj.GetComponent<T>();
        
        if (objComponent == null)
        {
            throw new ComponentNotFoundException($"Component of type '{typeof(T)}' not found.");
        }

        return objComponent;
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
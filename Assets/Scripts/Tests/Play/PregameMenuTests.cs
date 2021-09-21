using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.TestTools;
using TMPro;

public class PregameMenuTests : BasePlayTest
{
    [UnityTest]
    public IEnumerator UserCanGetToPregameMenu()
    {
        yield return StartAtMainMenu();
        ClickButton("PlayButton");
        yield return new WaitForSceneLoaded("PregameScene", .5f);
    }

    [UnityTest]
    public IEnumerator UserCanSetNameAndHostGame()
    {
        yield return UserCanGetToPregameMenu();

        string playerName = "SomeGuyName";
        SetTextInput("PlayerNameInput", playerName);
        ClickButton("HostButton");
        yield return new WaitForSceneLoaded("MatchScene", .5f);

        string actualPlayerName = GetGameObjectComponent<TextMeshProUGUI>("PlayerName").text;

        Assert.AreEqual(playerName, actualPlayerName);

        string actualOpponentName = GetGameObjectComponent<TextMeshProUGUI>("OpponentName").text;
        Assert.AreEqual("", actualOpponentName);
    }
}

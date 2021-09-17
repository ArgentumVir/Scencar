using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.TestTools;

public class PregameMenuTests : BasePlayTest
{
    [UnityTest]
    public IEnumerator UserCanGetToPregameMenu()
    {
        yield return StartAtMainMenu();
        ClickButton("PlayButton");
        yield return new WaitForSceneLoaded("PregameScene", .5f);
    }
}

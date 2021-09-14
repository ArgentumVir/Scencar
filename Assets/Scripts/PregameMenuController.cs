using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using ExtensionMethods;

public class PregameMenuController : ExtendedMonoBehaviour
{
    const string SELECTED_DECK_NAME_GAME_OBJECT = "SelectedDeckName";

    private string deckName;
    private Object deck; // Not implemented
    private TextMeshProUGUI selectedDeckNameTextMesh;

    public void Start()
    {
        TextMeshProUGUI selectedDeckNameTextMesh = Fetch(SELECTED_DECK_NAME_GAME_OBJECT)
           .FetchComponentInChildren<TextMeshProUGUI>();

        deckName = (deck == null)
            ? "DevDefault"
            : "<PLACE HOLDER FOR SELECTED DECK NAME>" ;

        selectedDeckNameTextMesh.text = deckName;
    }

    public void HandleHostClick()
    {
    }

    public void HandleJoinClick()
    {
    }

    public void HandleSelectDeckClick()
    {
        SceneManager.LoadScene("DeckSelectScene");
    }

    public void HandleBackClick()
    {
        SceneManager.LoadScene("MainMenuScene");
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using MLAPI;
using MLAPI.Transports.UNET;
using MLAPI.Messaging;
using MLAPI.SceneManagement;

public class PregameMenuController : ExtendedMonoBehaviour
{
    const string SELECTED_DECK_NAME_GAME_OBJECT = "SelectedDeckName";
    private TextMeshProUGUI selectedDeckNameText;
    const string SELECTED_IP_ADDRESS_INPUT_GAME_OBJECT = "IpAddressInput";
    private TextMeshProUGUI ipAddressInput;
    const string SELECTED_PORT_INPUT_GAME_OBJECT = "PortInput";
    private TextMeshProUGUI portInput;
    const string PLAYER_NAME_INPUT_GAME_OBJECT = "PlayerNameInput";
    private TextMeshProUGUI playerNameInput;
    const string DEFAULT_IP_ADDRESS = "127.0.0.1";
    const string DEFAULT_PORT = "7777";
    const string DEFAULT_PLAYER_NAME = "LazyBastard";
    const string DEFAULT_DECK_NAME = "DevDefault";

    private Object deck; // Not implemented

    private string ipAddress;
    private string port;
    private string playerName;
    private string deckName;

    public void Start()
    {
        NetworkManager.Singleton.DontDestroy = true;
        NetworkManager.Singleton.NetworkConfig.EnableSceneManagement = true;
        ipAddress = DEFAULT_IP_ADDRESS;
        port = DEFAULT_PORT;
        playerName = DEFAULT_PLAYER_NAME;
        deckName = DEFAULT_DECK_NAME;

        var selectedDeckNameText = FetchChildComponent<TextMeshProUGUI>(SELECTED_DECK_NAME_GAME_OBJECT);
        var ipAddressInput = FetchChildComponent<TMP_InputField>(SELECTED_IP_ADDRESS_INPUT_GAME_OBJECT);
        var portInput = FetchChildComponent<TMP_InputField>(SELECTED_PORT_INPUT_GAME_OBJECT);
        var playerNameInput = FetchChildComponent<TMP_InputField>(PLAYER_NAME_INPUT_GAME_OBJECT);

        ipAddressInput.onValueChanged.AddListener(HandleIpAddressChange);
        portInput.onValueChanged.AddListener(HandlePortChange);
        playerNameInput.onValueChanged.AddListener(HandlePlayerNameChange);

        selectedDeckNameText.text = deckName;
    }

    public void HandleHostClick()
    {
        SetNetworkManagerIpAddressAndPort(ipAddress, port);
        NetworkManager.Singleton.StartHost();

        // SceneManager.LoadScene("MatchScene");
        NetworkSceneManager.SwitchScene("MatchScene");
    }

    public void HandleJoinClick()
    {
        SetNetworkManagerIpAddressAndPort(ipAddress, port);
        NetworkManager.Singleton.StartClient();

        // NetworkSceneManager.SwitchScene("MatchScene");
        // SceneManager.LoadScene("MatchScene");
    }

    public void HandleSelectDeckClick()
    {
        SceneManager.LoadScene("DeckSelectScene");
    }

    public void HandleBackClick()
    {
        SceneManager.LoadScene("MainMenuScene");
    }

    public void HandleIpAddressChange(string text)
    {
        ipAddress = text;
    }

    public void HandlePortChange(string text)
    {
        port = text;
    }

    public void HandlePlayerNameChange(string text)
    {
        playerName = (text.Length > 256) ? text.Substring(0, 255) : text;
    }

    private static void SetNetworkManagerIpAddressAndPort(string ipAddress, string port)
    {
        NetworkManager.Singleton.GetComponent<UNetTransport>().ConnectAddress = ipAddress;
        NetworkManager.Singleton.GetComponent<UNetTransport>().ConnectPort = int.Parse(port);
        NetworkManager.Singleton.GetComponent<UNetTransport>().ServerListenPort = int.Parse(port);
    }
}

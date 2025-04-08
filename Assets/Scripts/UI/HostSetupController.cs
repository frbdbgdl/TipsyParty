using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;
using Mirror;

public class HostSetupController : MonoBehaviour
{
    public TMP_Dropdown playersDropdown;
    public TMP_Dropdown roundsDropdown;
    public Toggle drinkRuleToggle;
    public Toggle lobbyVisibilityToggle;


    public void OnCreateLobbyClicked(){
        Debug.Log("Creating Lobby...");
        GameManager.Instance.totalRounds = int.Parse(roundsDropdown.options[roundsDropdown.value].text);

        NetworkManager.singleton.StartHost();

        SteamLobbyManager.Instance.CreateSteamLobby();

        SceneManager.LoadScene("LobbyScene");
    }

    public void OnBackButtonClicked(){
        SceneManager.LoadScene("MainMenuScene");
    }
}

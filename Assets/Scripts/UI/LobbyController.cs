using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Mirror;
using TMPro;
using UnityEngine.SceneManagement;


public class LobbyController : Singleton<LobbyController>{

    [Header("UI Elements")]
    public GameObject playerSlotPrefab;
    public Transform playerSlotListContainer;
    public GameObject startGameButton;
    public GameObject inviteFriendsButton;
    public TextMeshProUGUI lobbyTitle;

    private Dictionary<NetworkPlayer, PlayerSlotUI> playerSlots = new();


    public void Start()
    {
        UpdateLobbyTitle();
        RefreshPlayerList();

        bool isHost = NetworkServer.active;
        startGameButton.SetActive(isHost);
        inviteFriendsButton.SetActive(isHost);
    }

    public void OnLeaveLobbyClicked(){
        SceneManager.LoadScene("MainMenuScene");
    }

    private void UpdateLobbyTitle(){
        foreach(var conn in NetworkServer.connections){
            if(conn.Value.identity != null){
                var player = conn.Value.identity.GetComponent<NetworkPlayer>();
                if(player.isHost){
                    lobbyTitle.text = $"{player.playerName}'s Lobby";
                    return;
                }
            }
        }

        lobbyTitle.text = "Lobby";
    }

    private void RefreshPlayerList(){
        foreach(Transform child in playerSlotListContainer){
            Destroy(child.gameObject);
        }

        playerSlots.Clear();

        foreach(var conn in NetworkServer.connections){
            if(conn.Value.identity == null) continue;

            NetworkPlayer player = conn.Value.identity.GetComponent<NetworkPlayer>();
            CreateOrUpdatePlayerSlot(player);
        }
    }

    public void CreateOrUpdatePlayerSlot(NetworkPlayer player){

        if(playerSlots.TryGetValue(player, out PlayerSlotUI slotUI)){
            ApplyDataToSlot(player, slotUI);
        }else{
            GameObject slotGO = Instantiate(playerSlotPrefab, playerSlotListContainer);
            slotUI = slotGO.GetComponent<PlayerSlotUI>();
            playerSlots[player] = slotUI;
            ApplyDataToSlot(player, slotUI);
        }
    }

    private void ApplyDataToSlot(NetworkPlayer player, PlayerSlotUI ui){
        Theme theme = ThemeManager.CurrentTheme;
        Color playerColor = theme.PlayerColors[player.slotIndex % theme.PlayerColors.Length];

        string statusText = player.isHost ? "Host" : (player.isReady ? "Ready" : "Nicht Ready");
        Color statusColor = player.isHost ? theme.HostTextColor : (player.isReady ? theme.ReadyTextColor : theme.NotReadyTextColor);

        ui.SetPlayerData(player.playerName, playerColor, statusText, statusColor);
    }


    public void UpdatePlayerSlot(NetworkPlayer player)
    {
        if(playerSlots.ContainsKey(player)){
            ApplyDataToSlot(player, playerSlots[player]);
        }
    }

}
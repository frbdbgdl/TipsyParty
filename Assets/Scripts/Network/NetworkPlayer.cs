using UnityEngine;
using Mirror;
using Steamworks;

public class NetworkPlayer : NetworkBehaviour{

    [SyncVar(hook = nameof(OnNameChanged))]
    public string playerName;

    [SyncVar(hook = nameof(OnSlotIndexChanged))]
    public int slotIndex;

    [SyncVar(hook = nameof(OnReadyStatusChanged))]
    public bool isReady;
    
    [SyncVar]
    public bool isHost;


    public override void OnStartLocalPlayer()
    {
        if(SteamManager.Initialized){
            string steamName = SteamFriends.GetPersonaName();
            CmdSetPlayerName(steamName);
            Debug.Log("✅ Steamname gesetzt: " + steamName);
        }
    }


    [Command]
    void CmdSetPlayerName(string name){
        playerName = name;
    }

    private void OnNameChanged(string _, string __){
        LobbyController.Instance.UpdatePlayerSlot(this);
    }

    private void OnSlotIndexChanged(int _, int __){
        LobbyController.Instance.UpdatePlayerSlot(this);
    }

    private void OnReadyStatusChanged(bool _, bool __){
        LobbyController.Instance.UpdatePlayerSlot(this);
    }

}



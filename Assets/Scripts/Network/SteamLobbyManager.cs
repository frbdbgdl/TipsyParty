using UnityEngine;
using Steamworks;
using Mirror;


public class SteamLobbyManager : Singleton<SteamLobbyManager>
{
    protected Callback<LobbyCreated_t> lobbyCreatedCallback;

    public void CreateSteamLobby()
    {
        if(!SteamManager.Initialized)
        {
            Debug.LogError("❌ Steam not initialized");
            return;
        }

        lobbyCreatedCallback = Callback<LobbyCreated_t>.Create(OnLobbyCreated);
        SteamMatchmaking.CreateLobby(ELobbyType.k_ELobbyTypeFriendsOnly, 4);
        Debug.Log("Creating Steam Lobby...");
    }

    private void OnLobbyCreated(LobbyCreated_t callback)
    {
        if(callback.m_eResult != EResult.k_EResultOK){
            Debug.LogError("❌ Failed to create lobby: " + callback.m_eResult);
            return;
        }

        Debug.Log("✅ Lobby created successfully: " + callback.m_ulSteamIDLobby);
    }
}
using UnityEngine;
using Mirror;


public class TipsyPartyNetworkManager : NetworkManager
{
    public override void OnServerAddPlayer(NetworkConnectionToClient conn)
    {
        base.OnServerAddPlayer(conn);

        NetworkPlayer player = conn.identity.GetComponent<NetworkPlayer>();

        Debug.Log("NumPlayer: " + numPlayers);

        if(numPlayers == 1){
            Debug.Log("Setting Host..");
            player.isHost = true;
        }

        if (player != null && LobbyController.Instance != null)
        {
            LobbyController.Instance.CreateOrUpdatePlayerSlot(player);
        }
    }
}
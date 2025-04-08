using UnityEngine;
using Steamworks;

public class SteamTest : MonoBehaviour
{
    private void Start()
    {
        if (SteamManager.Initialized)
        {
            Debug.Log("✅ Steamworks initialized: " + SteamFriends.GetPersonaName());
        }
        else
        {
            Debug.LogError("❌ Steam not initialized");
        }
    }
}
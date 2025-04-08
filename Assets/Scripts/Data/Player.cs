using UnityEngine;

[System.Serializable]
public class Player
{
    public string name;
    public Color color;
    public int points = 0;
    public bool isLocalPlayer = false;
    public bool isHost = false;
    public bool isReady = false;
    public int givenSips = 0;
    public int takenSips = 0;

    public Player(string name, Color color, bool isHost, bool isReady, bool isLocalPlayer)
    {
        this.name = name;
        this.color = color;
        this.isHost = isHost;
        this.isReady = isReady;
        this.isLocalPlayer = isLocalPlayer;
    }
}

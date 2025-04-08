using UnityEngine;
using System.Collections.Generic;

[System.Serializable]
public class GameData
{
  public int currentRound = 1;
  public string joinCode;
  public List<Player> players = new List<Player>();
  public string currentMinigameId = "";
  public List<Minigame> minigames = new List<Minigame>();
}

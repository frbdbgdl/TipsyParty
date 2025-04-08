using System.Collections.Generic;
using System.Data.Common;
using UnityEngine;

public class GameManager : Singleton<GameManager>
{
    public int totalRounds = 5;
    public bool drinkingRuleActive = true;
    public GameData gameData = new GameData();
    public string PlayerName {get; private set;}

    protected override void Awake()
    {
        base.Awake();
        LoadPlayerData();
    }

    void Start()
    {
        if(gameData.minigames.Count == 0){
            gameData.minigames = new List<Minigame>{
                new Minigame { id = "relfex_royal", name = "Reflex Royal", description = "A fast-paced reflex game where players must tap the screen as quickly as possible.", sceneName = "ReflexRoyalScene" }, 
                new Minigame { id = "reaction_chain", name = "Reaction Chain", description = "A game where players must react to a series of prompts in quick succession.", sceneName = "ReactionChainScene" },
                new Minigame { id = "sound_simon", name = "Sound Simon", description = "A memory game where players must repeat a sequence of sounds.", sceneName = "SoundSimonScene" }
            };
        }
    }

    void LoadPlayerData(){
        PlayerName = PlayerPrefs.GetString("PlayerName", "UnknownPlayer");
    }

    public void SetCurrentMinigame(string id)
    {
        gameData.currentMinigameId = id;
    }

    public void ResetGame(){
        gameData.currentRound = 1;
        foreach(Player player in gameData.players){
            player.points = 0;
        }
    }

    public Minigame GetMinigameById(string id){
        return gameData.minigames.Find(x => x.id == id);
    }
}

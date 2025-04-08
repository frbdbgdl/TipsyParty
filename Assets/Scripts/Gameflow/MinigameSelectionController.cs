using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class MinigameSelectionController : MonoBehaviour
{

    public GameObject minigameEntryPrefab;
    public Transform listContainer;

   public float highlightDelay = 0.1f;
   public int cycles = 20;

   public Color normalColor = Color.white;
   public Color highlightColor = Color.yellow;

    private List<TextMeshProUGUI> minigameEntries = new List<TextMeshProUGUI>();
   private int selectedIndex = -1;


    void Start(){
        foreach(Minigame game in GameManager.Instance.gameData.minigames){
            GameObject entry = Instantiate(minigameEntryPrefab, listContainer);
            entry.GetComponent<TextMeshProUGUI>().text = game.name;
            minigameEntries.Add(entry.GetComponent<TextMeshProUGUI>());
        }
        StartCoroutine(SelectRandomMinigame());
    } 

    IEnumerator SelectRandomMinigame(){
        int currentIndex = 0;
        for(int i = 0; i < cycles; i++){
            foreach(var entry in minigameEntries)
                entry.color = normalColor;

            minigameEntries[currentIndex].color = highlightColor;

            yield return new WaitForSeconds(highlightDelay);
            currentIndex = (currentIndex + 1) % minigameEntries.Count;
        }

        selectedIndex = Random.Range(0, minigameEntries.Count);

        foreach(var entry in minigameEntries)
            entry.color = normalColor;

        minigameEntries[selectedIndex].color = highlightColor;

        string name = minigameEntries[selectedIndex].text;
        Minigame game = GameManager.Instance.gameData.minigames.Find(g => g.name == name);
        if(game != null){
            GameManager.Instance.SetCurrentMinigame(game.id);
            yield return new WaitForSeconds(1.5f);
            SceneManager.LoadScene("MinigameIntroScene");
        }
    }
}

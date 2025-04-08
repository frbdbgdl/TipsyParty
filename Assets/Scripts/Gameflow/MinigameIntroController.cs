using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
public class MinigameIntroController : MonoBehaviour
{
    public TextMeshProUGUI minigameName;
    public TextMeshProUGUI minigameDescription;
    public TextMeshProUGUI drinkingRuleText;

    void Start()
    {
        Minigame game = GameManager.Instance.GetMinigameById(GameManager.Instance.gameData.currentMinigameId);
        minigameName.text = name;
        
        if(game == null){
            minigameName.text = "Minigame not found!";
            minigameDescription.text = "Minigame not found!";
            Debug.LogError("Minigame not found!");
            return;
        }else{
            minigameName.text = game.name;
            minigameDescription.text = game.description;
        }

        drinkingRuleText.text = GameManager.Instance.drinkingRuleActive ? "Erster verteilt 1 und Letzter trink 2" : "Trinkregel deaktiviert";
    }

    public void OnStartMinigameClicked(){
        Minigame game = GameManager.Instance.GetMinigameById(GameManager.Instance.gameData.currentMinigameId);
        if(game != null){
            SceneManager.LoadScene(game.sceneName);
        }
    }
}

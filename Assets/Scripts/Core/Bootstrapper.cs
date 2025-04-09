using UnityEngine;
using UnityEngine.SceneManagement;

public class Bootstrapper : MonoBehaviour
{
    [SerializeField] private string nextScene = "MainMenuScene";

    private void Awake()
    {
        DontDestroyOnLoad(this.gameObject);
        if(FindFirstObjectByType<ThemeManager>() == null){
            GameObject themeManager = Resources.Load<GameObject>("ThemeManager");
            Instantiate(themeManager);
        }

        SceneManager.LoadSceneAsync(nextScene);
    }
}

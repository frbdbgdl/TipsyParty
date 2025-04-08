using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;
using System.Threading.Tasks;


public class MainMenuController : MonoBehaviour
{
    public void OnCreateGameClicked()
    {
        SceneManager.LoadScene("HostSetupScene");
    }

    public void OnJoinGameClicked()
    {
        SceneManager.LoadScene("JoinGameScene");
    }

    public void OnSettingsClicked()
    {
        SceneManager.LoadScene("SettingsScene");
    }

    public void OnQuitGameClicked()
    {
        #if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
        #else
            Application.Quit();
        #endif
    }
}

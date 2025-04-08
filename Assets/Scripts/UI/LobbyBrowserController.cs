using System.Threading.Tasks;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// Ermöglicht das Beitreten einer privaten Lobby über Join-Code.
/// </summary>
public class LobbyBrowserController : MonoBehaviour
{
    [Header("UI Elements")]
    public TMP_InputField joinCodeInputField;

    /// <summary>
    /// Zurück zum Hauptmenü.
    /// </summary>
    public void OnBackButtonClicked(){
        SceneManager.LoadScene("MainMenuScene");
    }



}

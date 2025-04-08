using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class PlayerSlotUI : MonoBehaviour
{
    [Header("UI Elements")]
    public TextMeshProUGUI playerName;
    public Image playerAvatar;
    public TextMeshProUGUI playerStatus;
    public Button kickButton;


    public void SetPlayerData(string name, Color playerColor, string status, Color statusColor){
        playerName.text = name;
        playerAvatar.color = playerColor;
        playerStatus.text = status;
        playerStatus.color = statusColor;
    }



}

using UnityEngine;
using UnityEngine.EventSystems;

public class UIButtonSoundHandler : MonoBehaviour, IPointerEnterHandler, IPointerClickHandler
{
    public void OnPointerEnter(PointerEventData eventData)
    {
        AudioManager.Instance?.PlayHoverSound();
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        AudioManager.Instance?.PlayClickSound();
    }
}
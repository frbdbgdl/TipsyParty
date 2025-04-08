using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using TMPro;

[RequireComponent(typeof(TextMeshProUGUI))]
public class UITextButtonStyleApplier : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerClickHandler
{
    
    private TextMeshProUGUI tmpText;

    [Header("Use Overrides")]
    public bool useOverrides = false;

    [Header("Text Styling")]
    public Color overrideNormalColor = Color.white;
    public Color overrideHoverColor = new Color32(233, 200, 120, 255); // #E9C878
    public float overrideFontSize = 40f;

    [HideInInspector] public Color normalColor;
    [HideInInspector] public Color hoverColor;
    [HideInInspector] public float fontSize;

    [Header("Events")]
    public UnityEngine.Events.UnityEvent onClickEvent;


    void Start()
    {
        ApplyTheme();
    }

    public void ApplyTheme()
    {
        tmpText = GetComponent<TextMeshProUGUI>();

        if (useOverrides)
        {
            normalColor = overrideNormalColor;
            hoverColor = overrideHoverColor;
            fontSize = overrideFontSize;
        }
        else if(ThemeManager.CurrentTheme != null)
        {
            Theme theme = ThemeManager.CurrentTheme;
            if (theme != null)
            {
                normalColor = theme.TextColorDefault;
                hoverColor = theme.HoverTextColor;
                fontSize = theme.TextSizeDefault;
            }
        }

        tmpText.color = normalColor;
        tmpText.fontSize = fontSize;
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        tmpText.color = hoverColor;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        tmpText.color = normalColor;
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        onClickEvent?.Invoke();
    }
}

using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class ThemeableButton : MonoBehaviour, IThemeable
{
    [SerializeField] Image buttonImage;
    [SerializeField] TextMeshProUGUI buttonText;
    
    public void ApplyTheme(Theme theme)
    {
        if(theme == null) return;
        if(buttonImage != null)
            buttonImage.color = theme.ButtonBackgroundColor;

        if(buttonText != null)
        {
            buttonText.color = theme.TextColorDefault;
            buttonText.fontSize = theme.TextSizeDefault;
            buttonText.font = theme.DefaultFontTMP;
        }
        
    }

    void OnEnable()
    {
        ThemeManager.Instance.RegisterThemable(this);       
        Debug.Log("ThemeableButton registered with ThemeManager."); 
    }

    void OnDisable(){
        ThemeManager.Instance.UnregisterThemable(this);
        Debug.Log("ThemeableButton unregistered from ThemeManager.");
    }
}

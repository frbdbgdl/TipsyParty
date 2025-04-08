using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Image))]
public class UIBackgroundApplier : MonoBehaviour
{
    private Image imageComponent;

    [Header("Use Overrides")]
    public bool useOverrides = false;

    [Header("Background Color")]
    public Color overrideBackgroundColor = new Color32(99, 178, 235, 255); // #63B2EB

    [HideInInspector] public Color backgroundColor;

    void Start()
    {
        ApplyTheme();
    }

    public void ApplyTheme()
    {
        imageComponent = GetComponent<Image>();

        if (useOverrides)
        {
            backgroundColor = overrideBackgroundColor;
        }
        else if (ThemeManager.CurrentTheme != null)
        {
            Theme theme = ThemeManager.CurrentTheme;
            if (theme != null)
            {
                backgroundColor = theme.BackgroundColor;
            }
        }

        imageComponent.color = backgroundColor;
    }
}
using System.Collections.Generic;
using UnityEngine;

public class ThemeManager : Singleton<ThemeManager>
{
    public static Theme CurrentTheme {get; private set;}

    [SerializeField] Theme theme;
    [SerializeField] Theme fallbackTheme;
    [SerializeField] Theme[] themes;

    private readonly List<IThemeable> themeables = new();

    public static event System.Action<Theme> OnThemeChanged;

    protected override void Awake()
    {
        base.Awake();
        Debug.Log("ThemeManager Awake called.");
        if(theme != null){
            CurrentTheme = theme;
        }else{
            CurrentTheme = fallbackTheme;
            Debug.LogError("No theme assigned to ThemeManager! Falling back to default theme.");
        }
           
    }

    public void SetCurrentTheme(Theme theme)
    {
        if(theme != null){
            CurrentTheme = theme;
            ApplyThemeToAll();
            OnThemeChanged?.Invoke(CurrentTheme);
            Debug.Log($"Theme switched to: {CurrentTheme.ThemeName}");
        }
    }

    public void RegisterThemable(IThemeable themeable)
    {
        Debug.Log("Registering themeable: " + themeable.GetType().Name);
        if(themeable != null && !themeables.Contains(themeable)){
            themeables.Add(themeable);
            themeable.ApplyTheme(CurrentTheme);
            Debug.Log("Themeable registered: " + themeable.GetType().Name);
        }   
    }

    public void UnregisterThemable(IThemeable themeable)
    {
        if(themeable != null && themeables.Contains(themeable)){
            themeables.Remove(themeable);
        }   
    }

    public void ApplyThemeToAll(){
        if(CurrentTheme == null) return;
        foreach(var themeable in themeables){
            themeable.ApplyTheme(CurrentTheme);
        }
    }
}

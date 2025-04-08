using UnityEngine;
using UnityEditor;
using TMPro;

public class ApplyThemeToUITextButtons{

    [MenuItem("Tools/Theme/Apply Theme to All Text Buttons in Scene")]
    public static void ApplyTheme(){
        Theme theme = ThemeManager.CurrentTheme;

        if(theme == null){
            Debug.LogError("ThemeManager.CurrentTheme is null. Please assign a theme in the ThemeManager.");
            return;
        }

        var appliers = Object.FindObjectsByType<UITextButtonStyleApplier>(FindObjectsSortMode.None);

        int count = 0;
        foreach(var applier in appliers){

            TextMeshProUGUI tmpText = applier.GetComponent<TextMeshProUGUI>();
            if(tmpText == null) continue;

            Undo.RecordObject(tmpText, "Apply Theme to Text Button");
            Undo.RecordObject(applier, "Apply Theme to Text Button");

            applier.ApplyTheme();

            EditorUtility.SetDirty(tmpText);
            EditorUtility.SetDirty(applier);

            count++;
        }

        Debug.Log($"Applied theme to {count} Text Buttons in the scene.");
    }
}

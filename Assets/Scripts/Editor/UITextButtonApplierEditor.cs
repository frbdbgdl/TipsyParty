#if UNITY_EDITOR

using UnityEditor;
using UnityEngine;
using TMPro;

[CustomEditor(typeof(UITextButtonStyleApplier))]
public class UITextButtonStyleApplierEditor : Editor{
    public override void OnInspectorGUI()
    {
        DrawDefaultInspector();

        EditorGUILayout.Space();
        EditorGUILayout.LabelField("Apply Theme", EditorStyles.boldLabel);

        if (GUILayout.Button("Apply Theme"))
        {
            UITextButtonStyleApplier applier = (UITextButtonStyleApplier)target;
            applier.ApplyTheme();

            EditorUtility.SetDirty(applier);
            TextMeshProUGUI tmpText = applier.GetComponent<TextMeshProUGUI>();
            if (tmpText != null)
            {
                EditorUtility.SetDirty(tmpText);
            }
        }
    }
}

#endif
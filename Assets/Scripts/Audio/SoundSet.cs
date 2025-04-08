using UnityEngine;

[CreateAssetMenu(fileName = "SoundSet", menuName = "TipsyParty/SoundSet")]
public class SoundSet : ScriptableObject
{
    [Header("UI Sounds")]
    public AudioClip clickSound;
    public AudioClip hoverSound;

    [Header("Background Music")]
    public AudioClip backgroundMusic;
}

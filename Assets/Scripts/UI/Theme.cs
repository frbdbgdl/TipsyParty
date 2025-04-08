using UnityEngine;
using TMPro;

[CreateAssetMenu(fileName = "NewTheme", menuName = "TipsyParty/UITheme")]
public class Theme : ScriptableObject
{    
    
    [Header("General")]
    [SerializeField] string themeID;
    [SerializeField] string themeName;
    [SerializeField][TextArea] string description;
    [SerializeField] string themeVersion;
    [SerializeField] Texture2D themeIcon;

    [Header("Farben")]
    [SerializeField] Color primaryColor;
    [SerializeField] Color secondaryColor;
    [SerializeField] Color backgroundColor;
    [SerializeField] Color textColorDefault;
    [SerializeField] Color hoverTextColor;
    [SerializeField] Color textColorBlack;
    [SerializeField] Color textColorWhite;
    [SerializeField] Color textColorError;
    [SerializeField] Color textColorSuccess;
    [SerializeField] Color hostTextColor;
    [SerializeField] Color readyTextColor;
    [SerializeField] Color notReadyTextColor;
    [SerializeField] Color[] playerColors;

    [Header("Spacing")]
    [SerializeField] float paddingCanvas;
    [SerializeField] float listSpacing;

    [Header("Typography")]
    [SerializeField] Font defaultFont;
    [SerializeField] TMP_FontAsset defaultFontTMP;
    [SerializeField] Font titleFont;
    [SerializeField] int textSizeDefault;
    [SerializeField] int textSizeTitle;

    [Header("🔊 Audio")]
    [SerializeField] AudioClip buttonClickSound;
    [SerializeField] AudioClip buttonHoverSound;
    [SerializeField] AudioClip lobbyJoinSound;
    [SerializeField] AudioClip lobbyLeaveSound;
    [SerializeField] AudioClip themeMusic;


    // ----------------------------------------------------
    // ---------------------- GETTER ----------------------
    // ----------------------------------------------------

    // ───────────────────── General ─────────────────────
    public string ThemeID => themeID;
    public string ThemeName => themeName;
    public string Description => description;
    public string ThemeVersion => themeVersion;
    public Texture2D ThemeIcon => themeIcon;

    // ───────────────────── Farben ─────────────────────
    public Color PrimaryColor => primaryColor;
    public Color SecondaryColor => secondaryColor;
    public Color BackgroundColor => backgroundColor;
    public Color TextColorDefault => textColorDefault;
    public Color HoverTextColor => hoverTextColor;
    public Color TextColorBlack => textColorBlack;
    public Color TextColorWhite => textColorWhite;
    public Color TextColorError => textColorError;
    public Color TextColorSuccess => textColorSuccess;
    public Color HostTextColor => hostTextColor;
    public Color ReadyTextColor => readyTextColor;
    public Color NotReadyTextColor => notReadyTextColor;
    public Color[] PlayerColors => playerColors;

    // ───────────────────── Spacing ─────────────────────
    public float PaddingCanvas => paddingCanvas;
    public float ListSpacing => listSpacing;

    // ───────────────────── Typography ─────────────────────
    public Font DefaultFont => defaultFont;
    public TMP_FontAsset DefaultFontTMP => defaultFontTMP;
    public Font TitleFont => titleFont;
    public int TextSizeDefault => textSizeDefault;
    public int TextSizeTitle => textSizeTitle;

    // ───────────────────── Audio ─────────────────────
    public AudioClip ButtonClickSound => buttonClickSound;
    public AudioClip ButtonHoverSound => buttonHoverSound;
    public AudioClip LobbyJoinSound => lobbyJoinSound;
    public AudioClip LobbyLeaveSound => lobbyLeaveSound;
    public AudioClip ThemeMusic => themeMusic;
}

using UnityEngine;

public enum AudioChannel{
    UI,
    Game,
    Music,
    Ambient
}

public class AudioManager : Singleton<AudioManager>
{

    [Header("Audio Sound Set")]
    public SoundSet soundSet;

    [Header("Audio Sources")]
    public AudioSource uiSource;
    public AudioSource gameSource;
    public AudioSource musicSource;
    public AudioSource ambientSource;


    protected override void Awake()
    {
        base.Awake();
        if(soundSet != null && musicSource != null)
            PlayMusic(soundSet.backgroundMusic);
    }

    public void PlaySound(AudioClip clip, AudioChannel channel){
        if(clip == null) return;

        switch(channel){
            case AudioChannel.UI:
                uiSource.PlayOneShot(clip);
                break;
            case AudioChannel.Game:
                gameSource.PlayOneShot(clip);
                break;
            case AudioChannel.Music:
                musicSource.clip = clip;
                musicSource.loop = true;
                musicSource.Play();
                break;
            case AudioChannel.Ambient:
                ambientSource.clip = clip;
                ambientSource.loop = true;
                ambientSource.Play();
                break;
        }
    }

        // Convenience Methods
    public void PlayClickSound() => PlaySound(soundSet.clickSound, AudioChannel.UI);
    public void PlayHoverSound() => PlaySound(soundSet.hoverSound, AudioChannel.UI);
    public void PlayMusic(AudioClip music) => PlaySound(music, AudioChannel.Music);

    public void SetSoundSet(SoundSet newSoundSet)
    {
        soundSet = newSoundSet;
        PlayMusic(soundSet.backgroundMusic);
    }
}

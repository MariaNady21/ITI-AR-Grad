using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager instance;

    [SerializeField] AudioSource backgroundMusic;
    [SerializeField] AudioSource sfxSource;
    public AudioClip[] musicClips;

    private bool isMusicMuted = false;

    // ✅ افتراضيًا مفيش تشغيل تلقائي للموسيقى
    public bool disableAutoMusic = true;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void Start()
    {
        if (backgroundMusic == null)
        {
            backgroundMusic = gameObject.AddComponent<AudioSource>();
            backgroundMusic.loop = true;
        }

        if (sfxSource == null)
        {
            sfxSource = gameObject.AddComponent<AudioSource>();
            sfxSource.loop = false;
        }

        // ❌ مفيش تشغيل تلقائي تاني
        // if (!disableAutoMusic)
        // {
        //     PlayMusic("BackGround");
        // }
    }

    public void PlaySFX(string sfxName)
    {
        AudioClip clipToPlay = null;

        foreach (AudioClip clip in musicClips)
        {
            if (clip.name == sfxName)
            {
                clipToPlay = clip;
                break;
            }
        }

        if (clipToPlay != null)
        {
            sfxSource.PlayOneShot(clipToPlay);
        }
    }

    public void PlayMusic(string musicName)
    {
        AudioClip clipToPlay = null;

        foreach (AudioClip clip in musicClips)
        {
            if (clip.name == musicName)
            {
                clipToPlay = clip;
                break;
            }
        }

        if (clipToPlay != null)
        {
            if (backgroundMusic.clip != clipToPlay)
            {
                backgroundMusic.clip = clipToPlay;
                backgroundMusic.Play();
            }
            else if (!backgroundMusic.isPlaying)
            {
                backgroundMusic.Play();
            }
        }
    }

    public void StopMusic()
    {
        backgroundMusic.Stop();
    }

    public void SetMusicVolume(float volume)
    {
        backgroundMusic.volume = volume;
    }

    public void ToggleMusic()
    {
        if (isMusicMuted)
        {
            backgroundMusic.Play();
        }
        else
        {
            backgroundMusic.Pause();
        }

        isMusicMuted = !isMusicMuted;
    }

    public AudioSource GetSFXSource()
    {
        return sfxSource;
    }
}

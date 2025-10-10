using UnityEngine;

public class AudioManager : MonoBehaviour
{
 public static AudioManager instance;

    public AudioClip[] playlist;   // Tableau de musiques
    public AudioSource audioSource;
    private int musicIndex = 0;

    void Awake()
    {
        // Empêche les doublons d'AudioManager
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
            return;
        }
    }

    void Start()
    {
        if (playlist.Length > 0)
        {
            audioSource.clip = playlist[0];
            audioSource.Play();
        }
    }

    void Update()
    {
        if (!audioSource.isPlaying)
        {
            PlayNextSong();
        }
    }

    void PlayNextSong()
    {
        if (playlist.Length == 0) return;

        musicIndex = (musicIndex + 1) % playlist.Length;
        audioSource.clip = playlist[musicIndex];
        audioSource.Play();
    }
}

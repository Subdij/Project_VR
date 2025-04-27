using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class MusicManager : MonoBehaviour
{
    public static MusicManager Instance { get; private set; }

    [Header("Musique de fond")]
    [Tooltip("Glissez-déposez ici votre AudioClip de musique")]
    public AudioClip musicClip;

    private AudioSource audioSource;

    private void Awake()
    {
        // Singleton
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
        DontDestroyOnLoad(gameObject);

        // Setup AudioSource
        audioSource = GetComponent<AudioSource>();
        audioSource.playOnAwake = false;
        audioSource.loop = true;

        // Charge et lance la musique
        if (musicClip != null)
        {
            audioSource.clip = musicClip;
            audioSource.Play();
        }
        else
        {
            Debug.LogWarning("MusicManager : aucun AudioClip assigné dans l’Inspector !");
        }
    }

    /// <summary>
    /// Change dynamiquement la musique de fond en cours de jeu.
    /// </summary>
    public void ChangeMusic(AudioClip newClip)
    {
        if (newClip == null || newClip == audioSource.clip) return;
        audioSource.Stop();
        audioSource.clip = newClip;
        audioSource.Play();
    }
}

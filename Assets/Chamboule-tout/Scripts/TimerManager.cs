using UnityEngine;
using UnityEngine.UI;
using System.Collections;

[RequireComponent(typeof(AudioSource))]
public class TimerManager : MonoBehaviour
{
    [Tooltip("Durée initiale du compte à rebours en secondes")]
    public int timer = 60;
    public Text timerText;

    [Header("Musique de fin")]
    [Tooltip("Glissez ici le clip à jouer quand le timer se termine")]
    public AudioClip endMusicClip;

    [SerializeField] private GameObject gun;
    [SerializeField] private GameObject targets;

    private AudioSource audioSource;

    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
        audioSource.playOnAwake = false;
        audioSource.loop = false;
        audioSource.spatialBlend = 0f; // son 2D
    }

    private void Start()
    {
        StartCoroutine(Compter());
    }

    private IEnumerator Compter()
    {
        while (timer > 0)
        {
            timerText.text = "Timer: " + timer;
            yield return new WaitForSeconds(1f);
            timer--;
        }

        timerText.text = "Fin du timer !";
        gun.SetActive(false);
        targets.SetActive(false);

        if (endMusicClip != null)
        {
            audioSource.clip = endMusicClip;
            audioSource.Play();
        }
    }
}

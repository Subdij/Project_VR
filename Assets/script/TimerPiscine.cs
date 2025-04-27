using UnityEngine;
using UnityEngine.UI;
using System.Collections;

[RequireComponent(typeof(AudioSource))]
public class TimerPiscine : MonoBehaviour
{
    [Tooltip("Durée initiale du compte à rebours en secondes")]
    public int timer = 20;

    [Header("UI")]
    public Text timerText;
    [SerializeField] private BallCollisionHandler ballCollisionHandler;
    [SerializeField] private GameObject VictoryPanel;
    [SerializeField] private Text VictoryText;
    [SerializeField] private GameObject DefeatPanel;

    [Header("Sons de fin de partie")]
    [Tooltip("Premier SFX à jouer en cas de victoire")]
    public AudioClip victoryClip1;
    [Tooltip("Deuxième SFX à jouer en cas de victoire")]
    public AudioClip victoryClip2;
    [Tooltip("SFX à jouer en cas de défaite")]
    public AudioClip defeatClip;

    private AudioSource audioSource;

    private void Start()
    {
        // Setup AudioSource
        audioSource = GetComponent<AudioSource>();
        audioSource.playOnAwake = false;
        audioSource.loop = false;
        audioSource.spatialBlend = 0f; // son 2D pour UI

        // Masquer les panels au lancement
        VictoryPanel.SetActive(false);
        DefeatPanel.SetActive(false);

        // Démarrer le compte à rebours
        StartCoroutine(Compter());
    }

    private IEnumerator Compter()
    {
        // Tant que le timer n'est pas à 0 ET que la partie n'est pas finie
        while (timer > 0 && !GameManager.Instance.GameOver)
        {
            timerText.text = $"{timer} s";
            yield return new WaitForSeconds(1f);
            timer--;
        }

        // Fin de partie : victoire ou défaite
        if (GameManager.Instance.GameOver && timer > 0)
        {
            // Victoire
            VictoryPanel.SetActive(true);
            VictoryText.text = $"Touché en { (20 - timer) } s !";

            // Jouer les deux sons de victoire
            if (victoryClip1 != null)
                audioSource.PlayOneShot(victoryClip1);
            if (victoryClip2 != null)
                audioSource.PlayOneShot(victoryClip2);
        }
        else
        {
            // Défaite
            DefeatPanel.SetActive(true);
            timerText.text = "0 s";
            if (defeatClip != null)
                audioSource.PlayOneShot(defeatClip);
        }
    }
}

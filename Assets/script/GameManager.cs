using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; set; }

    [Header("Références Scène")]
    public GameObject    ball;
    public Transform     ballSpawnPoint;


    private Rigidbody ballRb;
    private int attempts = 0;
    public bool GameOver { get; set; }

    void Awake()
    {
        // Singleton basique
        if (Instance != null && Instance != this) { Destroy(gameObject); return; }
        Instance = this;
    }

    void Start()
    {
        ballRb       = ball.GetComponent<Rigidbody>();
        // retryButton.onClick.AddListener(RestartGame);
        // UpdateAttemptUI();
    }

    /* void UpdateAttemptUI()
    {
        attemptText.text = $"Essais : {attempts}";
    } */

    /// <summary>
    /// Appelé quand la balle touche le sol
    /// </summary>
    public void RegisterMiss()
    {
        if (GameOver) return;
        attempts++;
        // UpdateAttemptUI();
        RespawnBall();
    }

    /// <summary>
    /// Appelé quand la balle touche la cible
    /// </summary>
    public void RegisterSuccess()
    {
        //  if (GameOver) return;
        // attempts++;
        // UpdateAttemptUI();
        GameOver = true;
        // successText.text = $"Vous avez réussi en {attempts} essai{(attempts>1?"s":"")} !";
        // successPanel.SetActive(true);
    } 

    void RespawnBall()
    {
        // Remise à zéro physique
        ballRb.velocity        = Vector3.zero;
        ballRb.angularVelocity = Vector3.zero;
        // Retour à la position initiale
        ball.transform.position = ballSpawnPoint.position;
        ball.transform.rotation = ballSpawnPoint.rotation;
    }

    /// <summary>
    /// Bouton Recommencer
    /// </summary>

}

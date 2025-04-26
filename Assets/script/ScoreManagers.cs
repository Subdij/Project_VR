using UnityEngine;
using TMPro;

public class ScoreManagers : MonoBehaviour
{
    public static ScoreManagers Instance { get; private set; }
    public TextMeshProUGUI scoreText;
    private int score = 0;

    void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
    }

    void Start()
    {
        UpdateScoreUI();
    }

    public void AddPoints(int points)
    {
        score += points;
        UpdateScoreUI();
    }

    /// <summary>
    /// Remet le score à zéro et rafraîchit l'affichage.
    /// </summary>
    public void ResetScore()
    {
        score = 0;
        UpdateScoreUI();
    }

    private void UpdateScoreUI()
    {
        if (scoreText != null)
            scoreText.text = $"Score : {score}";
    }
}

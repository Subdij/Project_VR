using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class TimerPiscine : MonoBehaviour
{
    [Tooltip("Durée initiale du compte à rebours en secondes")]
    public int timer = 20;

    public Text timerText;
    [SerializeField] private BallCollisionHandler ballCollisionHandler;
    [SerializeField] private GameObject VictoryPanel;
    [SerializeField] private Text VictoryText;
    [SerializeField] private GameObject DefeatPanel;

    private void Start()
    {
        // Masquer d’abord les deux panels
        VictoryPanel.SetActive(false);
        DefeatPanel.SetActive(false);

        // Lancer le compte à rebours
        StartCoroutine(Compter());
    }

    private IEnumerator Compter()
    {
        // Tant que le timer n'est pas à 0 ET que RegisterSuccess() n'a pas mis GameOver = true
        while (timer > 0 && !GameManager.Instance.GameOver)
        {
            timerText.text = "Timer: " + timer;
            yield return new WaitForSeconds(1f);
            timer--;
        }

        // Dès qu'on sort de la boucle, soit timer == 0, soit GameOver == true
        if (GameManager.Instance.GameOver && timer > 0)
        {
            // Succès avant la fin du temps
            VictoryPanel.SetActive(true);
            // Afficher le temps mis (optionnel)
            VictoryText.text += " " + (20 - timer) + " s";
        }
        else
        {
            // Timer arrivé à zéro sans toucher la cible
            DefeatPanel.SetActive(true);
            timerText.text = "Fin du temps !";
        }
  
    }
}

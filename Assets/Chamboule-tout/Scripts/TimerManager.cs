using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class TimerManager : MonoBehaviour
{
    [Tooltip("Durée initiale du compte à rebours en secondes")]
    public int timer = 60;
    public Text timerText;

    [SerializeField] private GameObject gun;
    [SerializeField] private GameObject targets;

    private void Start()
    {
        StartCoroutine(Compter());
    }

    private IEnumerator Compter()
    {
        while (timer > 0)
        {
            timerText.text = "Timer: " + timer.ToString();
            yield return new WaitForSeconds(1f);
            timer--;
        }

        timerText.text = "Fin du timer !";
        gun.SetActive(false);
        targets.SetActive(false);
    }
}
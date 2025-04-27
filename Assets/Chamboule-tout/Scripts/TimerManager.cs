using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimerManager : MonoBehaviour
{
    private int timer;
    public Text timerText;

    public GameObject finalScore;
    public GameObject currentScore;
    public GameObject Timer;
    public GameObject targets;
    public GameObject gun;

    public Text finalScoreText;
    public Text currentScoreText;


    // Start is called before the first frame update
    void Start()
    {
        timer = 60;
        timerText.text = "Timer: " + timer;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (timer == 0)
        {
            Invoke("FinalMenu", 2f);
        }
    }

    public void StartTimer()
    {
        while (timer > 0)
        {
            Invoke("CountDown", 1f);
        }
    }


    private void CountDown()
    {
        timer += -1;
        timerText.text = "Timer: " + timer;
    }

    private void FinalMenu()
    {
        finalScore.SetActive(true);
        finalScoreText.text = "Final " + currentScoreText.text;

        currentScore.SetActive(false);
        Timer.SetActive(false);
        targets.SetActive(false);
        gun.SetActive(false);
    }

}

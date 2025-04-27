using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem.Controls;
using UnityEngine.SocialPlatforms;
using UnityEngine.UI;

public class ShooterScore : MonoBehaviour
{
    // Scores locaux
    [SerializeField] private Text localScore1;
    [SerializeField] private Text localScore2;
    [SerializeField] private Text localScore3;
    [SerializeField] private Text localScore4;
    [SerializeField] private Text localScore5;
    [SerializeField] private Text localScore6;
    [SerializeField] private Text localScore7;
    [SerializeField] private Text localScore8;
    [SerializeField] private Text localScore9;
    [SerializeField] private Text localScore10;
    [SerializeField] private Text localScore11;
    [SerializeField] private Text localScore12;
    [SerializeField] private Text localScore13;
    [SerializeField] private Text localScore14;
    [SerializeField] private Text localScore15;

    // Score globlal
    private int globalScore;
    public Text globalScoreText;

    void Update()
    {
        int local1 = int.Parse(localScore1.text);
        int local2 = int.Parse(localScore2.text);
        int local3 = int.Parse(localScore3.text);
        int local4 = int.Parse(localScore4.text);
        int local5 = int.Parse(localScore5.text);
        int local6 = int.Parse(localScore6.text);
        int local7 = int.Parse(localScore7.text);
        int local8 = int.Parse(localScore8.text);
        int local9 = int.Parse(localScore9.text);
        int local10 = int.Parse(localScore10.text);
        int local11 = int.Parse(localScore11.text);
        int local12 = int.Parse(localScore12.text);
        int local13 = int.Parse(localScore13.text);
        int local14 = int.Parse(localScore14.text);
        int local15 = int.Parse(localScore15.text);

        globalScore = local1 + local2 + local3 + local4 + local5 + local6 + local7 + local8 + local9 + local10 + local11 + local12 + local13 + local14 + local15;
        globalScoreText.text = "Score: " + globalScore.ToString(); 

    }
}

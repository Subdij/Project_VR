using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    public int Score;
    public Text ScoreText;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {      
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Tin-Box")) {
            Score += 1;
            ScoreText.text = "Score: " + Score;
        }
    }
}

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    public int Score;

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
            Debug.Log(Score);
        }
    }
}

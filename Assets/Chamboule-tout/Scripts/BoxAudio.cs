using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxAudio : MonoBehaviour
{
    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Tin-Box"))
        {
            other.gameObject.GetComponent<AudioSource>().Play();
        }
    }
}

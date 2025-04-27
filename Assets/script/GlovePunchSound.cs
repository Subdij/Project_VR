using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class GlovePunchSound : MonoBehaviour
{
    [Tooltip("Clip audio du coup de poing")]
    public AudioClip punchClip;

    [Tooltip("Tag de l'objet balle")]
    public string ballTag = "Ball";

    private AudioSource audioSource;

    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
        audioSource.playOnAwake = false;
        audioSource.spatialBlend = 1f; // son 3D
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag(ballTag) && punchClip != null)
        {
            audioSource.PlayOneShot(punchClip);
        }
    }
}

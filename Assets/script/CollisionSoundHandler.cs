using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class CollisionSoundHandler : MonoBehaviour
{
    [Header("Détection de collision")]
    [Tooltip("Tag de l'objet à détecter (par exemple \"Target\", \"Ball\"...)")]
    public string targetTag;

    [Header("Son de collision")]
    [Tooltip("Clip audio à jouer lors de la collision")]
    public AudioClip collisionClip;

    private AudioSource audioSource;

    private void Awake()
    {
        // Récupère (ou ajoute) le composant AudioSource
        audioSource = GetComponent<AudioSource>();
        audioSource.playOnAwake = false;
        audioSource.loop = false;
        // spatialBlend à 1 pour un son 3D localisé, à 0 pour un son global
        audioSource.spatialBlend = 1f; 
    }

    private void OnCollisionEnter(Collision collision)
    {
        // Si l'autre objet a le tag spécifié, on joue le son
        if (collision.gameObject.CompareTag(targetTag) && collisionClip != null)
        {
            audioSource.PlayOneShot(collisionClip);
        }
    }

    // Si vous utilisez des Trigger à la place :
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(targetTag) && collisionClip != null)
        {
            audioSource.PlayOneShot(collisionClip);
        }
    }
}

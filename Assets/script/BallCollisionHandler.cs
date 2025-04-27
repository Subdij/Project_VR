using UnityEngine;

public class BallCollisionHandler : MonoBehaviour
{
    void OnCollisionEnter(Collision col)
    {
        // touche le sol ?
        if (col.gameObject.CompareTag("Ground"))
        {
            GameManager.Instance.RegisterMiss();
        }
        // si la cible n’est pas en Trigger, tu peux aussi la détecter ici :
        else if (col.gameObject.CompareTag("Target"))
        {
            GameManager.Instance.RegisterSuccess();
        }
    }

    void OnTriggerEnter(Collider other)
    {
        // ou si tu préfères que la cible soit en Trigger
        if (other.CompareTag("Target"))
            GameManager.Instance.RegisterSuccess();
    }
}

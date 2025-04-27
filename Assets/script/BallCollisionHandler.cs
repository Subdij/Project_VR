using UnityEngine;

public class BallCollisionHandler : MonoBehaviour
{
    public bool hasTouchedTarget = false;

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
            hasTouchedTarget = true;
            GameManager.Instance.RegisterSuccess();
            transform.gameObject.SetActive(false); // désactiver la balle
        }
    }

}

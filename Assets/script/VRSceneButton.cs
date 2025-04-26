using UnityEngine;
using UnityEngine.SceneManagement;

public class VRSceneButton : MonoBehaviour
{
    [Tooltip("Nom de la scène à charger")]
    public string sceneToLoad;

    void OnTriggerEnter(Collider other)
    {
        // Détecte seulement le contrôleur VR
        if (other.CompareTag("Controller"))
        {
            // Charge la scène demandée
            SceneManager.LoadScene(sceneToLoad);
        }
    }
}

using UnityEngine;
using UnityEngine.SceneManagement;

public class UIButtonSceneLoader : MonoBehaviour
{
    [Tooltip("Nom de la scène à charger")]
    public string sceneName;

    // Cette méthode sera appelée par OnClick()
    public void LoadScene()
    {
        if (!string.IsNullOrEmpty(sceneName))
            SceneManager.LoadScene(sceneName);
        else
            Debug.LogWarning("sceneName non défini sur " + gameObject.name);
    }
}

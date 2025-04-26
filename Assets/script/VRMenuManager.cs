using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;
using UnityEngine.SceneManagement;

public class VRMenuManager : MonoBehaviour
{
    [Header("UI Menu")]
    [Tooltip("Le GameObject parent du menu (Canvas ou Panel)")]
    public GameObject menuUI;

    // Caractéristiques de la manette (droite ici, à adapter si besoin)
    private InputDevice targetDevice;
    private bool      wasMenuButtonPressed = false;
    private bool      isMenuOpen           = false;

    void Start()
    {
        // Récupérer la manette droite
        var desiredChars = InputDeviceCharacteristics.Right | InputDeviceCharacteristics.Controller;
        List<InputDevice> devices = new List<InputDevice>();
        InputDevices.GetDevicesWithCharacteristics(desiredChars, devices);
        if (devices.Count > 0)
            targetDevice = devices[0];

        // S'assurer que le menu est fermé au départ
        if (menuUI != null)
            menuUI.SetActive(false);
        else
            Debug.LogWarning("MenuUI non assigné dans l’Inspector !");
    }

    void Update()
    {
        if (!targetDevice.isValid) return;

        // Lire le bouton Menu (CommonUsages.menuButton)
        if (targetDevice.TryGetFeatureValue(CommonUsages.menuButton, out bool isPressed))
        {
            // Détecter l'appui (front montant)
            if (isPressed && !wasMenuButtonPressed)
                ToggleMenu();

            wasMenuButtonPressed = isPressed;
        }
    }

    /// <summary>Ouvre/ferme le menu</summary>
    private void ToggleMenu()
    {
        isMenuOpen = !isMenuOpen;
        menuUI.SetActive(isMenuOpen);
    }

    /// <summary>Appelé via l’UI Button pour charger une autre scène</summary>
    public void LoadScene(string sceneName)
    {
        // optionnel : fermer le menu avant de changer
        if (menuUI != null) 
            menuUI.SetActive(false);
        SceneManager.LoadScene(sceneName);
    }
}

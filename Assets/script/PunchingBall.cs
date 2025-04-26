using UnityEngine;
using System.Collections;

public class PunchingBall : MonoBehaviour
{
    [Header("Réglages frappe & reset")]
    [Tooltip("Multiplicateur appliqué à la vélocité relative pour le calcul d'impulsion")]
    public float punchForceMultiplier = 1.5f;
    [Tooltip("Multiplicateur pour convertir la force de frappe en points")]
    public float scoreMultiplier = 1.0f;
    [Tooltip("Temps (en secondes) avant de reset la balle")]
    public float resetDelay = 3f;

    private Rigidbody rb;
    private Vector3 initialPosition;
    private Quaternion initialRotation;
    private bool isResetting = false;
    private bool hasBeenHit = false;  // ← nouveau flag

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        initialPosition = transform.position;
        initialRotation = transform.rotation;
    }

    void OnCollisionEnter(Collision col)
    {
        // 1. Ne rien faire si déjà frappée ou en cours de reset
        if (hasBeenHit || isResetting)
            return;

        // 2. Vérifier que c'est bien la main VR
        if (!col.gameObject.CompareTag("Controller"))
            return;

        // 3. Marquer qu'on a déjà frappé
        hasBeenHit = true;

        // 4. Calcul et application de l'impulsion
        Vector3 impulse = col.relativeVelocity * punchForceMultiplier;
        rb.AddForce(impulse, ForceMode.Impulse);

        // 5. Calcul de la puissance et ajout au score
        float punchPower = impulse.magnitude;
        int points = Mathf.RoundToInt(punchPower * scoreMultiplier);
        if (ScoreManagers.Instance != null)
            ScoreManagers.Instance.AddPoints(points);
        else
            Debug.LogError("ScoreManagers.Instance est null !");

        // 6. Démarrer la réinitialisation
        StartCoroutine(ResetAfterDelay());
    }

    private IEnumerator ResetAfterDelay()
    {
        isResetting = true;
        yield return new WaitForSeconds(resetDelay);

        // Remise en place physique
        rb.velocity = Vector3.zero;
        rb.angularVelocity = Vector3.zero;
        transform.position = initialPosition;
        transform.rotation = initialRotation;

        // Réinitialiser le score et le flag de frappe
        if (ScoreManagers.Instance != null)
            ScoreManagers.Instance.ResetScore();
        hasBeenHit = false;
        isResetting = false;
    }
}

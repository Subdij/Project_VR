using UnityEngine;
using System.Collections;

public class DunkSeat : MonoBehaviour
{
    [Header("Réglages de la chute")]
    public HingeJoint hinge;
    public float dropTorque     = 5f;
    public float targetVelocity = -100f;

    [Header("Réinitialisation")]
    [Tooltip("Temps avant de remettre la chaise en position initiale")]
    public float resetDelay = 2f;

    private bool hasDropped = false;
    private Quaternion initialLocalRotation;
    private JointLimits lockedLimits;

    void Start()
    {
        // Sauvegarde la rotation initiale
        initialLocalRotation = transform.localRotation;

        // Verrouille la chaise dès le départ : pas de mouvement autorisé
        lockedLimits = new JointLimits { min = 0f, max = 0f };
        hinge.limits = lockedLimits;
        hinge.useLimits = true;
        hinge.useMotor = false;
    }

    /// <summary>
    /// Appelé par la cible : libère la chaise pour qu'elle bascule
    /// </summary>
    public void TriggerDrop()
    {
        if (hasDropped) return;
        hasDropped = true;

        // Déverrouille pour permettre le mouvement
        hinge.useLimits = false;

        // Active le moteur pour faire basculer la chaise
        JointMotor motor = hinge.motor;
        motor.force = dropTorque;
        motor.targetVelocity = targetVelocity;
        hinge.motor = motor;
        hinge.useMotor = true;

        // Programme la remise en place
        StartCoroutine(ResetSeatAfterDelay());
    }

    private IEnumerator ResetSeatAfterDelay()
    {
        yield return new WaitForSeconds(resetDelay);

        // Stoppe le moteur et verrouille de nouveau la chaise
        hinge.useMotor = false;
        hinge.useLimits = true;
        hinge.limits = lockedLimits;

        // Remet la chaise à sa rotation de départ
        transform.localRotation = initialLocalRotation;

        hasDropped = false;
    }
}

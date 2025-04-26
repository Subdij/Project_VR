using UnityEngine;
using System.Collections;

public class DunkSeat : MonoBehaviour
{
    [Header("Réglages de la chute")]
    public HingeJoint hinge;
    public float dropTorque     = 5f;
    public float targetVelocity = -100f;

    [Header("Réinitialisation")]
    public float resetDelay = 2f;

    [Header("Référence Bob l'Éponge")]
    public Transform spongebobTransform;
    private Rigidbody spongebobRigidbody;

    // Sauvegarde des états initiaux
    private Quaternion seatInitialRotation;
    private Vector3    spongebobInitialPosition;
    private Quaternion spongebobInitialRotation;

    private JointLimits lockedLimits;
    private bool hasDropped = false;

    void Start()
    {
        // 1. Chaise
        seatInitialRotation = transform.localRotation;
        lockedLimits = new JointLimits { min = 0f, max = 0f };
        hinge.limits     = lockedLimits;
        hinge.useLimits  = true;
        hinge.useMotor   = false;

        // 2. Bob l’Éponge
        if (spongebobTransform != null)
        {
            spongebobInitialPosition = spongebobTransform.position;
            spongebobInitialRotation = spongebobTransform.rotation;
            spongebobRigidbody       = spongebobTransform.GetComponent<Rigidbody>();
        }
        else
        {
            Debug.LogWarning("Référence à Bob l’Éponge manquante !");
        }
    }

    public void TriggerDrop()
    {
        if (hasDropped) return;
        hasDropped = true;

        hinge.useLimits = false;
        JointMotor motor = hinge.motor;
        motor.force          = dropTorque;
        motor.targetVelocity = targetVelocity;
        hinge.motor          = motor;
        hinge.useMotor       = true;

        StartCoroutine(ResetSeatAfterDelay());
    }

    private IEnumerator ResetSeatAfterDelay()
    {
        yield return new WaitForSeconds(resetDelay);

        // 1. Réinitialiser la chaise
        hinge.useMotor  = false;
        hinge.useLimits = true;
        hinge.limits    = lockedLimits;
        transform.localRotation = seatInitialRotation;

        // 2. Réinitialiser Bob l’Éponge
        if (spongebobTransform != null)
        {
            spongebobTransform.position = spongebobInitialPosition;
            spongebobTransform.rotation = spongebobInitialRotation;
            if (spongebobRigidbody != null)
            {
                spongebobRigidbody.velocity        = Vector3.zero;
                spongebobRigidbody.angularVelocity = Vector3.zero;
            }
        }

        hasDropped = false;
    }
}

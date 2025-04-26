using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System;
using UnityEngine;
using UnityEngine.InputSystem;
public class NewBehaviourScript : MonoBehaviour
{
    [SerializeField] private Animator _handAnimator;
    [SerializeField] private InputActionReference _triggerActionRef;
    [SerializeField] private InputActionReference _gripActionRef;

    private static readonly int triggerAnimation = Animator.StringToHash(name: "Trigger");
    private static readonly int gripAnimation = Animator.StringToHash(name: "Grip");

    private void Update()
    {
        float triggerValue = _triggerActionRef.action.ReadValue<float>();
        _handAnimator.SetFloat(id:triggerAnimation, triggerValue);

        float gripValue = _gripActionRef.action.ReadValue<float>();
        _handAnimator.SetFloat(id:gripAnimation, gripValue);
    }

}

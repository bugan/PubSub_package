using System;
using System.Security.Cryptography;
using UnityEngine;
using UnityEngine.InputSystem;

public class MouseInput : MonoBehaviour
{
    private InputAction attackAction;
    [SerializeField]
    private Health health;

    void Start()
    {
        attackAction = InputSystem.actions.FindAction("Attack");
    }


    void Update()
    {
        if (attackAction.WasPerformedThisFrame())
        {
            health.TakeDamage();
        
        } 
    }
}

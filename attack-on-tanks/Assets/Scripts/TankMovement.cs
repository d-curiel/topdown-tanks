using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class TankMovement : MonoBehaviour
{
    Rigidbody2D _RigidBody2D;
    Vector2 _CurrentMovement;
    [SerializeField]
    TankMovementData _TankMovementData;

    public UnityEvent<float> OnSpeedChange = new UnityEvent<float>();
    private void Awake()
    {
        _RigidBody2D = GetComponentInParent<Rigidbody2D>();
    }

    public void Move(Vector2 movementVector)
    {
        this._CurrentMovement = movementVector;

    }
    
    private void FixedUpdate()
    {
        _RigidBody2D.velocity = (Vector2)transform.up * _CurrentMovement.y * _TankMovementData.MovementSpeed  * Time.fixedDeltaTime;
        OnSpeedChange?.Invoke(_CurrentMovement.y);
        _RigidBody2D.MoveRotation(transform.rotation * Quaternion.Euler(0, 0, -_CurrentMovement.x * _TankMovementData.RotationSpeed * Time.fixedDeltaTime));
    }

}

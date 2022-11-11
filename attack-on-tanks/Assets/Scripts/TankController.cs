using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class TankController : MonoBehaviour
{

    TankMovement _TankMovement;
    AimTurret _AimTurret;
    TurretController[] _TurretController;

    public AimTurret AimTurret { get => _AimTurret; }
    public TankMovement TankMovement { get => _TankMovement; }


    private void Awake()
    {
        _TankMovement = GetComponentInChildren<TankMovement>();
        _AimTurret = GetComponentInChildren<AimTurret>();
        _TurretController = GetComponentsInChildren<TurretController>();
    }

    public void OnMovementInput(Vector2 movementDirection)
    {
        _TankMovement.Move(movementDirection);
    }
    public void OnAimInput(Vector2 aimPosition)
    {
        _AimTurret.Aim(aimPosition);
    }

    public void OnShotInput()
    {
        foreach(TurretController turret in _TurretController)
        {
            turret.Shoot();
        }
    }

}

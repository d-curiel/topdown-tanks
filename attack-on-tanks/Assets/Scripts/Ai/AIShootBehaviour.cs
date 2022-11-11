using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIShootBehaviour : AIBehaviour
{
    private float _FOVForShooting = 200;
     
    public override void PerformAction(TankController tank, AIDetector aIDetector)
    {
        tank.OnAimInput(aIDetector.Target.position);
        if (TargetInFOV(tank, aIDetector))
        {
            tank.OnMovementInput(Vector2.zero);
            tank.OnShotInput();
        }
    }

    private bool TargetInFOV(TankController tank, AIDetector aIDetector)
    {
        Vector2 direction = aIDetector.Target.position - tank.AimTurret.transform.position;
        return (Vector2.Angle(tank.AimTurret.transform.right, direction) < _FOVForShooting / 2);
    }
}

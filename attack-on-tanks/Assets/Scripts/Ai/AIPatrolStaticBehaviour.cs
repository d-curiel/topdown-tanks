using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIPatrolStaticBehaviour : AIBehaviour
{

    private float _PatrolDelay = 4;
    [SerializeField]
    private float _CurrentPatrolDelay = 4;

    private Vector2 _RandomDirection = Vector2.zero;

    private void Awake()
    {
        _RandomDirection = Random.insideUnitCircle;
    }
    public override void PerformAction(TankController tank, AIDetector aIDetector)
    {
        float angle = Vector2.Angle(tank.AimTurret.transform.right, _RandomDirection);
        if (_CurrentPatrolDelay <= 0 && (angle < 2))
        {
            _RandomDirection = Random.insideUnitCircle;
            _CurrentPatrolDelay = _PatrolDelay;
        } else
        {
            if(_CurrentPatrolDelay > 0)
            {
                _CurrentPatrolDelay -= Time.deltaTime;
            }
            else
            {
                tank.OnAimInput((Vector2)tank.AimTurret.transform.position + _RandomDirection);
            }
        }
    }
}

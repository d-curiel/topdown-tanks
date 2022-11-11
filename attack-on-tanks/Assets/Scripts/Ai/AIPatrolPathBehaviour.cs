using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIPatrolPathBehaviour : AIBehaviour
{
    [SerializeField]
    private PatrolPath _PatrolPath;
    [Range(0.1f, 1f)]
    private float _ArriveDistance = 1;
    private float _WaitingTime = 0.5f;
    [SerializeField]
    private bool _IsWaiting = false;
    [SerializeField]
    private Vector2 _CurrentPatrolTarget = Vector2.zero;
    private bool _IsInitialized = false;

    private int _CurrentIndex = -1;
    private void Awake()
    {
        if(_PatrolPath == null)
        {
            _PatrolPath = GetComponentInChildren<PatrolPath>();
        }
    }

    public override void PerformAction(TankController tank, AIDetector aIDetector)
    {
        if (!_IsWaiting)
        {
            if(_PatrolPath._PatrolLength < 2)
            {
                return;
            }

            if (!_IsInitialized)
            {
                var currentPathPoint = _PatrolPath.GetClosestPathPosition(tank.transform.position);
                this._CurrentIndex = currentPathPoint.Index;
                this._CurrentPatrolTarget = currentPathPoint.Position;
                _IsInitialized = true;
            }
            if (Vector2.Distance(tank.transform.position, this._CurrentPatrolTarget) < _ArriveDistance)
            {
                _IsWaiting = true;
                StartCoroutine(Wait());
                return;
            }
            Vector2 directionToPatrol = _CurrentPatrolTarget - (Vector2)tank.TankMovement.transform.position;
            var dotProduct = Vector2.Dot(tank.TankMovement.transform.up, directionToPatrol.normalized);
            if(dotProduct < .99f)
            {
                var crossProduct = Vector3.Cross(tank.TankMovement.transform.up, directionToPatrol.normalized);
                var rotationResult = crossProduct.z >= 0 ? -1 : 1;
                tank.OnMovementInput(new Vector2(rotationResult, 1));
            } else
            {
                tank.OnMovementInput(Vector2.up);
            }
        }
    }

    private IEnumerator Wait()
    {
        yield return new WaitForSeconds(_WaitingTime);
        var nextPatrolPoint = _PatrolPath.GetNextPAthPoint(_CurrentIndex);
        this._CurrentIndex = nextPatrolPoint.Index;
        this._CurrentPatrolTarget = nextPatrolPoint.Position;
        _IsWaiting = false;

    }
}

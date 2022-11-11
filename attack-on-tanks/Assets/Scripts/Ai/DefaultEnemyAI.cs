using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DefaultEnemyAI : MonoBehaviour
{
    [SerializeField]
    private AIBehaviour _ShootBehaviour, _PatrolBehaviour;

    [SerializeField]
    private TankController _Tank;

    [SerializeField]
    private AIDetector _AIDetector;

    private void Awake()
    {
        _Tank = GetComponentInChildren<TankController>();
        _AIDetector = GetComponentInChildren<AIDetector>();
    }


    private void Update()
    {
        if (_AIDetector.TargetVisible)
        {
            _ShootBehaviour.PerformAction(_Tank, _AIDetector);
        } else
        {
            _PatrolBehaviour.PerformAction(_Tank, _AIDetector);
        }
    }
}

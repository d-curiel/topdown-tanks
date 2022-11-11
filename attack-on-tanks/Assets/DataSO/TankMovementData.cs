using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NewTankMovementData", menuName = "Data/TankMovementData")]
public class TankMovementData : ScriptableObject
{
    public float MovementSpeed;
    public float RotationSpeed;
}

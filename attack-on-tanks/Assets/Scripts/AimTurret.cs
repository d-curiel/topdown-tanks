using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AimTurret : MonoBehaviour
{
    private Vector2 currentAimPosition;
    public void Aim(Vector2 aimPosition)
    {
        currentAimPosition = aimPosition;
    }

    private void FixedUpdate()
    {
        var faceingDirection = currentAimPosition - (Vector2)transform.position;
        var angle = Mathf.Atan2(faceingDirection.y, faceingDirection.x) * Mathf.Rad2Deg;
        var turretRotationStep = 350 * Time.deltaTime;
        transform.rotation = Quaternion.RotateTowards(transform.rotation, Quaternion.Euler(0, 0, angle), turretRotationStep);
    }
}

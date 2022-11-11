using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameObjectFollower : MonoBehaviour
{
    [SerializeField]
    Transform _ObjectToFollow;

    private void Update()
    {
        gameObject.transform.position = _ObjectToFollow.transform.position;
    }
}

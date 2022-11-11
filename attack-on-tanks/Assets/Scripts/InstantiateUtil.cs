using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstantiateUtil : MonoBehaviour
{
    [SerializeField]
    GameObject _Prefab;

    public void InstantiateObject()
    {
        Instantiate(_Prefab);
    }
}

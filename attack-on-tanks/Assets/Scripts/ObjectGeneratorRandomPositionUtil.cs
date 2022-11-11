using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectGeneratorRandomPositionUtil : MonoBehaviour
{
    [SerializeField]
    private GameObject _Prefab;
    [SerializeField] 
    private float _Radius;

    protected Vector2 GetRandomPosition()
    {
        return Random.insideUnitCircle * _Radius + (Vector2)transform.position;
    }

    protected Quaternion Random2DRotation()
    {
        return Quaternion.Euler(0, 0, Random.Range(0, 360));
    }

    public void CreateObject()
    {
        GameObject impactObject = GetObject();
        impactObject.transform.position = GetRandomPosition();
        impactObject.transform.rotation = Random2DRotation();
    }

    protected virtual GameObject GetObject()
    {
        return Instantiate(_Prefab);
    }
}

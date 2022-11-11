using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrackMarksSpawner : MonoBehaviour
{
    private Vector2 _LastPosition;
    private float _TrackMarkDistance = 1f;
    [SerializeField]
    private GameObject _TrackMarkPrefab;
    private int _ObjectPoolSize = 50;

    private ObjectPool _TrackMarksPool;

    private void Awake()
    {
        _TrackMarksPool = GetComponent<ObjectPool>();
    }

    void Start()
    {
        _LastPosition = transform.position;
        _TrackMarksPool.Init(_TrackMarkPrefab, _ObjectPoolSize);
    }

    void Update()
    {
        var distanceDriven = Vector2.Distance(transform.position, _LastPosition);
        if (distanceDriven >= _TrackMarkDistance)
        {
            _LastPosition = transform.position;
            var tracks = _TrackMarksPool.CreateObject();
            tracks.transform.position = transform.position;
            tracks.transform.rotation = transform.rotation;
        }
    }
}

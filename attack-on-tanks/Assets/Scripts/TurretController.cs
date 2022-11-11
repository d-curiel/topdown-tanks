using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(ObjectPool))]
public class TurretController : MonoBehaviour
{
    [SerializeField]
    List<Transform>_Barrels;
    [SerializeField]
    TurretData _TurretData;
    [SerializeField]
    private int _BulletPoolCount = 10;

    private float _CurrentDelay;
    private bool _CanShoot = true;

    private Collider2D[] _TankColliders;
    private ObjectPool _BulletPool;

    public UnityEvent OnShoot, OnCantShoot;
    public UnityEvent<float> OnReloading;
    private void Awake()
    {
        _TankColliders = GetComponentsInParent<Collider2D>();
        _BulletPool = GetComponent<ObjectPool>();
    }
    private void Start()
    {

        _BulletPool.Init(_TurretData.BulletPrefab, _BulletPoolCount);
        OnReloading?.Invoke(_CurrentDelay);
    }
    private void Update()
    {
        if (!_CanShoot)
        {
            _CurrentDelay -= Time.deltaTime;
            OnReloading?.Invoke(_CurrentDelay / _TurretData.ShootDelay);
            _CanShoot = _CurrentDelay <= 0;
        }
    }

    public void Shoot()
    {
        if (_CanShoot)
        {
            _CanShoot = false;
            _CurrentDelay = _TurretData.ShootDelay;
            foreach(Transform barrel in _Barrels)
            {
                GameObject bullet = _BulletPool.CreateObject();
                bullet.transform.position = barrel.position;
                bullet.transform.localRotation = barrel.rotation;
                bullet.GetComponent<BulletController>().Init(_TurretData.BulletData);
                foreach(Collider2D collider in _TankColliders)
                {
                    Physics2D.IgnoreCollision(bullet.GetComponent<Collider2D>(), collider);
                }
            }

            OnShoot?.Invoke();
            OnReloading?.Invoke(_CurrentDelay);
        } else
        {
            OnCantShoot?.Invoke();
        }
    }
}

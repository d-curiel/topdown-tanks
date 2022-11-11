using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class BulletController : MonoBehaviour
{
    BulletData _BulletData;

    private Vector2 _StartPosition;
    private float _ConquaredDistance;

    private Rigidbody2D _RigidBody2D;

    public UnityEvent OnHit = new UnityEvent();
    public void Init(BulletData _BulletData)
    {
        this._BulletData = _BulletData;
        _StartPosition = transform.position;
        _RigidBody2D.velocity = transform.up * _BulletData.Speed;
    }
    private void Awake()
    {
        _RigidBody2D = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        _ConquaredDistance = Vector2.Distance(_StartPosition, transform.position);
        if(_ConquaredDistance > _BulletData.MaxDistance)
        {
            DisableObject();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        OnHit?.Invoke();
        DamageableBehaviour damageable = collision.GetComponent<DamageableBehaviour>();
        if (damageable != null)
        {
            damageable.Hit(_BulletData.Damage);
        }
        DisableObject();
    }

   

    private void DisableObject()
    {
        gameObject.SetActive(false);
        _RigidBody2D.velocity = Vector2.zero;
    }
}

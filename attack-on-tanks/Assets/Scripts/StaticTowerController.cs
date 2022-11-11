using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StaticTowerController : MonoBehaviour
{
    Rigidbody2D _Barrel;
    [SerializeField]
    GameObject _BarrelObject;
    [SerializeField]
    GameObject _Bullet;
    [SerializeField]
    Transform _ShootPosition;
    GameObject _PlayerDetected; Vector2 faceingDirection;

    private void Awake()
    {
        _Barrel = _BarrelObject.GetComponent<Rigidbody2D>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            if(_PlayerDetected == null)
            {
                _PlayerDetected = collision.gameObject;
                InvokeRepeating("LookAndShoot", 2f, 1f);
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            _PlayerDetected = null; 
            CancelInvoke("LookAndShoot");
        }
    }
    private void FixedUpdate()
    {
        
    }

    private void LookAndShoot()
    {
           
        faceingDirection = (Vector2)_PlayerDetected.transform.position - _Barrel.position;
        float angle = Mathf.Atan2(faceingDirection.y, faceingDirection.x) * Mathf.Rad2Deg + 90;
        _Barrel.MoveRotation(angle);
        Shot();
    }
    private void Shot()
    {
        float angle = Mathf.Atan2(faceingDirection.y, faceingDirection.x) * Mathf.Rad2Deg - 90;
        GameObject bulletToShot = Instantiate(_Bullet);
        bulletToShot.transform.position = _ShootPosition.position;
        bulletToShot.GetComponent<Rigidbody2D>().MoveRotation(angle);
        bulletToShot.GetComponent<Rigidbody2D>().AddForce(faceingDirection.normalized * 300f);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplosionBehaviour : MonoBehaviour
{
    [SerializeField]
    private int _DamageBarrel;

    public void Explode()
    {
        ContactFilter2D cf;
        Collider2D[] result = new Collider2D[10];
        Physics2D.OverlapCircle(gameObject.transform.position, 3f, new ContactFilter2D(), result);
        foreach(Collider2D collision in result)
        {
            if(collision != null) { 
                DamageableBehaviour damageable = collision.GetComponent<DamageableBehaviour>();
                if (damageable != null)
                {
                    damageable.Hit(_DamageBarrel);
                }
            }
        }
    }
}

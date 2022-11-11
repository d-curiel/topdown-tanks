using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealingBagBehaviour : MonoBehaviour
{

    [SerializeField]
    private HealingData _HealingData;
    private AudioSource _AudioSource;

    private void Awake()
    {
        _AudioSource = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        DamageableBehaviour damageable = collision.GetComponent<DamageableBehaviour>();
        if(damageable != null)
        {
            damageable.Heal(_HealingData.HealingPoints);
            _AudioSource.PlayOneShot(_AudioSource.clip);
            StartCoroutine(Wait());
        }
    }

    private IEnumerator Wait()
    {
        yield return new WaitForSeconds(_AudioSource.clip.length);
        Destroy(gameObject);
    }


}

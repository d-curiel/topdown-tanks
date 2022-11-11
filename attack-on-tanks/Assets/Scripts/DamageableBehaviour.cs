using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class DamageableBehaviour : MonoBehaviour
{
    [SerializeField]
    private DamageableData _DamageableData;
    [SerializeField]
    private int _Health;

    public int Health { 
        get => _Health;
        set {
            _Health = value; 
            OnHealthChange?.Invoke((float)Health / _DamageableData.MaxHealth);
        } 
    }

    public UnityEvent OnDead;
    public UnityEvent<float> OnHealthChange;
    public UnityEvent OnHit, OnHeal;

    private void Start()
    {
        if (Health == 0)
            Health = _DamageableData.MaxHealth;
    }

    internal void Hit(int damage)
    {
        if(Health > 0) { 
            Health -= damage;
            if(Health <= 0)
            {
                OnDead?.Invoke();
            } else
            {
                OnHit?.Invoke();
            }
        }
    }

    internal void Heal(int healthBoost)
    {
        Health += healthBoost;
        Health = Mathf.Clamp(Health, 0, _DamageableData.MaxHealth);
        OnHeal?.Invoke();
    }
}

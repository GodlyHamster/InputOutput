using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthSystem : MonoBehaviour
{

    public event Action<int> _HealthUpdated;
    [SerializeField] int _health;

    public void TakeDamage(int damage)
    {
        _health -= damage;
        _HealthUpdated(_health);
    }

    public void AddHealth(int health)
    {
        if ((_health + health) > 100) { }
        else
        {
            _health += health;
            _HealthUpdated(_health);
        }
    }
}

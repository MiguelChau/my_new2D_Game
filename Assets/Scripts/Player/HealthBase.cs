using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthBase : MonoBehaviour
{
    public Action OnKill;

    [Header("Life Stats")]
    public int startLife = 50;
    private float _currentLife;
    public float delayToKill;

    public bool destroyOnKill = false;

    private void Awake()
    {
        Init();
    }

    private void Init()
    {
        _currentLife = startLife;
    }

    public void Damage(int damage)
    {
        if(_currentLife <=0)
        {
            Kill();
        }
    }

    private void Kill()
    {
        if(destroyOnKill)
        {
            Destroy(gameObject, delayToKill);
        }
    }
}

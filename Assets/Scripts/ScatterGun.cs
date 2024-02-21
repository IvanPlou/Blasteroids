using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScatterGun : Weapon
{
    [SerializeField] protected int _bulletCount = 5;
    [SerializeField] protected float _bulletSpread = 30f;

    protected override void Fire()
    {
            for (int i = 0; i < _bulletCount; i++)
                {
                Quaternion randomRotation = Quaternion.Euler (Random.Range(-_bulletSpread, _bulletSpread), Random.Range(-_bulletSpread, _bulletSpread), 0); 
                Instantiate(_bulletPrefab, transform.position, transform.rotation * randomRotation);
                }
    }    
}


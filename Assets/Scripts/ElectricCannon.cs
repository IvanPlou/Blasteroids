using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.UIElements;

public class ElectricCannon : ScatterGun
{
    //Change the base ScatterGun Fire Method for a new instantiation of the projectile with rotation. Can use a different prefab in the inspector.
    protected override void Fire()
    {  
          Quaternion randomRotation = Quaternion.Euler(Random.Range(-_bulletSpread, _bulletSpread), Random.Range(-_bulletSpread, _bulletSpread), 0);
          GameObject lasgun = GameObject.Instantiate(_bulletPrefab, transform.position, transform.rotation);
          lasgun.transform.rotation = randomRotation;
    }
    
}

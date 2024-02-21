using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    //Editable parameters on the inspector.
    [SerializeField] protected string _fireButton = "Fire1";
    [SerializeField] protected GameObject _bulletPrefab;
    [SerializeField] private float _cooldown = 0.2f;

    private float _nextShootTime = 0f;

    private void Update()
    {
        //Checks cooldown time and calls fire method.
        if(Input.GetButton(_fireButton) && Time.timeSinceLevelLoad >= _nextShootTime) 
        {
            _nextShootTime = Time.timeSinceLevelLoad + _cooldown;
            Fire();
        }
    }

    //Instantiates the selected bullet/projectile prefab on the ship's position and rotation.
    protected virtual void Fire()
    {
        Instantiate(_bulletPrefab, transform.position, transform.rotation);
    }
}

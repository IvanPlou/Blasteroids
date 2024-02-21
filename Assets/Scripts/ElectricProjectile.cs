using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElectricProjectile : Projectile
{
    // variables editeable in the inspector.
    [SerializeField] private float _speed = 20f;
    [SerializeField] private float _lifetime = 0f;
    [SerializeField] private float _rotationSpeed = 0f;

    private Rigidbody _rb;

    // Overrides the standard Projectile Start Method to change the rotation be fixed in x and y axis and adjustable in z axis.
    protected virtual void Start()
    {
        _rb = GetComponent<Rigidbody>();
        _rb.velocity = transform.forward * _speed;
        Vector3 rotation = new Vector3 (0f,0f,1f);
        _rb.AddTorque(rotation * _rotationSpeed);
        if (_lifetime > 0f)
        {
            Destroy(gameObject, _lifetime);
        }
    }
}

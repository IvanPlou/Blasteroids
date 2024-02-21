using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    //Editable parameters on the inspector.
    [SerializeField] private float _speed = 20f;
    [SerializeField] private float _speed2 = 20f;
    [SerializeField] private float _lifetime = 0f;
    [SerializeField] private float _rotationSpeed = 0f;

    private Rigidbody _rb;

    //Gets the rigid body (what handles physics) of the projectile and adds a forward (z axis) force with an adjustable parameter. Sets lifetime of the object to an adjustable parameter.
    protected virtual void Start()
    {
        _rb = GetComponent<Rigidbody>();
        _rb.velocity = transform.forward * Random.Range(_speed, _speed2);
        _rb.AddTorque(Random.insideUnitSphere * _rotationSpeed);
        if( _lifetime > 0f )
        {
            Destroy(gameObject, _lifetime);
        }
    }   
}

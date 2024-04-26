using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageOnCollision : MonoBehaviour
{
    //Editable parameters on the inspector. 
    [SerializeField] private string _tagToDamage; //Able to select damageable tags using a string.
    [SerializeField] private float _damageAmount = 1f;


    private void OnTriggerEnter(Collider other)
    {
        //If the tag of the object coincides with the tag inputed on the string field in the inspector, gets the object's health and applies health reduction method.
        // Destroys the projectile after collision.
        if(other.CompareTag(_tagToDamage))
        {
            Health health = other.GetComponent<Health>();
            if(health != null )
            {
                health.ApplyDamage(_damageAmount);
                Destroy(gameObject);
            }
        }
    }


}


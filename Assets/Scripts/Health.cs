using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Health : MonoBehaviour
{
    //Parameters editable in the inspector.
    [SerializeField] private float _maxHealth = 10f;
    [SerializeField] private GameObject _deathParticle;
    [SerializeField] private int _scoreValue = 0;

    private float _currentHealth;

    public float HealthPercentage => _currentHealth / _maxHealth;
    public UnityEvent OnDeath;

    //Defautls current health to max possible health at the beggining of the game.
    private void Start()
    {
        _currentHealth = _maxHealth;
    }

    //Function to implement damage which applies the damage parameter from the object colliding, to the current health, as long as health is higher than 0.
    public void ApplyDamage(float damage)
    {
        if(_currentHealth <= 0)
        {
            return;
        }

        _currentHealth = Mathf.Clamp(_currentHealth - damage, 0f, _maxHealth);

       //If the asteroids halth has reached 0 or less, instantiates the selected death particale and invokes the OnDeth Event that can be saved and recognized by other classes. 
       // Calls the AddScore function to increase the score variable from Score class.
       // Destroys the asteroid game object from the game and hierarchy.
        if(_currentHealth <= 0f) 
        {
            if( _deathParticle != null ) 
            {
                Instantiate(_deathParticle, transform.position, transform.rotation);
            }
            OnDeath.Invoke();
            Score.AddScore(_scoreValue);
            Destroy(gameObject);
        }
    }

}

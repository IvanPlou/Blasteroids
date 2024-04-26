using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidSpawn : MonoBehaviour
{
    //Editable parameters on the inspector.
    [SerializeField] private List<GameObject> _asteroidPrefabs = new List<GameObject>();

    [SerializeField] private float _spawnRadius;
    [SerializeField] private float _targetRadius;
    [SerializeField] private float _spawnTimeMin;
    [SerializeField] private float _spawnTimeMax;


    [SerializeField] private Transform _target;
    private Vector3 _lastSpawnLocation;
    private Vector3 _lastTargetLocation;

    private void Start()
    {
        //Executes the called corroutine to follow a sequence
        StartCoroutine(SpawnCoro());
    }

    private Vector3 GetPointInSphere(Vector3 center, float radius)
    {
        Vector3 result = center + Random.insideUnitSphere * radius;
        return result;
    }
    private IEnumerator SpawnCoro()
    {
        while (_target != null)
        {
            // This happens first
            _lastSpawnLocation = GetPointInSphere(transform.position, _spawnRadius);
            _lastTargetLocation = GetPointInSphere(_target.position, _targetRadius);
            Quaternion targetDirection = Quaternion.LookRotation(_lastTargetLocation - _lastSpawnLocation);
            Instantiate(_asteroidPrefabs[Random.Range(0, _asteroidPrefabs.Count)], _lastSpawnLocation, targetDirection);
            yield return new WaitForSeconds(Random.Range(_spawnTimeMin, _spawnTimeMax));
            // continues to this
        }
    }

    //Draws debug gizmos to see the spawn position and radius, the target position and radius (to which the asteroids are going to be sent).
    private void OnDrawGizmos()
    {
        if (_target == null)
        {
            return;
        }
        Gizmos.color = Color.magenta;
        Gizmos.DrawWireSphere(transform.position, _spawnRadius);
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(_target.position, _targetRadius);
        Gizmos.color = Color.red;
        if(_lastSpawnLocation != null) 
        {
            Gizmos.DrawLine(_lastSpawnLocation, _lastTargetLocation);
        }
    }


}
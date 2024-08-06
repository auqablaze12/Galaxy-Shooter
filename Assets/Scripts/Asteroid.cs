using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Asteroid : MonoBehaviour
{

    private float _rotateSpeed = 5.0f;
    [SerializeField]
    private GameObject _explostionPrefab;
    private SpawnManager _spawnManager;

    private void Start()
    {
        _spawnManager = GameObject.Find("Spawn_Manager").GetComponent<SpawnManager>();
        

        if (_spawnManager == null)
        {
            Debug.LogError("Spawn Manager is NULL.");
        }


    }
    
    void Update()
    {
        transform.Rotate(Vector3.forward * _rotateSpeed * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D other)
    { 

        if (other.tag == "Laser")
        {
            Instantiate(_explostionPrefab, transform.position, Quaternion.identity);
            Destroy(other.gameObject);
            _spawnManager.StartSpawning();
            Destroy(this.gameObject, 0.2f);
        }
    }

}



using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{

    [SerializeField]
    private GameObject _enemyPrefab;
    [SerializeField]
    private GameObject _enemyContainer;
    [SerializeField]
    private GameObject[] powerups;

    private bool _stopSpawning = false;

    private AudioSource _explosionAudio;
    [SerializeField]
    private AudioClip _explosionClip;


    public void StartSpawning()
    {
        StartCoroutine(EnemySpawnRoutine());
        StartCoroutine(PowerupSpawnRoutine());
    }

    IEnumerator EnemySpawnRoutine()
    {

        yield return new WaitForSeconds(3.0f);

        while (_stopSpawning == false)
        {
            Vector3 posToSpawn = new Vector3(Random.Range(-9f, 9f), 7, 0);
            GameObject newEnemy = Instantiate(_enemyPrefab, posToSpawn, Quaternion.identity);
            newEnemy.transform.parent = _enemyContainer.transform;
            yield return new WaitForSeconds(3.0f);
        }
      
    }

    IEnumerator PowerupSpawnRoutine()
    {
        while (_stopSpawning == false)
        {
            Vector3 posToSpawn = new Vector3(Random.Range(-9f, 9f), 7, 0);
            int randomPowerUp = Random.Range(0, 3);
            Instantiate(powerups[randomPowerUp], posToSpawn, Quaternion.identity);
            yield return new WaitForSeconds(Random.Range(3, 8));
        }
    }



    public void OnPlayerDeath()
    {
        _stopSpawning = true;

        AudioSource _explosionAudio = GetComponent<AudioSource>();

        _explosionAudio.clip = _explosionClip;
        _explosionAudio.Play();
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour


{
    [SerializeField]
    private GameObject _enemyprefab;
    [SerializeField]
    private GameObject _container;
    [SerializeField]
    private GameObject _powerupPrefab;
    [SerializeField]
    public bool PlayerDead = false;

    private void Start()
    {
        print("Start");
        SpawnEnemy();
        StartCoroutine(SpawnEnemy());
        StartCoroutine(SpawnPowerup());
    }

    IEnumerator SpawnEnemy()
    {
        Vector3 posToSpawn = new Vector3(0, 0, 0);

        while (PlayerDead == false)
        {
            GameObject newEnemy = Instantiate(_enemyprefab, posToSpawn, Quaternion.identity);
            newEnemy.transform.parent = _container.transform;
            yield return new WaitForSeconds(2);
            
        }
    }

    IEnumerator SpawnPowerup()
    {
       
        while (PlayerDead == false)
        {
            GameObject powerUp = Instantiate(_powerupPrefab, new Vector3(Random.Range(-9, 9), 7.4f, 0), Quaternion.identity);
            powerUp.transform.parent = _container.transform;
            yield return new WaitForSeconds(10);

        }
    }

    public void OnPlayerDeath()
    {
        Debug.Log("bum");
        PlayerDead = true;
    }
}


//Instantiate(_laserPrefab, transform.position + _centerTurretVector, Quaternion.identity);
//_canFire = Time.time + _fireRate;
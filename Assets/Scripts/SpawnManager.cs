using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour


{
    [SerializeField]
    private GameObject _enemyprefab;
    [SerializeField]
    private GameObject _enemycontainer;
    [SerializeField]
    private GameObject[] _powerups;
    [SerializeField]
    private GameObject _powerupcontainer;
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
        while (PlayerDead == false)
        {
            
            GameObject newEnemy = Instantiate(_enemyprefab, new Vector3(Random.Range(-9, 9), 7.4f, 0), Quaternion.identity);
            newEnemy.transform.parent = _enemycontainer.transform;
            yield return new WaitForSeconds(2);
        }
    }

    IEnumerator SpawnPowerup()
    {
       
        while (PlayerDead == false)
        {
            //int i = Random.Range(0, 2);
            int randPowerUp = Random.Range(0, 2);

            GameObject powerUp = Instantiate(_powerups[randPowerUp], new Vector3(Random.Range(-9, 9), 7.4f, 0), Quaternion.identity);
            powerUp.transform.parent = _powerupcontainer.transform;
            yield return new WaitForSeconds(1);

        }
    }

    public void OnPlayerDeath()
    {
        PlayerDead = true;
    }
}
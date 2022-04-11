using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject enemyPrefab;
    public float spawnRadius = 12f;
    public float minEnemyRate = 2f;
    public int maxEnemies = 6;
    public int startEnemyNumber = 5;

    float enemyRate = 5f;
    float nextEnemy = 1;

    void Start(){
        for (int i = 0; i < startEnemyNumber; i++)
        {
            Vector3 offset = Random.onUnitSphere;
            offset.z = 0;
            offset = offset.normalized * spawnRadius;

            Instantiate(enemyPrefab, transform.position + offset, transform.rotation);
        }
    }

    // Update is called once per frame
    void Update()
    {
        nextEnemy -= Time.deltaTime;

        Vector3 offset = Random.onUnitSphere;
        offset.z = 0;
        offset = offset.normalized * spawnRadius;

        GameObject[] enemyObjects = GameObject.FindGameObjectsWithTag(enemyPrefab.tag);
        int enemyCount = enemyObjects.Length;

        if (nextEnemy <= 0 && enemyCount < maxEnemies) {
            nextEnemy = enemyRate;
            enemyRate = Mathf.Max(enemyRate *= 0.9f, minEnemyRate);

            Instantiate(enemyPrefab, transform.position + offset, transform.rotation);
        }
    }
}

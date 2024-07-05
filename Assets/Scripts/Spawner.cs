using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] GameObject[] enemies;
    GameObject enemyToSpawn;
    float spawnTime = 0.4f;
    //ENCAPSULATION
    public float SpawnTime 
    {  
        get { return spawnTime; } 
        set 
        { 
            if (value <= 0) 
            {
                Debug.LogError("Spawn time cannot be less or equal to 0");
            }
            else
            {
                spawnTime = value;
            }
       } 
    }
     
    private void Start()
    {
        StartCoroutine(EnemySpawn());
    }

    IEnumerator EnemySpawn()
    {
        yield return new WaitForSeconds(spawnTime);
        Instantiate(GetRandomEnemy(), GenerateRandomSpawnPos(), enemyToSpawn.transform.rotation);
        StartCoroutine(EnemySpawn());
    }

    //ABSTRACTION
    GameObject GetRandomEnemy()
    {
        enemyToSpawn = enemies[Random.Range(0, enemies.Length)];
        return enemyToSpawn;
    }
    Vector3 GenerateRandomSpawnPos()
    {
        return new Vector3(Random.Range(-10f, 10f), enemyToSpawn.transform.localScale.y / 2, 20);
    }
}

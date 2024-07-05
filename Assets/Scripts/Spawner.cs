using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public static Spawner Instance;

    [SerializeField] GameObject[] enemies;
    GameObject enemyToSpawn;
    //ENCAPSULATION
    public float SpawnPosZ { get; private set; } = 120;
    float boundaryX = 9.5f;
    
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

    //ABSTRACTION
    GameObject GetRandomEnemyPrefab()
    {
        enemyToSpawn = enemies[Random.Range(0, enemies.Length)];
        return enemyToSpawn;
    }

    private void Start()
    {
        Instance = this;
        SpawnTime = MainManager.Instance.spawnInterval;
        StartCoroutine(EnemySpawn());
    }

    IEnumerator EnemySpawn()
    {
        yield return new WaitForSeconds(spawnTime);
        Instantiate(GetRandomEnemyPrefab(), GenerateRandomSpawnPos(), enemyToSpawn.transform.rotation);
        StartCoroutine(EnemySpawn());
    }

    
    Vector3 GenerateRandomSpawnPos()
    {
        return new Vector3(Random.Range(-boundaryX, boundaryX), enemyToSpawn.transform.localScale.y / 2, SpawnPosZ);
    }
}

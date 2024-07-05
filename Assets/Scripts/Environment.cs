using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[DefaultExecutionOrder(12)]
public class Environment : MonoBehaviour
{
    public static Environment Instance;
    [SerializeField] GameObject RoadSegmentPrefab;
    public float spawnPos { get; private set; } = -15;
    public List<GameObject> roads;
    float speed = 10;
    void Start()
    {
        Instance = this;
        GenerateRoad();
    }

    private void Update()
    {
        Move();
    }
    private void Move()
    {
        transform.Translate(Vector3.back * speed * Time.deltaTime);
    }
    //ABSTRACTION
    private void GenerateRoad()
    {
        
        for (int i = 0; spawnPos < Spawner.Instance.SpawnPosZ; i++)
        {
            InstantiateRoadSegment(spawnPos);
            spawnPos += RoadSegmentPrefab.GetComponent<BoxCollider>().size.x;
        }
    }
    public void InstantiateRoadSegment(float _spawnPos)
    {
        Instantiate(RoadSegmentPrefab, GetSpawnPos(_spawnPos), RoadSegmentPrefab.transform.rotation, gameObject.transform);
    }
    Vector3 GetSpawnPos(float z)
    {
        return new Vector3(0, 0, z);
    }
}

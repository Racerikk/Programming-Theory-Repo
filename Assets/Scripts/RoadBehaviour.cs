using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoadBehaviour : MonoBehaviour
{
    private void Start()
    {
        Environment.Instance.roads.Add(gameObject);
    }
    private void Update()
    {
        BoundaryCheck();
    }
    private void OnDestroy()
    {
        Environment.Instance.roads.Remove(gameObject);
    }

    void BoundaryCheck()
    {
        if(transform.position.z < -15)
        {
            Environment.Instance.InstantiateRoadSegment(GetLastRoad().transform.position.z + GetLastRoad().GetComponent<BoxCollider>().size.x);
            Destroy(gameObject);
        }
    }

    //ABSTRACTION
    GameObject GetLastRoad()
    {
        return Environment.Instance.roads[Environment.Instance.roads.Count - 1];
    }
}

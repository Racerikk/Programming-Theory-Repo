using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour
{
    float speed = 15f;

    private void Update()
    {
        Move();
        BoundaryCheck();
    }

    public virtual void Move()
    {
        transform.Translate(Vector3.forward * speed * Time.deltaTime, Space.Self);
    }
    void BoundaryCheck()
    {
        if(transform.position.z < -15)
        {
            Destroy(gameObject);
        }
    }
}

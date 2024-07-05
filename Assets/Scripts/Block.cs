using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Block : MonoBehaviour
{
    float speed = 20f;

    private void Update()
    {
        Move();
        BoundaryCheck();
    }

    public virtual void Move()
    {
        transform.Translate(Vector3.forward * speed * Time.deltaTime, Space.Self);
    }
    public virtual void BoundaryCheck()
    {
        if(transform.position.z < -15)
        {
            Destroy(gameObject);
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            collision.gameObject.GetComponent<HealthSystem>().Damage(1);
            Destroy(gameObject);
        }
    }
}

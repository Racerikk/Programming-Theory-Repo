using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    float speed = 10f;
    float boundaryX = 9f;
    void Update()
    {
        BoundaryCheck();
        Movement();
    }
    void Movement()
    {
        transform.Translate(new Vector3 (Input.GetAxisRaw("Horizontal"), 0, 0) * Time.deltaTime * speed);
    }
    void BoundaryCheck()
    {
        if(transform.position.x > boundaryX)
        {
            transform.position = new Vector3(boundaryX, transform.position.y,transform.position.z);
        }
        if (transform.position.x < -boundaryX)
        {
            transform.position = new Vector3(-boundaryX, transform.position.y, transform.position.z);
        }
    }
}

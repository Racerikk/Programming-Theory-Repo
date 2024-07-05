using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class BgBlock : Block
{
    [SerializeField] float _Speed = 15f;
    Vector3 startPosition;
    float boundary = 40;
    private void Start()
    {
        startPosition = transform.position;
    }

    public override void Move()
    {
        transform.Translate(Vector3.right * _Speed * Time.deltaTime);
    }
    public override void BoundaryCheck()
    {
        if(transform.position.x > boundary)
        {
            transform.position = startPosition;
            boundary = Random.Range(35, 100);
        }
    }
}

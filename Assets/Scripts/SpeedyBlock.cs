using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//INHERITANCE
public class SpeedyBlock : Block
{
    float speed = 25f;

    public override void Move()
    {
        transform.Translate(Vector3.forward * speed * Time.deltaTime, Space.Self);
    }
}

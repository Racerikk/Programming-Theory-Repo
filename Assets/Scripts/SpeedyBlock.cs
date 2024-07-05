using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class SpeedyBlock : Block //INHERITANCE
{
    float speed = 25f;

    //POLYMORPHISM
    public override void Move()
    {
        transform.Translate(Vector3.forward * speed * Time.deltaTime, Space.Self);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class SpeedyBlock : Block //INHERITANCE
{
    float _speed = 30f;

    //POLYMORPHISM
    public override void Move()
    {
        transform.Translate(Vector3.forward * _speed * Time.deltaTime, Space.Self);
    }
}

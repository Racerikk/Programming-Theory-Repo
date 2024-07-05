using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TitleBehaviour : MonoBehaviour
{
    float distance = 20;
    private void Start()
    {
        StartCoroutine(Shake());
    }
    IEnumerator Shake()
    {
        yield return new WaitForSeconds(1.5f);
        transform.position += Vector3.down * distance;
        distance = -distance;
        StartCoroutine(Shake());
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{
    public static PlayerAnimation instance;
    [HideInInspector]public Animator animator;
    
    void Start()
    {
        instance = this;
        animator = GetComponent<Animator>();
        animator.speed = 1.5f;
        animator.SetFloat("Speed_f", 2f);
    }
}

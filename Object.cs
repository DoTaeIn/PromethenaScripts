using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Object : MonoBehaviour
{
    private Animator anim;
    private int HitNum;

    // Start is called before the first frame update
    private void Start()
    {
        anim = GetComponent<Animator>();
    }
    

    void Awake()
    {
        Break();
    }

    // Update is called once per frame
    void Update()
    {
        if (HitNum == 2)
        {
            
        }
    }
    
    void Break()
    {
        anim.SetTrigger("Hit");
    }
}

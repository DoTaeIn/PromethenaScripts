using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    private BoxCollider2D collider;
    public GameObject Apple;

    private void Awake()
    {
        collider = GetComponent<BoxCollider2D>();
    }

    public void OnTriggerEnter2D(Collider2D other)
    {
        Destroy(Apple);
    }
}

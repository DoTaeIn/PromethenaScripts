using System;
using System.Collections;
using System.Collections.Generic;
using TreeEditor;
using UnityEngine;

public class Camera : MonoBehaviour
{
    public GameObject target;
    public float moveSpeed;
    private Vector3 targetPos;

    private void Update()
    {
        if (target.gameObject != null)
        {
            targetPos.Set(target.transform.position.x, target.transform.position.y, this.transform.position.z);
            this.transform.position = Vector3.Lerp(this.transform.position, targetPos, moveSpeed * Time.deltaTime);
        }
    }
}

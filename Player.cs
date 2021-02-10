using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private HpBar health;
    [SerializeField] private HpBar mana;

    private float initHealth = 100;
    private float initMana = 50;

    public float movePower;
    private SpriteRenderer renderer;
    private Animator anim;
    private Rigidbody2D rigid;
    private Vector3 movement;
    public float HP;

    void Start()
    {
        health.Initialize(initHealth, initHealth);
        mana.Initialize(initMana, initMana);
    }

    private void getInput()
    {
        if (Input.GetKeyDown(KeyCode.I))
        {
            health.MyMaxValue -= 10;
            mana.MyCurrentValue -= 10;
        }
        
        if (Input.GetKeyDown(KeyCode.O))
        {
            health.MyMaxValue += 10;
            mana.MyCurrentValue += 10;
        }
    }

    void Awake()
    {
        rigid = GetComponent<Rigidbody2D>();
        renderer = gameObject.GetComponentInChildren<SpriteRenderer>();
        anim = GetComponent<Animator>();
        getInput();
    }
    
    void Update()
    {

        if (Input.GetAxisRaw("Horizontal") == 0)
        {
            anim.SetBool("Walk", false);
        }
        else if (Input.GetAxisRaw("Horizontal") < 0)
        {
            anim.SetBool("Walk", true);

        }
        else if (Input.GetAxisRaw("Horizontal") > 0)
        {
            anim.SetBool("Walk", true);

        }

        if (HP <= 0)
        {
            Dead();
        }
    }

    private void FixedUpdate()
    {
        Move();
    }

    void Move()
    {
        Vector3 moveVelocity = Vector3.zero;
        if (Input.GetAxisRaw("Horizontal") < 0)
        {
            moveVelocity = Vector3.left;
            renderer.flipX = true;
        }
        else if (Input.GetAxisRaw("Horizontal") > 0)
        {
            moveVelocity = Vector3.right;
            renderer.flipX = false;
        }

        transform.position += moveVelocity * movePower * Time.deltaTime;
    }

    void Dead()
    {
        
    }
}

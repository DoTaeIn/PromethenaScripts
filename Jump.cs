using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jump : MonoBehaviour
{
    [SerializeField] float m_jumpForce = 0f;

    [SerializeField] int m_maxJumpCount = 0;

    public int m_jumpCount = 0;

    private Rigidbody2D m_rigid = null;
    private float m_distance = 0f;
    private Animator anim;
    [SerializeField] LayerMask m_layerMask = 0;
    BoxCollider2D collider;


    private void Awake()
    {
        collider = GetComponent<BoxCollider2D>(); 
    }

    void Start()
    {
        m_rigid = GetComponent<Rigidbody2D>();
        m_distance = GetComponent<BoxCollider2D>().bounds.extents.y + 0.05f;
        
    }

    void TrytoJump()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            
            if (m_jumpCount < m_maxJumpCount)
            {
                if (m_jumpCount == 2)
                {
                    anim.SetBool("Double_Jump", true);
                }
                m_jumpCount++;
                m_rigid.velocity = Vector2.up * m_jumpForce;
                anim.SetTrigger("Jump");
            }
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        m_jumpCount = 0;
        anim.SetBool("Double_Jump", false);
    }

    void Checkitsground()
    {
        if (m_rigid.velocity.y < 0)
        {
            RaycastHit2D t_hit = Physics2D.Raycast(transform.position, Vector2.down, m_distance, m_layerMask);

            if (t_hit)
            {
                if (t_hit.transform.CompareTag("map"))
                {
                    m_jumpCount = 0;
                    
                }
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        TrytoJump();
        Checkitsground();
        
    }
}

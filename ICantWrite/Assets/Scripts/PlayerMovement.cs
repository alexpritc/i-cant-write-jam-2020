using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float speed = 5f;

    private Rigidbody rb;
    private Animator anim;
    private SpriteRenderer sr;

    private float x;
    private float z;

    private Vector3 lastVelocity;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        anim = GetComponent<Animator>();
        sr = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        x = Input.GetAxis("Horizontal");
        z = Input.GetAxis("Vertical");
    }

    private void FixedUpdate()
    {
        Move();
    }

    private void Move()
    {
        Vector3 inputVelocity = new Vector3(x, 0f, z);
        
        PlayAnim(inputVelocity, lastVelocity);

        if (inputVelocity.magnitude > 1f)
        {
            inputVelocity /= inputVelocity.magnitude;
        }

        rb.velocity = inputVelocity * speed;

        lastVelocity = rb.velocity;
    }

    private void PlayAnim(Vector3 inputVelocity, Vector3 lastVelocity)
    {
        if (lastVelocity.x > 0)
        {
            sr.flipX = true;
        }
        else if (lastVelocity.x < 0)
        {
            sr.flipX = false;
        }

        if (inputVelocity != Vector3.zero)
        {
            anim.Play("Walk");
        }
        else
        {
            anim.Play("Idle");
        }
    }
}

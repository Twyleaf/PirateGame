﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Ship
{
    Rigidbody2D rb;
    private HPCounter hpCounter;

    float rotateInput;
    float forwardInput;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        hpCounter = GetComponentInChildren<HPCounter>();
    }

    void Update()
    {
        rotateInput = Input.GetAxisRaw("Horizontal");
        forwardInput = Input.GetAxisRaw("Vertical");
        forwardInput = Mathf.Max(forwardInput, 0);
    }

    private void FixedUpdate()
    {
        rb.angularVelocity = 0;

        rb.rotation += -rotateInput * rotationSpeed;

        rb.velocity = (forwardInput * forwardSpeed) * Rotate(Vector2.down, rb.rotation) ;

        hpCounter.ResetPosition(transform);

    }

}

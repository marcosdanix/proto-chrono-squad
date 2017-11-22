using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour {

    public float speed;
    public bool belongsToPlayer = true;
    
    // Use this for initialization

    internal void SetDirection(float direction)
    {
        var rb = GetComponent<Rigidbody2D>();
        rb.velocity = new Vector2(this.speed * direction, 0.0f);
    }
}

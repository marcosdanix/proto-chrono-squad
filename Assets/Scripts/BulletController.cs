using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour {

    public float speed = 5.0f;
    public bool belongsToPlayer = true;
    
    // Use this for initialization
	void Start () {
        if (!belongsToPlayer)
            this.speed = 3.0f;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    internal void SetDirection(float direction)
    {
        var rb = GetComponent<Rigidbody2D>();
        rb.velocity = new Vector2(this.speed * direction, 0.0f);
    }
}

﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    public float Speed;
    public GameObject bullet;

    private Rigidbody2D rb;
    private bool grounded;
    private float direction = 1.0f;
    private Transform bulletSpawn;
    

	// Use this for initialization
	void Start ()
    {
        this.rb = GetComponent<Rigidbody2D>();
        bulletSpawn = this.transform.Find("Bullet Spawn");
        GetComponent<PlayerController>().enabled = true;
    }

    void Update()
    {
        if(Input.GetButtonDown("Fire1"))
        {
            var fired = Instantiate(bullet, bulletSpawn.position, Quaternion.identity);
            var firedComp = fired.GetComponent<BulletController>();
            firedComp.SetDirection(direction);
            
        }
    }

    // Update is called once per frame
    void FixedUpdate ()
    {
        float hor = Input.GetAxis("Horizontal");
        if (Mathf.Abs(hor) > 0.1f) direction = Mathf.Sign(hor);
        rb.velocity = new Vector2(Speed * hor, rb.velocity.y);
        transform.localScale = new Vector3(direction, 1.0f, 1.0f);
	}
}
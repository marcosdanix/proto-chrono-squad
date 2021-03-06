﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour {

    public GameObject bullet;
    public GameObject player;
    public float enemySpeed;

    private float shootTimer = 2.0f;
    private Rigidbody2D rb;
    private float direction = -1.0f;
    private Transform bulletSpawn;
    
    

	// Use this for initialization
	void Start ()
    {
        this.rb = GetComponent<Rigidbody2D>();
        bulletSpawn = this.transform.Find("Bullet Spawn");
        player = (GameObject)GameObject.FindWithTag("Player");
    }

    void Update()
    {
        if (this.transform.position.x > player.transform.position.x)
            direction = -1.0f;
        else
            direction = 1.0f;
        transform.localScale = new Vector3(direction, 1.0f, 1.0f);

        shootTimer -= Time.deltaTime;


    }

    void LateUpdate()
    {
        if (shootTimer <= 0.0f)
        {
            var fired = Instantiate(bullet, bulletSpawn.position, Quaternion.identity);
            var firedComp = fired.GetComponent<BulletController>();
            firedComp.belongsToPlayer = false;
            firedComp.speed = enemySpeed;
            firedComp.SetDirection(direction);            
            shootTimer = 2.0f;
        }
    }

}

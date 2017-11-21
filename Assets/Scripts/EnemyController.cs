using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour {

    public GameObject bullet;
    public GameObject player;

    private Rigidbody2D rb;
    internal bool grounded;
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
    }

    // Update is called once per frame
    void FixedUpdate ()
    {
    }
}

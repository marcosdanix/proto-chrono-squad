using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

class CameraController : MonoBehaviour
{
    public float leftLimit = -50.0f;
    public float rightLimit = 50.0f;

    public Transform player;

    void Awake()
    {
        player = GameObject.FindWithTag("Player").transform;
    }

    void Update()
    {
        player = GameObject.FindWithTag("Player").transform;
        transform.position = new Vector3(Mathf.Clamp(player.position.x, leftLimit, rightLimit), player.position.y, -10.0f);
    }
}

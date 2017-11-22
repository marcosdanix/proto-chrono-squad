using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

class CameraController : MonoBehaviour
{
    public float leftLimit = -50.0f;
    public float rightLimit = 50.0f;

    public static GameObject player;

    void Start()
    {
        player = (GameObject) GameObject.FindWithTag("Player");
    }

    void Update()
    {
        transform.position = new Vector3(Mathf.Clamp(player.transform.position.x, leftLimit, rightLimit), player.transform.position.y, -10.0f);
    }
}

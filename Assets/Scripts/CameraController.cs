using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

class CameraController : MonoBehaviour
{
        public float leftLimit = -50.0f;
        public float rightLimit = 50.0f;

        void Awake()
        {
           
        }

        void Update()
        {
            transform.position = new Vector3(Mathf.Clamp(transform.position.x, leftLimit, rightLimit), transform.position.y, transform.position.z);
        }
}

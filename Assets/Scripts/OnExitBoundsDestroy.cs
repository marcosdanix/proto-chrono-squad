﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnExitBoundsDestroy : MonoBehaviour {

    void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Bound"))
        {
            //Destroy(this.gameObject);
            this.gameObject.SetActive(false);
        }
    }
}

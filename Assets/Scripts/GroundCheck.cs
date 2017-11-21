using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundCheck : MonoBehaviour {

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Ground")) changeGrounded(true);
    }

    void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Ground")) changeGrounded(false);
    }

    private void changeGrounded(bool val)
    {
        GetComponentInParent<PlayerController>().grounded = val;
    }
}
